/**
 * This code was taken from:
 * https://stackoverflow.com/questions/79132936/how-to-drag-and-drop-outlook-mail-attachments-to-windows-forms-application-in-n
 * Written by Nickun (https://stackoverflow.com/users/1872437/nickun)
 */

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistiek_Bonnensorteerder
{
    public class FileDragAndDropHelper
    {
        private static string[] ForbiddenFormats = { "mail", "folder", "appointment" };
        private static string[] FileContentFormats = { "FileGroupDescriptor", "FileGroupDescriptorW", "FileContents" };
        private bool _isFileDragged;
        private bool _isAsyncOperationInProgress;

        public void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            _isFileDragged = false;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                _isFileDragged = files?.Length > 0 || e.Data.GetDataPresent("Chromium Web Custom MIME Data Format");
            }
            else
            {
                string[] formats = e.Data.GetFormats();

                _isFileDragged = formats.Any(format => FileContentFormats.Contains(format)) &&
                    formats.All(format => ForbiddenFormats.All(p => !format.Equals(p, StringComparison.InvariantCultureIgnoreCase)));
            }
            e.Effect = _isFileDragged ? DragDropEffects.Copy : DragDropEffects.None;
        }

        public void DragLeave(object sender, EventArgs e)
        {
            _isFileDragged = false;
        }

        /// <summary>
        /// Standard drag-and-drop handler for files.
        /// </summary>
        public string[] DragDropFiles(DragEventArgs e)
        {
            if (!_isFileDragged)
                return Array.Empty<string>();

            // Handle the drag-and-drop operation here
            // Implement your logic to process the files
            return null;
        }

        /// <summary>
        /// Asynchronous drag-and-drop handler for files.
        /// </summary>
        public async Task<string[]> DragDropFilesAsync(DragEventArgs e)
        {
            if (_isAsyncOperationInProgress)
            {
                // If an async operation is already in progress, do not start a new one
                throw new InvalidOperationException("An async operation is already in progress.");
            }

            // Check if the data contains the custom MIME format for Chromium Web
            // as it can be a sign that asynchronous operation is supported
            if (!e.Data.GetDataPresent("Chromium Web Custom MIME Data Format"))
            {
                // Fallback to the simple drag-and-drop handler
                return DragDropFiles(e);
            }

            // Get the native IDataObject and check for async capability
            MarshalByRefObject nativeDataObject = GetNativeIDataObject(e);
            if (!(nativeDataObject is NativeMethods.IDataObjectAsyncCapability asyncCapability))
            {
                // If not async-capable, fall back to the simple method
                return DragDropFiles(e);
            }

            try
            {
                // Tell Outlook we can handle the operation asynchronously
                asyncCapability.SetAsyncMode(true);

                // Start the asynchronous operation
                asyncCapability.StartOperation(null);
                _isAsyncOperationInProgress = true;
            }
            catch (Exception ex)
            {
                // If starting the async operation fails, handle the error
                int hResult = Marshal.GetHRForException(ex);
                asyncCapability.EndOperation(hResult, null, DragDropEffects.None);
                throw new InvalidOperationException("Failed to start async operation.", ex);
            }

            // Perform the data retrieval on a background thread
            var dropResult = await Task.Run(() =>
            {
                try
                {
                    // Now, get the FileDrop data. Because we are in an async operation,
                    // this call will now block until the temporary files are ready.
                    string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (filePaths == null || filePaths.Length == 0)
                    {
                        throw new InvalidOperationException("No files were dropped.");
                    }
                    return new { Success = true, Paths = filePaths, Exception = (Exception)null };
                }
                catch (Exception ex)
                {
                    return new { Success = false, Paths = (string[])null, Exception = ex };
                }
            });

            // We are now back on the UI thread
            _isAsyncOperationInProgress = false; // Reset async operation flag
            if (dropResult.Success)
            {
                // Signal successful completion to Outlook
                asyncCapability.EndOperation(0, null, e.Effect); // S_OK = 0
                System.Collections.Generic.List<FileInfo> files = dropResult.Paths
                    .Select(path => new FileInfo(path))
                    .Where(file => file.Exists)
                    .ToList();
                return files.Select(file => file.FullName).ToArray();
            }
            else
            {
                // Signal an error to Outlook
                int hResult = Marshal.GetHRForException(dropResult.Exception);
                asyncCapability.EndOperation(hResult, null, DragDropEffects.None);
                throw new InvalidOperationException($"An error occurred: {dropResult.Exception.Message}");
            }
        }

        public static MarshalByRefObject GetNativeIDataObject(DragEventArgs e)
        {
            object oleUnderlyingDataObject = e.Data.GetType()
                .GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(e.Data);

            return (MarshalByRefObject)oleUnderlyingDataObject?.GetType()
                .GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(oleUnderlyingDataObject);
        }

        private class NativeMethods
        {
            // IDataObjectAsyncCapability Interface
            [ComImport]
            [Guid("3D8B0590-F691-11d2-8EA9-006097DF5BD4")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            public interface IDataObjectAsyncCapability
            {
                void SetAsyncMode([In, MarshalAs(UnmanagedType.Bool)] bool fDoOpAsync);
                void GetAsyncMode([Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsOpAsync);
                void StartOperation([In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbcReserved);
                void InOperation([Out, MarshalAs(UnmanagedType.Bool)] out bool pfInAsyncOp);
                void EndOperation([In, MarshalAs(UnmanagedType.Error)] int hResult,
                                  [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbcReserved,
                                  [In] DragDropEffects dwEffects);
            }
        }
    }
}
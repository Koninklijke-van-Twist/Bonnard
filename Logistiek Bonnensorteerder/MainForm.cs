using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Logistiek_Bonnensorteerder.Config;

namespace Logistiek_Bonnensorteerder
{
    public partial class MainForm : Form
    {
        #region Consts

        private const string NoFileSelected = "Geen document(en) geselecteerd";
        private const string PdfFileExtension = ".pdf";

        // Could have taken this from the Datetime object, but we want them to be consistent regardless of culture settings and include a number.
        private static string[] months = { "01. januari", "02. februari" , "03. maart", "04. april", "05. mei", "06. juni", "07. juli", "08. augustus", "09. september", "10. october", "11. november", "12. december"};
        private static FileDragAndDropHelper DragDropHelper = new FileDragAndDropHelper();

        #endregion

        #region Properties

        // Generate the folder name for the current file's document type
        public string DocumentTypeFolderName => Regex.Replace($"{documentTypeDropdown.SelectedIndex + 1:D2}. {ConfigFile.documentTypes[documentTypeDropdown.SelectedIndex].name}{Environment.NewLine}", Environment.NewLine, "");
        
        // Generate the path name for the current file to be saved in, which includes the DocumentTypeFolderName and the date the user entered in the form.
        public string DestinationFolder => $"{ConfigFile.DestinationPathRoot}\\{DocumentTypeFolderName}\\{dateTimePicker.Value.Year}\\{months[dateTimePicker.Value.Month-1]}\\";
        
        // If the currently seleced file is changed, automatically reset some form elements and reset the PDF preview.
        public string SelectedFile
        {
            get
            {
                return _currentSelectedFile;
            }

            set
            {
                _currentSelectedFile = value;

                UpdateFileSelectedLabel();

                // We have to clear the PDF preview first, so that the current held file is properly disposed.
                if (value != NoFileSelected)
                {
                    ClearPDFPreview();
                    pdfViewer.Show();
                }
                else
                {
                    pdfViewer.Hide();
                }
                    
                pdfViewer.Document = PdfiumViewer.PdfDocument.Load(_currentSelectedFile);
            }
        }

        public string ConfigFilePath => Path.Combine(AppContext.BaseDirectory, "config.json");
        public string ReleaseNumberFilePath => Path.Combine(AppContext.BaseDirectory, "release.number");

        #endregion

        #region Static Methods

        public static bool CanWriteToFile(string filePath)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Write))
                {
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
        }

        #endregion

        #region Private Variables

        internal static Config ConfigFile;

        // When a user selects more than one file, they are placed in a queue to be handled one by one
        private Queue<string> _selectedFiles = new Queue<string>();
        private string _currentSelectedFile = NoFileSelected;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            openFileDialog.Multiselect = true;

            LoadConfigFile();
            InitializeForm();
        }

        #region Events

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                Directory.CreateDirectory(DestinationFolder);
                try
                {
                    string targetName = DestinationFolder + GetResultFileName();
                    File.Copy(SelectedFile, targetName);
                    OnPostSave(targetName);
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden. Het bestand is mogelijk niet opgeslagen.\nMogelijk is dit document al eerder ingevoerd; controleer dit handmatig.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }
        private void fileSelectorButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "PDF Bestanden|*.pdf";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleOpenedFiles(openFileDialog.FileNames);
        }

        private void cancelAndRestartButton_Click(object sender, EventArgs e)
        {
            cancelAndRestartButton.Enabled = false;

            orderNumberTextbox.Text = "";
            pickbonTextbox.Text = "";

            dateTimePicker.Value = DateTime.Now;
            departmentDropdown.SelectedIndex = 0;
            documentTypeDropdown.SelectedIndex = 0;
            customerNameTextbox.Text = "";
            transporterTextbox.Text = "";

            _selectedFiles.Clear();
            selectedDocumentPathLabel.Text = NoFileSelected;

            ClearPDFPreview();

            fileSelectorButton.Enabled = true;
            saveButton.Enabled = false;
            SetAllowedRequiredElements();
        }

        private void editConfigButton_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
            LoadConfigFile();
            InitializeForm();
        }

        private void releaseLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Koninklijke-van-Twist/Bonnard/releases");
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if ((string[])e.Data.GetData(DataFormats.FileDrop) is string[] files)
            {
                bool hasPdf = files.Any(f => Path.GetExtension(f).Equals(PdfFileExtension, StringComparison.OrdinalIgnoreCase)
                                             && !_selectedFiles.Contains(f) && SelectedFile != f);

                e.Effect = hasPdf ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                // This is likely an Outlook attachment
                if (OutlookContainsPdf(e.Data))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                DragDropHelper.DragEnter(sender, e);
            }
        }

        private async void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if ((string[])e.Data.GetData(DataFormats.FileDrop) is string[] files)
            {
                IEnumerable<string> pdfFiles = files.Where(f => Path.GetExtension(f).Equals(PdfFileExtension, StringComparison.OrdinalIgnoreCase));
                HandleOpenedFiles(pdfFiles.ToArray());
                return;
            }
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                // Handle "old" Outlook attachments
                List<string> savedPdfPaths = SavePdfAttachmentsFromOutlook(e.Data);
                if (savedPdfPaths.Any())
                {
                    HandleOpenedFiles(savedPdfPaths.ToArray());
                    return;
                }
            }

            try
            {
                string[] filesAsync = await DragDropHelper.DragDropFilesAsync(e);
                if (filesAsync != null && filesAsync.Length > 0)
                {
                    IEnumerable<string> pdfFiles = filesAsync.Where(f => Path.GetExtension(f).Equals(PdfFileExtension, StringComparison.OrdinalIgnoreCase));
                    HandleOpenedFiles(pdfFiles.ToArray());
                    return;
                }
                else
                {
                    MessageBox.Show("Geen bruikbare bestanden aangetroffen in de Drag&Drop. Alleen PDF bestanden worden ondersteund.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout gevonden bij het verwerken van: {ex.Message}");
            }
        }

        private void departmentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllowedRequiredElements();
        }

        private void documentTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllowedRequiredElements();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generate a proper filename based on all input values for the currently selected file.
        /// This includes a .pdf file extension.
        /// </summary>
        private string GetResultFileName()
        {
            string result = "";

            result += $"{dateTimePicker.Value.Year}-{dateTimePicker.Value.Month.ToString("d2")}-{dateTimePicker.Value.Day.ToString("d2")}";

            if (departmentDropdown.SelectedItem != null && departmentDropdown.SelectedIndex != 0)
            {
                result += $"_{departmentDropdown.SelectedItem as string}";
            }

            if(orderNumberTextbox.Text.Length > 0)
            {
                result += $"_{orderNumberTextbox.Text}";
            }

            if (pickbonTextbox.Text.Length > 0)
            {
                result += $"_{pickbonTextbox.Text}";
            }

            if (customerNameTextbox.Text.Length > 0)
            {
                result += $"_{customerNameTextbox.Text}";
            }

            if (transporterTextbox.Text.Length > 0)
            {
                result += $"_{transporterTextbox.Text}";
            }

            result += $"_{documentTypeDropdown.SelectedItem as string}";

            return result + PdfFileExtension;
        }

        private void SetAllowedRequiredElements()
        {
            try
            {
                RestrictableListEntry department = departmentDropdown.SelectedIndex - 1 >= 0? ConfigFile.departments[departmentDropdown.SelectedIndex - 1] : new RestrictableListEntry(); // account fo runspecified
                RestrictableListEntry documentType = ConfigFile.documentTypes[documentTypeDropdown.SelectedIndex];

                department.FixDictionaries();
                documentType.FixDictionaries();

                departmentDropdown.Enabled = department.allowedEntries["department"] && documentType.allowedEntries["department"];
                orderNumberTextbox.Enabled = department.allowedEntries["orderNumber"] && documentType.allowedEntries["orderNumber"];
                pickbonTextbox.Enabled = department.allowedEntries["pickbon"] && documentType.allowedEntries["pickbon"];
                customerNameTextbox.Enabled = department.allowedEntries["customerName"] && documentType.allowedEntries["customerName"];
                transporterTextbox.Enabled = department.allowedEntries["transporterName"] && documentType.allowedEntries["transporterName"];

                if (!departmentDropdown.Enabled) departmentDropdown.SelectedIndex = 0;
                if (!orderNumberTextbox.Enabled) orderNumberTextbox.Text = "";
                if (!pickbonTextbox.Enabled) pickbonTextbox.Text = "";
                if (!customerNameTextbox.Enabled) customerNameTextbox.Text = "";
                if (!transporterTextbox.Enabled) transporterTextbox.Text = "";

                departmentLabel.Font = new Font(departmentLabel.Font, department.requiredEntries["department"] || documentType.requiredEntries["department"] ? FontStyle.Underline : FontStyle.Regular);
                orderNumberLabel.Font = new Font(orderNumberLabel.Font, department.requiredEntries["orderNumber"] || documentType.requiredEntries["orderNumber"] ? FontStyle.Underline : FontStyle.Regular);
                pickbonLabel.Font = new Font(pickbonLabel.Font, department.requiredEntries["pickbon"] || documentType.requiredEntries["pickbon"] ? FontStyle.Underline : FontStyle.Regular);
                customerNameLabel.Font = new Font(customerNameLabel.Font, department.requiredEntries["customerName"] || documentType.requiredEntries["customerName"] ? FontStyle.Underline : FontStyle.Regular);
                transporterNameLabel.Font = new Font(transporterNameLabel.Font, department.requiredEntries["transporterName"] || documentType.requiredEntries["transporterName"] ? FontStyle.Underline : FontStyle.Regular);
            }
            catch
            {
                Console.WriteLine("Index out of range (likely initializing)");
            }
        }

        private void HandleOpenedFiles(string[] files)
        {
            foreach (string fileName in files)
            {
                if (!_selectedFiles.Contains(fileName) && SelectedFile != fileName)
                {
                    _selectedFiles.Enqueue(fileName);
                }
            }

            if (SelectedFile == NoFileSelected)
            {
                SelectedFile = _selectedFiles.Dequeue();
            }
            else
            {
                UpdateFileSelectedLabel();
            }

            fileSelectorButton.Enabled = false;
            cancelAndRestartButton.Enabled = true;
            editConfigButton.Enabled = false;
            saveButton.Enabled = Path.GetExtension(SelectedFile) == PdfFileExtension;
        }

        private void UpdateFileSelectedLabel()
        {
            selectedDocumentPathLabel.Text = Regex.Split(_currentSelectedFile, "\\\\").Last();

            if (_selectedFiles.Count > 0)
                selectedDocumentPathLabel.Text += $" (+{_selectedFiles.Count})";
        }

        private void LoadConfigFile()
        {
            if (!File.Exists(ConfigFilePath))
            {
                Console.WriteLine("Configuratiebestand niet gevonden!");
                return;
            }

            string json = File.ReadAllText(ConfigFilePath);
            ConfigFile = JsonConvert.DeserializeObject<Config>(json);

            departmentDropdown.Items.Clear();
            departmentDropdown.Items.Add("Ongespecificeerd");
            departmentDropdown.Items.AddRange(ConfigFile.departments.Select(o => o.name).ToArray());

            documentTypeDropdown.Items.Clear();
            documentTypeDropdown.Items.AddRange(ConfigFile.documentTypes.Select(o => o.name).ToArray());
        }

        private bool OutlookContainsPdf(IDataObject data)
        {
            List<string> names = GetOutlookAttachmentNames(data);
            return names.Any(name => Path.GetExtension(name).Equals(PdfFileExtension, StringComparison.OrdinalIgnoreCase));
        }

        private List<string> SavePdfAttachmentsFromOutlook(IDataObject data)
        {
            List<string> savedFiles = new List<string>();
            List<string> fileNames = GetOutlookAttachmentNames(data);

            for (int i = 0; i < fileNames.Count; i++)
            {
                string name = fileNames[i];
                if (Path.GetExtension(name).Equals(PdfFileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    Stream stream = GetOutlookAttachmentStream(data, i);

                    string tempFilePath = Path.Combine(Path.GetTempPath(), name);
                    using (FileStream output = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(output);
                    }

                    savedFiles.Add(tempFilePath);
                }
            }

            return savedFiles;
        }

        private List<string> GetOutlookAttachmentNames(IDataObject data)
        {
            List<string> result = new List<string>();

            MemoryStream fileGroupDescriptorStream = (MemoryStream)data.GetData("FileGroupDescriptor");
            byte[] buffer = new byte[fileGroupDescriptorStream.Length];
            fileGroupDescriptorStream.Read(buffer, 0, buffer.Length);

            int fileCount = BitConverter.ToInt32(buffer, 0);
            for (int i = 0; i < fileCount; i++)
            {
                int offset = 76 + (i * 592); // FILEDESCRIPTOR struct size
                string name = Encoding.Default.GetString(buffer, offset, 260).TrimEnd('\0');
                result.Add(name);
            }

            return result;
        }

        private Stream GetOutlookAttachmentStream(IDataObject data, int index)
        {
            if (data.GetData("FileContents") is MemoryStream singleStream && index == 0)
            {
                return singleStream;
            }

            // Handle multiple attachments
            if (data.GetData("FileContents") is MemoryStream[] multipleStreams && index < multipleStreams.Length)
            {
                return multipleStreams[index];
            }

            return Stream.Null;
        }


        private void InitializeForm()
        {
            editConfigButton.Enabled = CanWriteToFile(ConfigFilePath);

            saveButton.Enabled = false;
            departmentDropdown.SelectedIndex = 0;
            documentTypeDropdown.SelectedIndex = 0;

            departmentDropdown.SelectedItem = departmentDropdown.Items[0];
            documentTypeDropdown.SelectedItem = documentTypeDropdown.Items[0];

            try
            {
                string releaseNumber = File.ReadAllText(ReleaseNumberFilePath);
                releaseLabel.Text = releaseNumber;
            }
            catch
            {
                releaseLabel.Text = "onbekende release";
            }

            SetAllowedRequiredElements();
        }

        private void OnPostSave(string savedName)
        {
            selectedDocumentPathLabel.Text = "";

            if (!ConfigFile.keepOriginalFile)
            {
                ClearPDFPreview();
                File.Delete(SelectedFile);
            }

            orderNumberTextbox.Text = "";
            pickbonTextbox.Text = "";

            if (_selectedFiles.Count > 0)
            {
                SelectedFile = _selectedFiles.Dequeue();
                MessageBox.Show($"Bestand opgeslagen als '{savedName}'.\n\nHet volgende bestand is nu geselecteerd; u kunt meteen verder gaan.\n({SelectedFile})", "Opgeslagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileSelectorButton.Enabled = false;

                cancelAndRestartButton.Enabled = true;
                editConfigButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = false;
                
                dateTimePicker.Value = DateTime.Now;
                departmentDropdown.SelectedIndex = 0;
                documentTypeDropdown.SelectedIndex = 0;
                customerNameTextbox.Text = "";
                transporterTextbox.Text = "";

                MessageBox.Show($"Bestand opgeslagen als '{savedName}'.", "Opgeslagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileSelectorButton.Enabled = true;
                cancelAndRestartButton.Enabled = false;
                editConfigButton.Enabled = CanWriteToFile(ConfigFilePath);

                ClearPDFPreview();
                _currentSelectedFile = NoFileSelected;
                SetAllowedRequiredElements();
            }
        }

        private bool ValidateInput()
        {
            bool anyNotMet = false;
            RestrictableListEntry department = departmentDropdown.SelectedIndex - 1 >= 0 ? ConfigFile.departments[departmentDropdown.SelectedIndex - 1] : new RestrictableListEntry(); // account fo runspecified
            RestrictableListEntry documentType = ConfigFile.documentTypes[documentTypeDropdown.SelectedIndex];

            department.FixDictionaries();
            documentType.FixDictionaries();

            if (department.requiredEntries["department"] && departmentDropdown.SelectedIndex == 0) anyNotMet = true;
            if (department.requiredEntries["orderNumber"] && orderNumberTextbox.Text.Length == 0) anyNotMet = true;
            if (department.requiredEntries["pickbon"] && pickbonTextbox.Text.Length == 0) anyNotMet = true;
            if (department.requiredEntries["customerName"] && customerNameTextbox.Text.Length == 0) anyNotMet = true;
            if (department.requiredEntries["transporterName"] && transporterTextbox.Text.Length == 0) anyNotMet = true;

            if (documentType.requiredEntries["department"] && departmentDropdown.SelectedIndex == 0) anyNotMet = true;
            if (documentType.requiredEntries["orderNumber"] && orderNumberTextbox.Text.Length == 0) anyNotMet = true;
            if (documentType.requiredEntries["pickbon"] && pickbonTextbox.Text.Length == 0) anyNotMet = true;
            if (documentType.requiredEntries["customerName"] && customerNameTextbox.Text.Length == 0) anyNotMet = true;
            if (documentType.requiredEntries["transporterName"] && transporterTextbox.Text.Length == 0) anyNotMet = true;

            if (anyNotMet)
            {
                MessageBox.Show("Één of meerdere vereiste velden zijn niet ingevuld.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (SelectedFile == NoFileSelected)
            {
                MessageBox.Show("Er is geen document geselecteerd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (documentTypeDropdown.SelectedItem == null)
            {
                MessageBox.Show("Er is geen documenttype geselecteerd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearPDFPreview()
        {
            pdfViewer.Document?.Dispose();
            pdfViewer.Document = null;
            pdfViewer.Renderer.Invalidate();
            pdfViewer.Hide();
        }

        #endregion
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Logistiek_Bonnensorteerder
{
    public partial class MainForm : Form
    {
        #region Consts

        private const string NoFileSelected = "Geen document(en) geselecteerd";
        private const string PdfFileExtension = ".pdf";

        // Could have taken this from the Datetime object, but we want them to be consistent regardless of culture settings and include a number.
        private static string[] months = { "01. januari", "02. februari" , "03. maart", "04. april", "05. mei", "06. juni", "07. juli", "08. augustus", "09. september", "10. october", "11. november", "12. december"};

        #endregion

        #region Properties

        // Generate the folder name for the current file's document type
        public string DocumentTypeFolderName => Regex.Replace($"{documentTypeDropdown.SelectedIndex + 1:D2}. {ConfigFile.documentTypes[documentTypeDropdown.SelectedIndex]}{Environment.NewLine}", Environment.NewLine, "");
        
        // Generate the path name for the current file to be saved in, which includes the DocumentTypeFolderName and the date the user entered in the form.
        public string DestinationFolder => $"{ConfigFile.destinationPathRoot}\\{DocumentTypeFolderName}\\{dateTimePicker.Value.Year}\\{months[dateTimePicker.Value.Month-1]}\\";
        
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
                selectedDocumentPathLabel.Text = Regex.Split(_currentSelectedFile, "\\\\").Last();

                if (_selectedFiles.Count > 0)
                    selectedDocumentPathLabel.Text += $" (+{_selectedFiles.Count})";

                // We have to clear the PDF preview first, so that the current held file is properly disposed.
                ClearPDFPreview();
                pdfViewer.Show();
                pdfViewer.Document = PdfiumViewer.PdfDocument.Load(_currentSelectedFile);
            }
        }

        public string ConfigFilePath => Path.Combine(AppContext.BaseDirectory, "config.json");

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
        private string _currentSelectedFile = "";

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
            foreach(string fileName in openFileDialog.FileNames)
                _selectedFiles.Enqueue(fileName);

            SelectedFile = _selectedFiles.Dequeue();

            fileSelectorButton.Enabled = false;
            cancelAndRestartButton.Enabled = true;
            editConfigButton.Enabled = false;
            saveButton.Enabled = openFileDialog.FileName.Substring(openFileDialog.FileName.Length - 4, 4).ToLower() == PdfFileExtension;
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
        }

        private void editConfigButton_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
            LoadConfigFile();
            InitializeForm();
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

            result += $"{dateTimePicker.Value.Year}-{dateTimePicker.Value.Month}-{dateTimePicker.Value.Day}";

            if (departmentDropdown.SelectedItem != null)
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
            departmentDropdown.Items.AddRange(ConfigFile.departments);

            documentTypeDropdown.Items.Clear();
            documentTypeDropdown.Items.AddRange(ConfigFile.documentTypes);
        }

        private void InitializeForm()
        {
            editConfigButton.Enabled = CanWriteToFile(ConfigFilePath);

            saveButton.Enabled = false;
            departmentDropdown.SelectedIndex = 0;
            documentTypeDropdown.SelectedIndex = 0;

            departmentDropdown.SelectedItem = departmentDropdown.Items[0];
            documentTypeDropdown.SelectedItem = documentTypeDropdown.Items[0];
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
                editConfigButton.Enabled = true;

                ClearPDFPreview();
            }
        }

        private bool ValidateInput()
        {
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

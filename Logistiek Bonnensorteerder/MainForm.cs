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
        private static string[] months = { "01.januari", "02.februari" , "03.maart", "04.april", "05.mei", "06.juni", "07.juli", "08.augustus", "09.september", "10.october", "11.november", "12.december"};

        #endregion

        #region Properties

        public bool HasFileSelected => _currentSelectedFile != NoFileSelected;
        public string DestinationFolder => $"{_config.destinationPathRoot}\\{dateTimePicker.Value.Year}\\{months[dateTimePicker.Value.Month-1]}\\";
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
            }
        }

        #endregion

        #region Private Variables

        private Config _config;
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
                    File.Copy(openFileDialog.FileName, targetName);
                    OnPostSave(targetName);
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden. Het bestand is niet opgeslagen.\nMogelijk is dit document al eerder ingevoerd; controleer dit handmatig.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void fileSelectorButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach(string fileName in openFileDialog.FileNames)
                _selectedFiles.Enqueue(fileName);

            SelectedFile = _selectedFiles.Dequeue();

            saveButton.Enabled = openFileDialog.FileName.Substring(openFileDialog.FileName.Length - 4, 4).ToLower() == PdfFileExtension;
        }

        #endregion

        #region Private Methods

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
            string exeDirectory = AppContext.BaseDirectory;
            string configPath = Path.Combine(exeDirectory, "config.json");

            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuratiebestand niet gevonden!");
                return;
            }

            string json = File.ReadAllText(configPath);
            _config = JsonConvert.DeserializeObject<Config>(json);

            departmentDropdown.Items.Clear();
            departmentDropdown.Items.Add("Ongespecificeerd");
            departmentDropdown.Items.AddRange(_config.departments);

            documentTypeDropdown.Items.Clear();
            documentTypeDropdown.Items.AddRange(_config.documentTypes);
        }

        private void InitializeForm()
        {
            saveButton.Enabled = false;
            departmentDropdown.SelectedIndex = 0;
        }

        private void OnPostSave(string savedName)
        {
            if (!_config.keepOriginalFile)
            {
                File.Delete(SelectedFile);
            }

            SelectedFile = NoFileSelected;

            if (_selectedFiles.Count > 0)
            {
                SelectedFile = _selectedFiles.Dequeue();
            }

            orderNumberTextbox.Text = "";
            pickbonTextbox.Text = "";

            if (!HasFileSelected)
            {
                dateTimePicker.Value = DateTime.Now;
                departmentDropdown.SelectedIndex = 0;
                documentTypeDropdown.SelectedIndex = 0;
                customerNameTextbox.Text = "";
                transporterTextbox.Text = "";

                MessageBox.Show($"Bestand opgeslagen als '{savedName}'.", "Opgeslagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileSelectorButton.Enabled = true;
            }
            else
            {
                MessageBox.Show($"Bestand opgeslagen als '{savedName}'.\nHet volgende bestand ({SelectedFile}) is nu geselecteerd; u kunt meteen verder gaan.", "Opgeslagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileSelectorButton.Enabled = false;
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

        #endregion
    }
}

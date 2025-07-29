using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Logistiek_Bonnensorteerder
{
    public partial class MainForm : Form
    {
        #region Consts

        private const string NoFileSelected = "NoFileSelected";
        private const string PdfFileExtension = ".pdf";

        // Could have taken this from the Datetime object, but we want them to be consistent regardless of culture settings and include a number.
        private static string[] months = { "01.januari", "02.februari" , "03.maart", "04.april", "05.mei", "06.juni", "07.juli", "08.augustus", "09.september", "10.october", "11.november", "12.december"};

        #endregion

        #region Properties

        public string DestinationFolder => $"{_config.destinationPathRoot}\\{dateTimePicker.Value.Year}\\{months[dateTimePicker.Value.Month-1]}\\";

        #endregion

        #region Private Variables

        private Config _config;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            LoadConfigFile();
            InitializeForm();
        }

        #region Events

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                Directory.CreateDirectory(DestinationFolder);
                File.Copy(openFileDialog.FileName, DestinationFolder + GetResultFileName());
            }
        }
        private void fileSelectorButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            selectedDocumentPathLabel.Text = Regex.Split(openFileDialog.FileName, "\\").Last();

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
                Console.WriteLine("Configuration file not found!");
                return;
            }

            string json = File.ReadAllText(configPath);
            _config = JsonConvert.DeserializeObject<Config>(json);

            departmentDropdown.Items.Clear();
            departmentDropdown.Items.AddRange(_config.departments);

            documentTypeDropdown.Items.Clear();
            documentTypeDropdown.Items.AddRange(_config.documentTypes);
        }

        private void InitializeForm()
        {
            saveButton.Enabled = false; 
            openFileDialog.FileName = NoFileSelected;
        }

        private bool ValidateInput()
        {
            if (openFileDialog.FileName == NoFileSelected)
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

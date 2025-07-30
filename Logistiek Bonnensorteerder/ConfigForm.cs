using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistiek_Bonnensorteerder
{
    public partial class ConfigForm : Form
    {
        #region Private Variables

        private string _oldPath = "";

        #endregion

        public ConfigForm()
        {
            InitializeComponent();
            SetFieldsFromConfig();
        }

        #region Private Methods

        private void SetFieldsFromConfig()
        {
            departmentsConfigInput.Text = string.Join(Environment.NewLine, MainForm.ConfigFile.departments);
            documentTypesConfigInput.Text = string.Join(Environment.NewLine, MainForm.ConfigFile.documentTypes);

            rootFolderTextfield.Text = MainForm.ConfigFile.destinationPathRoot;
            saveOriginalFileCheckbox.Checked = MainForm.ConfigFile.keepOriginalFile;
            _oldPath = MainForm.ConfigFile.destinationPathRoot;

            RefreshLabels();
        }

        private void RefreshLabels()
        {
            string[] departments = Regex.Split(departmentsConfigInput.Text, Environment.NewLine);
            string[] documentTypes = Regex.Split(documentTypesConfigInput.Text, Environment.NewLine);

            departmentsConfigLabel.Text = "";
            for (int i = 0; i < departments.Length; i++)
            {
                departmentsConfigLabel.Text += $"[{departments[i]}]{Environment.NewLine}";
            }

            documentTypesConfigLabel.Text = "";
            for (int i = 0; i < documentTypes.Length; i++)
            {
                documentTypesConfigLabel.Text += $"{i + 1:D2}. {documentTypes[i]}{Environment.NewLine}";
            }
        }

        private bool IsValidLocalPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            try
            {
                // Probeert het pad te normaliseren.
                string fullPath = Path.GetFullPath(path);

                // Extra check: root moet aanwezig zijn (bijvoorbeeld "C:\" of "\\server\share")
                string root = Path.GetPathRoot(fullPath);
                return !string.IsNullOrWhiteSpace(root) && Path.IsPathRooted(fullPath);
            }
            catch
            {
                return false;
            }
        }

        private string NormalizeAsFolderPath(string inputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath))
                throw new ArgumentException("Pad mag niet leeg zijn.");

            // Verandert naar absoluut pad (ook voor relatieve paden).
            string fullPath = Path.GetFullPath(inputPath);

            // Controleer of het pad lijkt op een bestand (heeft bestandsextensie)
            // Zo ja: strip bestand, ga naar directory.
            if (Path.HasExtension(fullPath))
            {
                fullPath = Path.GetDirectoryName(fullPath);
            }

            // Verwijder eventuele trailing slashes (zonder root te verwijderen, zoals "C:\")
            if (fullPath.EndsWith(Path.DirectorySeparatorChar.ToString()) && fullPath.Length > Path.GetPathRoot(fullPath).Length)
            {
                fullPath = fullPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }

            fullPath = Regex.Replace(fullPath, Environment.NewLine, "");

            return fullPath;
        }

        #endregion

        #region Events

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            MainForm.ConfigFile.keepOriginalFile = saveOriginalFileCheckbox.Checked;

            MainForm.ConfigFile.departments = Regex.Split(departmentsConfigInput.Text, Environment.NewLine);
            MainForm.ConfigFile.documentTypes = Regex.Split(documentTypesConfigInput.Text, Environment.NewLine);

            MainForm.ConfigFile.destinationPathRoot = _oldPath;

            string jsonConfig = Newtonsoft.Json.JsonConvert.SerializeObject(MainForm.ConfigFile);

            string exeDirectory = AppContext.BaseDirectory;
            string configPath = Path.Combine(exeDirectory, "config.json");

            File.WriteAllText(configPath, jsonConfig);
            Close();
        }

        private void departmentsConfigInput_TextChanged(object sender, EventArgs e)
        {
            RefreshLabels();
        }

        private void documentTypesConfigLabel_Click(object sender, EventArgs e)
        {
            RefreshLabels();
        }

        private void rootFolderTextfield_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidLocalPath(rootFolderTextfield.Text.Trim()))
            {
                MessageBox.Show("Het opgegeven pad is niet geldig.", "Pad niet valide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _oldPath = NormalizeAsFolderPath(rootFolderTextfield.Text.Trim());
            }

            rootFolderTextfield.Text = _oldPath;
        }

        private void saveOriginalFileCheckbox_CheckedChanged(object sender, EventArgs e)
        {
              
        }

        #endregion
    }
}

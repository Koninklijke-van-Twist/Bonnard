using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Logistiek_Bonnensorteerder.Config;

namespace Logistiek_Bonnensorteerder
{
    public partial class ConfigForm : Form
    {
        #region Static Variables

        public static RestrictableListEntry CurrentlyEditedEntry;
        public static bool CurrentlyEditedEntryIsDepartment;

        #endregion

        #region Private Variables

        private string _oldPath = "";
        private Config _tempConfig;

        #endregion

        public ConfigForm()
        {
            InitializeComponent();
            SetFieldsFromConfig();
        }

        #region Private Methods

        private void SetFieldsFromConfig()
        {
            _tempConfig = MainForm.ConfigFile;
            departmentsPanel.Controls.Clear();
            foreach (RestrictableListEntry dept in _tempConfig.departments)
            {
                departmentsPanel.Controls.Add(CreateConfigEntryControl(dept, "department", _tempConfig.departments.IndexOf(dept)));
            }

            documentTypesPanel.Controls.Clear();
            foreach (RestrictableListEntry docType in _tempConfig.documentTypes)
            {
                documentTypesPanel.Controls.Add(CreateConfigEntryControl(docType, "documentType", _tempConfig.documentTypes.IndexOf(docType)));
            }

            rootFolderTextfield.Text = _tempConfig.destinationPathRoot;
            saveOriginalFileCheckbox.Checked = _tempConfig.keepOriginalFile;
            _oldPath = _tempConfig.destinationPathRoot;
        }

        private string TransformOnedrivePath(string original)
        {
            if (original.ToLower().StartsWith("onedrive://"))
            {
                return Regex.Replace(original, "onedrive://", Environment.GetEnvironmentVariable("OneDrive"), RegexOptions.IgnoreCase);
            }
            else if (original.ToLower().StartsWith("onedrive:\\\\"))
            {
                return Regex.Replace(original, "onedrive:\\\\", Environment.GetEnvironmentVariable("OneDrive"), RegexOptions.IgnoreCase);
            }

            return original;
        }

        private bool IsValidLocalPath(string path)
        {
            path = TransformOnedrivePath(path);

            if (string.IsNullOrWhiteSpace(path))
                return false;

            try
            {
                // Probeert het pad te normaliseren.
                string fullPath = Path.GetFullPath(path);

                // Extra check: root moet aanwezig zijn (bijvoorbeeld "C:\" of "\\server\share")
                string root = Path.GetPathRoot(fullPath);
                return !string.IsNullOrWhiteSpace(root) && (Path.IsPathRooted(fullPath));
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

            if (inputPath.ToLower().StartsWith("onedrive://"))
            {
                return Regex.Replace(inputPath, "onedrive://", "onedrive:\\\\", RegexOptions.IgnoreCase);
            }

            bool isCustomScheme = Regex.IsMatch(inputPath, @"^[a-zA-Z0-9]+:\\\\");

            if (isCustomScheme)
            {
                // Normalize slashes and remove trailing ones
                string cleaned = inputPath.Replace('/', '\\').TrimEnd('\\');

                // Check if it ends with a filename (e.g., has an extension after last slash)
                int lastSlash = cleaned.LastIndexOf('\\');
                if (lastSlash >= 0 && lastSlash < cleaned.Length - 1)
                {
                    string lastSegment = cleaned.Substring(lastSlash + 1);
                    if (lastSegment.Contains('.'))
                    {
                        // Looks like a file: remove it
                        cleaned = cleaned.Substring(0, lastSlash);
                    }
                }

                return cleaned;
            }
            else
            {
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
        }

        private Control CreateConfigEntryControl(RestrictableListEntry entry, string entryType, int index)
        {
            Panel panel = new Panel
            {
                Width = 350,
                Height = 25
            };

            Label label = new Label
            {
                Text = $"{index.ToString("d2")} {entry.name}{(entry.createSubfolderPerDocument? " 📁" : "")}",
                AutoSize = true,
                Location = new Point(0, 7)
            };

            Button editButton = new Button
            {
                Text = "✏️",
                Width = 25,
                Location = new Point(230, 2),
                Tag = (entry, entryType)
            };
            editButton.Click += EditButton_Click;

            Button deleteButton = new Button
            {
                Text = "✖️",
                Width = 25,
                Location = new Point(260, 2),
                Tag = (entry, entryType)
            };
            deleteButton.Click += DeleteButton_Click;

            panel.Controls.Add(label);
            panel.Controls.Add(editButton);
            panel.Controls.Add(deleteButton);

            return panel;
        }


        #endregion

        #region Events

        private void EditButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            (RestrictableListEntry entry, string type) = ((RestrictableListEntry, string))button.Tag;

            CurrentlyEditedEntry = entry.Clone();
            CurrentlyEditedEntryIsDepartment = type == "department";

            using (EditEntryForm editForm = new EditEntryForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    entry.name = CurrentlyEditedEntry.name;
                    entry.createSubfolderPerDocument = CurrentlyEditedEntry.createSubfolderPerDocument;
                    entry.requiredEntries = new Dictionary<string, bool>(CurrentlyEditedEntry.requiredEntries);
                    entry.allowedEntries = new Dictionary<string, bool>(CurrentlyEditedEntry.allowedEntries);

                    SetFieldsFromConfig();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            (RestrictableListEntry entry, string type) = ((RestrictableListEntry, string))button.Tag;

            DialogResult confirm = MessageBox.Show($"Weet u zeker dat u '{entry.name}' wilt verwijderen?", "Verwijderen bevestigen",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (type == "department")
                    _tempConfig.departments.Remove(entry);
                else if (type == "documentType")
                    _tempConfig.documentTypes.Remove(entry);

                SetFieldsFromConfig();
            }
        }


        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            _tempConfig.keepOriginalFile = saveOriginalFileCheckbox.Checked;

            _tempConfig.destinationPathRoot = _oldPath;

            string jsonConfig = Newtonsoft.Json.JsonConvert.SerializeObject(_tempConfig);

            string exeDirectory = AppContext.BaseDirectory;
            string configPath = Path.Combine(exeDirectory, "config.json");

            File.WriteAllText(configPath, jsonConfig);
            Close();
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

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            CurrentlyEditedEntry = new RestrictableListEntry();
            CurrentlyEditedEntryIsDepartment = true;

            using (var editForm = new EditEntryForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _tempConfig.departments.Add(CurrentlyEditedEntry);
                    SetFieldsFromConfig();
                }
            }
        }

        private void addDocumentTypeButton_Click(object sender, EventArgs e)
        {
            CurrentlyEditedEntry = new RestrictableListEntry();
            CurrentlyEditedEntryIsDepartment = false;

            using (var editForm = new EditEntryForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _tempConfig.documentTypes.Add(CurrentlyEditedEntry);
                    SetFieldsFromConfig();
                }
            }
        }

        #endregion
    }
}

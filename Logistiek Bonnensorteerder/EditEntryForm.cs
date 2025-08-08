using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Logistiek_Bonnensorteerder.Config;

namespace Logistiek_Bonnensorteerder
{
    public partial class EditEntryForm : Form
    {
        #region Static Members


        #endregion

        public EditEntryForm()
        {
            InitializeComponent();
            EnsureDictionarySizes();

            nameTextBox.Text = ConfigForm.CurrentlyEditedEntry.name;

            departmentAllowedCheck.Checked = ConfigForm.CurrentlyEditedEntry.allowedEntries["department"];
            orderNumberAllowedCheck.Checked = ConfigForm.CurrentlyEditedEntry.allowedEntries["orderNumber"];
            pickbonAllowedCheck.Checked = ConfigForm.CurrentlyEditedEntry.allowedEntries["pickbon"];
            customerNameAllowedCheck.Checked = ConfigForm.CurrentlyEditedEntry.allowedEntries["customerName"];
            transporterNameAllowedCheck.Checked = ConfigForm.CurrentlyEditedEntry.allowedEntries["transporterName"];

            departmentCheck.Checked = ConfigForm.CurrentlyEditedEntry.requiredEntries["department"];
            orderNumberCheck.Checked = ConfigForm.CurrentlyEditedEntry.requiredEntries["orderNumber"];
            pickbonCheck.Checked = ConfigForm.CurrentlyEditedEntry.requiredEntries["pickbon"];
            customerNameCheck.Checked = ConfigForm.CurrentlyEditedEntry.requiredEntries["customerName"];
            transporterNameCheck.Checked = ConfigForm.CurrentlyEditedEntry.requiredEntries["transporterName"];

            if(ConfigForm.CurrentlyEditedEntryIsDepartment)
            {
                departmentAllowedCheck.Checked = true;
                departmentAllowedCheck.Enabled = false;

                departmentCheck.Checked = true;
                departmentCheck.Enabled = false;
            }
        }

        #region Private Methods

        private void EnsureDictionarySizes()
        {
            ConfigForm.CurrentlyEditedEntry.FixDictionaries();
        }

        private void HandleAllowedCheck(CheckBox source, CheckBox target)
        {
            target.Enabled = source.Checked;

            if (!source.Checked)
                target.Checked = false;
        }

        private static string MakeFilenameSafe(string input)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(input.Where(c => !invalidChars.Contains(c)).ToArray());
        }

        #endregion

        #region Events

        private void departmentAllowedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            HandleAllowedCheck(departmentAllowedCheck, departmentCheck);
            ConfigForm.CurrentlyEditedEntry.allowedEntries["department"] = departmentAllowedCheck.Checked;
        }

        private void orderNumberAllowedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            HandleAllowedCheck(orderNumberAllowedCheck, orderNumberCheck);
            ConfigForm.CurrentlyEditedEntry.allowedEntries["orderNumber"] = orderNumberAllowedCheck.Checked;
        }

        private void pickbonAllowedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            HandleAllowedCheck(pickbonAllowedCheck, pickbonCheck);
            ConfigForm.CurrentlyEditedEntry.allowedEntries["pickbon"] = pickbonAllowedCheck.Checked;
        }

        private void customerNameAllowedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            HandleAllowedCheck(customerNameAllowedCheck, customerNameCheck);
            ConfigForm.CurrentlyEditedEntry.allowedEntries["customerName"] = customerNameAllowedCheck.Checked;
        }

        private void transporterNameAllowedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            HandleAllowedCheck(transporterNameAllowedCheck, transporterNameCheck);
            ConfigForm.CurrentlyEditedEntry.allowedEntries["transporterName"] = transporterNameAllowedCheck.Checked;
        }

        private void departmentCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.requiredEntries["department"] = departmentCheck.Checked;
        }

        private void orderNumberCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.requiredEntries["orderNumber"] = orderNumberCheck.Checked;
        }

        private void pickbonCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.requiredEntries["pickbon"] = pickbonCheck.Checked;
        }

        private void customerNameCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.requiredEntries["customerName"] = customerNameCheck.Checked;
        }

        private void transporterNameCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.requiredEntries["transporterName"] = transporterNameCheck.Checked;
        }

        private void nameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            ConfigForm.CurrentlyEditedEntry.name = nameTextBox.Text.Trim();
            nameTextBox.Text = MakeFilenameSafe(nameTextBox.Text);
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            if (ConfigForm.CurrentlyEditedEntry.name.Length == 0)
            {
                MessageBox.Show("Dit element heeft nog geen naam!", "Naam vereist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }
}

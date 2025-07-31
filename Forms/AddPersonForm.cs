using System;
using System.Windows.Forms;

namespace GiftOrganizer.Forms
{
    public partial class AddPersonForm : Form
    {
        public string PersonName => txtName.Text.Trim();
        public string Relationship => txtRelation.Text.Trim();
        public string Notes => txtNotes.Text.Trim();

        public AddPersonForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PersonName))
            {
                MessageBox.Show("Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer.Forms
{
    public partial class AddEventForm : Form
    {
        public int? SelectedPersonId {
            get {
                if (cmbPeople.SelectedItem is ComboBoxItem item)
                    return item.Value;
                // If you have 'All' or 'General' as string items, treat them as no person
                return null;
            }
        }
        public string EventName => txtName.Text.Trim();
        public DateTime EventDate => dtpDate.Value.Date;
        public bool Reminder => chkReminder.Checked;

        public AddEventForm()
        {
            InitializeComponent();
            LoadPeople();
        }

        private void LoadPeople()
        {
            cmbPeople.Items.Clear();
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, name FROM people", conn);
            using var reader = cmd.ExecuteReader();
            // Add a general option for no specific person
            cmbPeople.Items.Add(new ComboBoxItem { Text = "General", Value = 0 });
            while (reader.Read())
            {
                cmbPeople.Items.Add(new ComboBoxItem { Text = reader.GetString(1), Value = reader.GetInt32(0) });
            }
        }

        public void SetEvent(Event ev)
        {
            txtName.Text = ev.Name;
            dtpDate.Value = ev.EventDate;
            chkReminder.Checked = ev.Reminder;
            // If person_id is 0 or null, select nothing or 'General'
            if (ev.PersonId == 0)
            {
                cmbPeople.SelectedIndex = 0; // 'General' (index 0)
            }
            else
            {
                foreach (var obj in cmbPeople.Items)
                {
                    if (obj is ComboBoxItem item && item.Value == ev.PersonId)
                    {
                        cmbPeople.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EventName))
            {
                MessageBox.Show("Event name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

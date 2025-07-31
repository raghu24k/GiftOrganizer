using System;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;
using System.IO;

namespace GiftOrganizer.Forms
{
    public partial class AddGiftForm : Form
    {
        public int SelectedPersonId => ((ComboBoxItem)cmbPeople.SelectedItem)?.Value ?? 0;
        public int SelectedEventId => ((ComboBoxItem)cmbEvents.SelectedItem)?.Value ?? 0;
        public string GiftName => txtName.Text.Trim();
        public string GiftType => cmbType.SelectedItem?.ToString() ?? "";
        public decimal Cost => decimal.TryParse(txtCost.Text, out var c) ? c : 0;
        public string Notes => txtNotes.Text.Trim();
        public string ImagePath => txtImage.Text.Trim();

        public AddGiftForm()
        {
            InitializeComponent();
            LoadPeople();
            LoadEvents();
            if (cmbType.Items.Contains("Given"))
                cmbType.SelectedItem = "Given";
            // Always enable autocomplete for people/events
            cmbPeople.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPeople.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEvents.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEvents.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadPeople()
        {
            cmbPeople.Items.Clear();
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, name FROM people", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbPeople.Items.Add(new ComboBoxItem { Text = reader.GetString(1), Value = reader.GetInt32(0) });
            }
        }

        private void LoadEvents()
        {
            cmbEvents.Items.Clear();
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, name FROM events", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbEvents.Items.Add(new ComboBoxItem { Text = reader.GetString(1), Value = reader.GetInt32(0) });
            }
        }

        public void SetGift(Gift gift)
        {
            txtName.Text = gift.Name;
            cmbType.SelectedItem = gift.Type;
            txtCost.Text = gift.Cost.ToString();
            txtNotes.Text = gift.Notes;
            txtImage.Text = gift.ImagePath;
            foreach (ComboBoxItem item in cmbPeople.Items)
            {
                if (item.Value == gift.PersonId)
                {
                    cmbPeople.SelectedItem = item;
                    break;
                }
            }
            foreach (ComboBoxItem item in cmbEvents.Items)
            {
                if (item.Value == gift.EventId)
                {
                    cmbEvents.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = dlg.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedPersonId == 0 || SelectedEventId == 0 || string.IsNullOrWhiteSpace(GiftName) || string.IsNullOrWhiteSpace(GiftType))
            {
                MessageBox.Show("All fields except notes/image are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

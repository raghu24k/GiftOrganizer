using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer.Forms
{
    public partial class GiftsForm : Form
    {
        public GiftsForm()
        {
            InitializeComponent();
            LoadPeople();
            LoadEvents();
            if (cmbType.Items.Count > 0)
                cmbType.SelectedIndex = 0; // Set default to 'All'
            LoadGifts();
            var btnBack = new Button {
                Text = "Back",
                Width = 60,
                Height = 28,
                Top = 10,
                Left = this.Width - 90,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);
            cmbPeople.SelectedIndexChanged += (s, e) => LoadGifts();
            cmbEvents.SelectedIndexChanged += (s, e) => LoadGifts();
            cmbType.SelectedIndexChanged += (s, e) => LoadGifts();
            chkThisMonth.CheckedChanged += (s, e) => LoadGifts();
        }

        private void LoadPeople()
        {
            cmbPeople.Items.Clear();
            cmbPeople.Items.Add("All");
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, name FROM people", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbPeople.Items.Add(new ComboBoxItem { Text = reader.GetString(1), Value = reader.GetInt32(0) });
            }
            cmbPeople.SelectedIndex = 0;
        }

        private void LoadEvents()
        {
            cmbEvents.Items.Clear();
            cmbEvents.Items.Add("All");
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, name FROM events", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbEvents.Items.Add(new ComboBoxItem { Text = reader.GetString(1), Value = reader.GetInt32(0) });
            }
            cmbEvents.SelectedIndex = 0;
        }

        private void LoadGifts()
        {
            flowGifts.Controls.Clear();
            var gifts = new List<Gift>();
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                var sql = "SELECT g.id, g.person_id, g.event_id, g.name, g.type, g.cost, g.notes, g.image_path, e.event_date FROM gifts g LEFT JOIN events e ON g.event_id = e.id";
                var filters = new List<string>();
                if (cmbPeople.SelectedIndex > 0 && cmbPeople.SelectedItem is ComboBoxItem p)
                    filters.Add($"g.person_id = {p.Value}");
                if (cmbEvents.SelectedIndex > 0 && cmbEvents.SelectedItem is ComboBoxItem e)
                    filters.Add($"g.event_id = {e.Value}");
                if (cmbType.SelectedIndex > 0 && cmbType.SelectedItem is string t && t != "All")
                    filters.Add($"g.type = '{t}'");
                if (chkThisMonth.Checked)
                    filters.Add($"MONTH(e.event_date) = MONTH(CURDATE()) AND YEAR(e.event_date) = YEAR(CURDATE())");
                if (filters.Count > 0)
                    sql += " WHERE " + string.Join(" AND ", filters);
                var cmd = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gifts.Add(new Gift
                    {
                        Id = reader.GetInt32(0),
                        PersonId = reader.GetInt32(1),
                        EventId = reader.GetInt32(2),
                        Name = reader.GetString(3),
                        Type = reader.GetString(4),
                        Cost = reader.GetDecimal(5),
                        Notes = reader.GetString(6),
                        ImagePath = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                    });
                }
            }
            string search = txtSearch.Text.Trim().ToLower();
            foreach (var gift in gifts)
            {
                if (string.IsNullOrEmpty(search) || gift.Name.ToLower().Contains(search))
                {
                    var card = CreateGiftCard(gift);
                    flowGifts.Controls.Add(card);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSearch.TextChanged += (s, ev) => LoadGifts();
        }

        private Control CreateGiftCard(Gift gift)
        {
            var panel = new Panel
            {
                Width = 350,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Tag = gift
            };
            var lblName = new Label
            {
                Text = gift.Name,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true
            };
            var lblType = new Label
            {
                Text = $"Type: {gift.Type}",
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Top = 30
            };
            var lblCost = new Label
            {
                Text = $"Cost: Rs.{gift.Cost:N2}",
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Top = 55
            };
            var lblNotes = new Label
            {
                Text = gift.Notes,
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                AutoSize = true,
                Top = 80
            };
            PictureBox pic = null;
            if (!string.IsNullOrEmpty(gift.ImagePath) && File.Exists(gift.ImagePath))
            {
                pic = new PictureBox
                {
                    Image = Image.FromFile(gift.ImagePath),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 60,
                    Height = 60,
                    Left = 250,
                    Top = 10,
                    Cursor = Cursors.Hand
                };
                pic.Click += (s, e) =>
                {
                    var form = new Form
                    {
                        Text = gift.Name + " - Image Preview",
                        Size = new Size(500, 500),
                        StartPosition = FormStartPosition.CenterParent
                    };
                    var bigPic = new PictureBox
                    {
                        Image = Image.FromFile(gift.ImagePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Fill
                    };
                    form.Controls.Add(bigPic);
                    form.ShowDialog();
                };
                panel.Controls.Add(pic);
            }
            var btnEdit = new Button
            {
                Text = "Edit",
                Width = 60,
                Height = 28,
                Top = 100,
                Left = 10
            };
            btnEdit.Click += (s, e) => EditGift(gift);
            var btnDelete = new Button
            {
                Text = "Delete",
                Width = 60,
                Height = 28,
                Top = 100,
                Left = 80
            };
            btnDelete.Click += (s, e) => DeleteGift(gift);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblType);
            panel.Controls.Add(lblCost);
            panel.Controls.Add(lblNotes);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);
            lblType.Top = lblName.Bottom + 5;
            lblCost.Top = lblType.Bottom + 5;
            lblNotes.Top = lblCost.Bottom + 5;
            return panel;
        }

        private void btnAddGift_Click(object sender, EventArgs e)
        {
            var addForm = new AddGiftForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO gifts (person_id, event_id, name, type, cost, notes, image_path) VALUES (@pid, @eid, @name, @type, @cost, @notes, @img)", conn);
                    cmd.Parameters.AddWithValue("@pid", addForm.SelectedPersonId);
                    cmd.Parameters.AddWithValue("@eid", addForm.SelectedEventId);
                    cmd.Parameters.AddWithValue("@name", addForm.GiftName);
                    cmd.Parameters.AddWithValue("@type", addForm.GiftType);
                    cmd.Parameters.AddWithValue("@cost", addForm.Cost);
                    cmd.Parameters.AddWithValue("@notes", addForm.Notes);
                    cmd.Parameters.AddWithValue("@img", addForm.ImagePath);
                    cmd.ExecuteNonQuery();
                }
                LoadGifts();
            }
        }

        private void EditGift(Gift gift)
        {
            var editForm = new AddGiftForm();
            editForm.SetGift(gift);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE gifts SET person_id=@pid, event_id=@eid, name=@name, type=@type, cost=@cost, notes=@notes, image_path=@img WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@pid", editForm.SelectedPersonId);
                    cmd.Parameters.AddWithValue("@eid", editForm.SelectedEventId);
                    cmd.Parameters.AddWithValue("@name", editForm.GiftName);
                    cmd.Parameters.AddWithValue("@type", editForm.GiftType);
                    cmd.Parameters.AddWithValue("@cost", editForm.Cost);
                    cmd.Parameters.AddWithValue("@notes", editForm.Notes);
                    cmd.Parameters.AddWithValue("@img", editForm.ImagePath);
                    cmd.Parameters.AddWithValue("@id", gift.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadGifts();
            }
        }

        private void DeleteGift(Gift gift)
        {
            if (MessageBox.Show($"Delete gift '{gift.Name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM gifts WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", gift.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadGifts();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer.Forms
{
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
            LoadPeople();
            LoadEvents();
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
            cmbPeople.SelectedIndexChanged += (s, e) => LoadEvents();
        }

        private void LoadPeople()
        {
            cmbPeople.Items.Clear();
            cmbPeople.Items.Add("All");
            cmbPeople.Items.Add("General"); // For events with no person
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
            flowEvents.Controls.Clear();
            var events = new List<Event>();
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                string sql = "SELECT id, person_id, name, event_date, reminder FROM events";
                if (cmbPeople.SelectedIndex == 1) // General
                    sql += " WHERE person_id IS NULL";
                else if (cmbPeople.SelectedIndex > 1 && cmbPeople.SelectedItem is ComboBoxItem p)
                    sql += $" WHERE person_id = {p.Value}";
                sql += " ORDER BY event_date ASC";
                var cmd = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    events.Add(new Event
                    {
                        Id = reader.GetInt32(0),
                        PersonId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                        Name = reader.GetString(2),
                        EventDate = reader.GetDateTime(3),
                        Reminder = reader.GetBoolean(4)
                    });
                }
            }
            string search = txtSearch.Text.Trim().ToLower();
            foreach (var ev in events)
            {
                if (string.IsNullOrEmpty(search) || ev.Name.ToLower().Contains(search))
                {
                    var card = CreateEventCard(ev);
                    flowEvents.Controls.Add(card);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSearch.TextChanged += (s, ev) => LoadEvents();
        }

        private Control CreateEventCard(Event ev)
        {
            var panel = new Panel
            {
                Width = 350,
                Height = 110,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Tag = ev
            };
            var lblName = new Label
            {
                Text = ev.Name,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true
            };
            var lblDate = new Label
            {
                Text = $"Date: {ev.EventDate:yyyy-MM-dd}",
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Top = 30
            };
            var lblReminder = new Label
            {
                Text = ev.Reminder ? "Reminder set" : string.Empty,
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                AutoSize = true,
                Top = 55
            };
            var btnEdit = new Button
            {
                Text = "Edit",
                Width = 60,
                Height = 28,
                Top = 70,
                Left = 10
            };
            btnEdit.Click += (s, e) => EditEvent(ev);
            var btnDelete = new Button
            {
                Text = "Delete",
                Width = 60,
                Height = 28,
                Top = 70,
                Left = 80
            };
            btnDelete.Click += (s, e) => DeleteEvent(ev);
            var btnAddGift = new Button
            {
                Text = "Add Gift",
                Width = 80,
                Height = 28,
                Top = 70,
                Left = 150
            };
            btnAddGift.Click += (s, e) => {
                var addGiftForm = new AddGiftForm();
                // Set event in ComboBox
                foreach (var obj in addGiftForm.Controls)
                {
                    if (obj is ComboBox cmb && cmb.Name == "cmbEvents")
                    {
                        foreach (ComboBoxItem item in cmb.Items)
                        {
                            if (item.Value == ev.Id)
                            {
                                cmb.SelectedItem = item;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (addGiftForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Save to DB
                    using (var conn = new MySqlConnection(GiftOrganizer.Database.DbInitializer.GetAppConnectionString()))
                    {
                        conn.Open();
                        var cmd = new MySqlCommand("INSERT INTO gifts (person_id, event_id, name, type, cost, notes, image_path) VALUES (@pid, @eid, @name, @type, @cost, @notes, @img)", conn);
                        cmd.Parameters.AddWithValue("@pid", addGiftForm.SelectedPersonId);
                        cmd.Parameters.AddWithValue("@eid", addGiftForm.SelectedEventId);
                        cmd.Parameters.AddWithValue("@name", addGiftForm.GiftName);
                        cmd.Parameters.AddWithValue("@type", addGiftForm.GiftType);
                        cmd.Parameters.AddWithValue("@cost", addGiftForm.Cost);
                        cmd.Parameters.AddWithValue("@notes", addGiftForm.Notes);
                        cmd.Parameters.AddWithValue("@img", addGiftForm.ImagePath);
                        cmd.ExecuteNonQuery();
                    }
                }
            };
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblReminder);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);
            panel.Controls.Add(btnAddGift);
            lblDate.Top = lblName.Bottom + 5;
            lblReminder.Top = lblDate.Bottom + 5;
            return panel;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            var addForm = new AddEventForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO events (person_id, name, event_date, reminder) VALUES (@pid, @name, @date, @rem)", conn);
                    if (addForm.SelectedPersonId.HasValue)
                        cmd.Parameters.AddWithValue("@pid", addForm.SelectedPersonId.Value);
                    else
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                    cmd.Parameters.AddWithValue("@name", addForm.EventName);
                    cmd.Parameters.AddWithValue("@date", addForm.EventDate);
                    cmd.Parameters.AddWithValue("@rem", addForm.Reminder);
                    cmd.ExecuteNonQuery();
                }
                LoadEvents();
            }
        }

        private void EditEvent(Event ev)
        {
            var editForm = new AddEventForm();
            editForm.SetEvent(ev);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE events SET person_id=@pid, name=@name, event_date=@date, reminder=@rem WHERE id=@id", conn);
                    if (editForm.SelectedPersonId.HasValue)
                        cmd.Parameters.AddWithValue("@pid", editForm.SelectedPersonId.Value);
                    else
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                    cmd.Parameters.AddWithValue("@name", editForm.EventName);
                    cmd.Parameters.AddWithValue("@date", editForm.EventDate);
                    cmd.Parameters.AddWithValue("@rem", editForm.Reminder);
                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadEvents();
            }
        }

        private void DeleteEvent(Event ev)
        {
            if (MessageBox.Show($"Delete event '{ev.Name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM events WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadEvents();
            }
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }
        public override string ToString() => Text;
    }
}

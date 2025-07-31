using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer.Forms
{
    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
            LoadPeople();
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
        }

        private void LoadPeople()
        {
            flowPeople.Controls.Clear();
            var people = new List<Person>();
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, name, relationship, notes FROM people", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Relationship = reader.GetString(2),
                        Notes = reader.GetString(3)
                    });
                }
            }
            string search = txtSearch.Text.Trim().ToLower();
            foreach (var person in people)
            {
                if (string.IsNullOrEmpty(search) || person.Name.ToLower().Contains(search))
                {
                    var card = CreatePersonCard(person);
                    flowPeople.Controls.Add(card);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSearch.TextChanged += (s, ev) => LoadPeople();
        }

        private Control CreatePersonCard(Person person)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Tag = person
            };
            var lblName = new Label
            {
                Text = person.Name,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true
            };
            var lblRelation = new Label
            {
                Text = $"Relation: {person.Relationship}",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                AutoSize = true,
                Top = 30
            };
            var lblNotes = new Label
            {
                Text = person.Notes,
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Top = 55
            };
            var btnEdit = new Button
            {
                Text = "Edit",
                Width = 60,
                Height = 28,
                Top = 90,
                Left = 10
            };
            btnEdit.Click += (s, e) => EditPerson(person);
            var btnDelete = new Button
            {
                Text = "Delete",
                Width = 60,
                Height = 28,
                Top = 90,
                Left = 80
            };
            btnDelete.Click += (s, e) => DeletePerson(person);
            var btnAddGift = new Button
            {
                Text = "Add Gift",
                Width = 80,
                Height = 28,
                Top = 90,
                Left = 150
            };
            btnAddGift.Click += (s, e) => {
                var addGiftForm = new AddGiftForm();
                // Set person in ComboBox
                foreach (var obj in addGiftForm.Controls)
                {
                    if (obj is ComboBox cmb && cmb.Name == "cmbPeople")
                    {
                        foreach (ComboBoxItem item in cmb.Items)
                        {
                            if (item.Value == person.Id)
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
            panel.Controls.Add(lblRelation);
            panel.Controls.Add(lblNotes);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);
            panel.Controls.Add(btnAddGift);
            lblRelation.Top = lblName.Bottom + 5;
            lblNotes.Top = lblRelation.Bottom + 5;
            return panel;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var addForm = new AddPersonForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Save to DB
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO people (name, relationship, notes) VALUES (@name, @rel, @notes)", conn);
                    cmd.Parameters.AddWithValue("@name", addForm.PersonName);
                    cmd.Parameters.AddWithValue("@rel", addForm.Relationship);
                    cmd.Parameters.AddWithValue("@notes", addForm.Notes);
                    cmd.ExecuteNonQuery();
                }
                LoadPeople();
            }
        }

        private void EditPerson(Person person)
        {
            var editForm = new AddPersonForm();
            // Set initial values
            editForm.Controls["txtName"].Text = person.Name;
            editForm.Controls["txtRelation"].Text = person.Relationship;
            editForm.Controls["txtNotes"].Text = person.Notes;
            editForm.lblTitle.Text = "Edit Person";
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE people SET name=@name, relationship=@rel, notes=@notes WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@name", editForm.PersonName);
                    cmd.Parameters.AddWithValue("@rel", editForm.Relationship);
                    cmd.Parameters.AddWithValue("@notes", editForm.Notes);
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadPeople();
            }
        }

        private void DeletePerson(Person person)
        {
            if (MessageBox.Show($"Delete {person.Name}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM people WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.ExecuteNonQuery();
                }
                LoadPeople();
            }
        }
    }
}

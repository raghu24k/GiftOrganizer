using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GiftOrganizer.Models;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.peopleMenuItem.Click += (s, e) => { new PeopleForm().ShowDialog(this); LoadDashboard(); };
            this.eventsMenuItem.Click += (s, e) => { new EventsForm().ShowDialog(this); LoadDashboard(); };
            this.giftsMenuItem.Click += (s, e) => { new GiftsForm().ShowDialog(this); LoadDashboard(); };
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            LoadUpcomingEvents();
            LoadTotalSpent();
            LoadPlannedGifts();
        }

        private void LoadUpcomingEvents()
        {
            flowEvents.Controls.Clear();
            var events = new List<Event>();
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, person_id, name, event_date, reminder FROM events WHERE event_date >= CURDATE() ORDER BY event_date ASC LIMIT 5", conn);
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
            foreach (var ev in events)
            {
                var card = new Panel
                {
                    Width = 250,
                    Height = 80,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Padding = new Padding(10)
                };
                var lblName = new Label
                {
                    Text = ev.Name,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    AutoSize = true
                };
                var lblDate = new Label
                {
                    Text = $"Date: {ev.EventDate:yyyy-MM-dd}",
                    Font = new Font("Segoe UI", 9F),
                    AutoSize = true,
                    Top = 30
                };
                card.Controls.Add(lblName);
                card.Controls.Add(lblDate);
                lblDate.Top = lblName.Bottom + 5;
                flowEvents.Controls.Add(card);
            }
        }

        private void LoadTotalSpent()
        {
            decimal total = 0;
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT SUM(g.cost) FROM gifts g LEFT JOIN events e ON g.event_id = e.id WHERE g.type='Given' AND MONTH(e.event_date)=MONTH(CURDATE()) AND YEAR(e.event_date)=YEAR(CURDATE())", conn);
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    total = Convert.ToDecimal(result);
            }
            lblTotalSpent.Text = $"Total Spent This Month: Rs.{total:N2}";
        }

        private void LoadPlannedGifts()
        {
            flowPlannedGifts.Controls.Clear();
            var gifts = new List<Gift>();
            using (var conn = new MySqlConnection(DbInitializer.GetAppConnectionString()))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, person_id, event_id, name, type, cost, notes, image_path FROM gifts WHERE type='Planned' ORDER BY cost DESC LIMIT 5", conn);
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
            foreach (var gift in gifts)
            {
                var card = new Panel
                {
                    Width = 250,
                    Height = 80,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Padding = new Padding(10)
                };
                var lblName = new Label
                {
                    Text = gift.Name,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    AutoSize = true
                };
                var lblCost = new Label
                {
                    Text = $"Cost: Rs.{gift.Cost:N2}",
                    Font = new Font("Segoe UI", 9F),
                    AutoSize = true,
                    Top = 30
                };
                card.Controls.Add(lblName);
                card.Controls.Add(lblCost);
                lblCost.Top = lblName.Bottom + 5;
                flowPlannedGifts.Controls.Add(card);
            }
        }
    }
}

using System;
using System.Windows.Forms;
using GiftOrganizer.Database;
using MySql.Data.MySqlClient;

namespace GiftOrganizer
{
    public static class ReminderService
    {
        public static void ShowReminders()
        {
            using var conn = new MySqlConnection(DbInitializer.GetAppConnectionString());
            conn.Open();
            var cmd = new MySqlCommand("SELECT name, event_date FROM events WHERE reminder=1 AND event_date=CURDATE()", conn);
            using var reader = cmd.ExecuteReader();
            string reminders = "";
            while (reader.Read())
            {
                reminders += $"{reader.GetString(0)} ({reader.GetDateTime(1):yyyy-MM-dd})\n";
            }
            if (!string.IsNullOrEmpty(reminders))
            {
                MessageBox.Show($"Today's Events with Reminders:\n\n{reminders}", "Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

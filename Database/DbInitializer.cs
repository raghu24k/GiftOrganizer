using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GiftOrganizer.Database
{
    public class DbInitializer
    {
        private const string rootConnStr = "server=localhost;user=root;password=;";

        public static void Initialize()
        {
            try
            {
                using var conn = new MySqlConnection(rootConnStr);
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    CREATE DATABASE IF NOT EXISTS gift_organizer;
                    USE gift_organizer;

                    CREATE TABLE IF NOT EXISTS people (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        name VARCHAR(100),
                        relationship VARCHAR(100),
                        notes TEXT
                    );

                    CREATE TABLE IF NOT EXISTS events (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        person_id INT NULL,
                        name VARCHAR(100),
                        event_date DATE,
                        reminder BOOLEAN,
                        FOREIGN KEY (person_id) REFERENCES people(id)
                    );

                    CREATE TABLE IF NOT EXISTS gifts (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        person_id INT,
                        event_id INT,
                        name VARCHAR(100),
                        type ENUM('Given', 'Planned', 'Received'),
                        cost DECIMAL(10, 2),
                        notes TEXT,
                        image_path VARCHAR(255),
                        FOREIGN KEY (person_id) REFERENCES people(id),
                        FOREIGN KEY (event_id) REFERENCES events(id)
                    );
                ";

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database setup failed:\n" + ex.Message);
            }
        }

        public static string GetAppConnectionString()
        {
            return "server=localhost;user=root;password=;database=gift_organizer;";
        }
    }
}

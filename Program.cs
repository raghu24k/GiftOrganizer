using System;
using System.Windows.Forms;
using GiftOrganizer.Database;
using GiftOrganizer.Forms;

namespace GiftOrganizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 🔁 Initialize DB on startup
            DbInitializer.Initialize();
            ReminderService.ShowReminders();

            Application.Run(new DashboardForm());
            // Application.Run(new GiftsForm());
        }
    }
}

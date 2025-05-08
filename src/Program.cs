#nullable enable
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MAME_Shrink.Forms;
using MAME_Shrink.Settings;
using NLog;

namespace MAME_Shrink;

internal static class Program
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        try
        {
            _logger.Info("Application started");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");    //  TEST

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var userPreferences = UserPreferencesManager.Get();
            if (userPreferences is null)
            {
                using var form = new OptionsForm();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    // Terminare il programma se la finestra viene chiusa senza conferma
                    Environment.Exit(0);
                }
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Unhandled exception occurred");
        }
        finally
        {
            _logger.Info("Application ended");
            LogManager.Shutdown(); // Optional but recommended
        }
    }
}

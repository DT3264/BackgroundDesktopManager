using System;
using System.Drawing;
using System.Windows.Forms;
namespace BackgroundDesktopManager
{
    internal static class Program
    {
        public static Utils utils;
        public static Timer timer;
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            utils = new Utils(new Settings(args));
            timer = new Timer();
            timer.Tick += (object sender, EventArgs e) => utils.setNextImage();
            timer.Interval = utils.settings.interval;
            timer.Start();
            using (NotifyIcon notifyIcon = new NotifyIcon())
            {
                notifyIcon.Text = "Background Manager";
                notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                MenuItem[] array = new MenuItem[3];
                array[0] = new MenuItem("Previous", delegate (object s, EventArgs e)
                {
                    utils.setPreviousImage();
                });
                array[1] = new MenuItem("Next", delegate (object s, EventArgs e)
                {
                    utils.setNextImage();
                });
                array[2] = new MenuItem("Exit", delegate (object s, EventArgs e)
                {
                    Application.Exit();
                });
                notifyIcon.ContextMenu = new ContextMenu(array);
                notifyIcon.Visible = true;
                Application.Run();
                notifyIcon.Visible = false;
            }
        }

    }
}

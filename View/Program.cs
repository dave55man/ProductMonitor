using Bootstrap;
using Bootstrap.StructureMap;
using System;
using System.Windows.Forms;
using Trek.ProductMonitor.View.View;

namespace Trek.ProductMonitor.View
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Setup IOC via Bootstrapper and StructureMap
            Bootstrapper.With.StructureMap().Start();

            //Start the Product Monitor!
            Application.Run(new View.ProductMonitor());
        }

        public static void Exit()
        {
            Application.Exit();
        }
    }
}

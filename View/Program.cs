using Bootstrap;
using Bootstrap.StructureMap;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Application.Run(new Form1());

            Bootstrapper.With.StructureMap().Start();

            //TODO: Hookup the presenter here!
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Windows.Forms;
using GAsty.Forms;

namespace GAsty.Config
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OasisForms.Initialise();
            Application.Run(OasisForms.DockMain);
        }
    }
}

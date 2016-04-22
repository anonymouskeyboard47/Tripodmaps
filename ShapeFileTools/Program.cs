using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tripodmaps
{
     

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //MainForm f = new MainForm(Application.StartupPath + "\\Data\\" + "Main.trip");
            //Application.Run(f);            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TripodMainForm(Application.StartupPath + "\\Data\\" + "Main.trip"));


        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;

namespace FaceVerification
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
           // Application.Run(new Comparer());
            Application.Run(new Form1());
            //ConexionBD bd = new ConexionBD();
            //bd.ConectTest();
            //Console.Read();
        }
    }
}
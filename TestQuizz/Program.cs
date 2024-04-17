using doan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FVuotChuongNgaiVat());
            //  Application.Run(new Fdapde());
            //Application.Run(new FBatBong());
            // Application.Run(new FChonCapTuongUng());
            // Application.Run(new FTruyTimKhoBau());
            Application.Run(new Form4());
        }
    }
}

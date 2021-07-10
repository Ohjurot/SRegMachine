using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRegMachine
{
    static class SRegMachine
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            // Get load file
            string loadFile = null;
            if (args.Length == 1) {
                loadFile = args[0];
            }

            // Call app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_SRegMachine(loadFile));
        }
    }
}

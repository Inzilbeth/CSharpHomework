using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Forms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1 && int.TryParse(args[0], out int size))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PairForm(size));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidateOpenDemo
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
            Application.Run(new Form1());
        }
    }

    class ValidationRule
    {
        public string TradeId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorRegEx { get; set; }
        public ValidationScope Scope { get; set; }
        public bool AutoValidate { get; set; }
    }

    enum ValidationScope
    {
        Official=0,
        UnOfficial=1,
        Both=2
    }
}

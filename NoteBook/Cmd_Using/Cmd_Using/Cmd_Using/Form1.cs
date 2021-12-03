using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmd_Using
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand();

        }
        static void ExecuteCommand()
        {
            string bat = @"D:\User\Downloads\새 폴더\HansotPy\temp.bat";
            var psi = new ProcessStartInfo();
            psi.CreateNoWindow = true; //This hides the dos-style black window that the command prompt usually shows
            psi.FileName = @"cmd.exe";
            psi.Verb = "runas"; //This is what actually runs the command as administrator
            psi.Arguments = "/C " + bat;

            try
            {
                var process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception)
            {
                //If you are here the user clicked decline to grant admin privileges (or he's not administrator)
                Console.WriteLine("exception ocurred.");
            }

        }
    }
}

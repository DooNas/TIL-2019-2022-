using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeFormDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Controll to TopPanel
            panel1.MouseUp += panelTop_MouseUp;
            panel1.MouseDown += panelTop_MouseDown;
            panel1.MouseMove += panelTop_MouseMove;
            BtnClose.Click += Btn_Close;
            BtnMinmon.Click += Btn_Minmon;
        }
        //////////////Controll to TopPanel/////////////////
        bool isMove;
        int MouseX, MouseY;
        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            MouseX = e.X;
            MouseY = e.Y;
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
            }
        }
        private void Btn_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddaf(object sender, EventArgs e)
        {

        }

        private void Btn_Minmon(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //////////////////////////////////////////////////


    }
}

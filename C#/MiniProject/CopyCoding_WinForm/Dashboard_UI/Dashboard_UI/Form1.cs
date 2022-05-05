using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void EndResponsive()    //창의 사이즈 변화에 따른 크기 조절
        {
            if(this.Width < 450)    //만약 form1의 가로 길이가 450 이하라면 
            {
                tableLayoutPanel2.ColumnStyles[1].Width = 350;
            }
            else if(this.Width < 1010)  //만약 from1의 가로 길이가 1010 이상이라면
            {
                tableLayoutPanel2.ColumnStyles[1].Width = tableLayoutPanel2.Width - (chart1.Width + chart1.Margin.Right);
            }
            else
            {
                tableLayoutPanel2.ColumnStyles[1].Width = tableLayoutPanel2.Width - (chart1.Width + chart2.Width + chart1.Margin.Right + chart2.Margin.Right);
            }

            if(this.Height < 775)
            {
                panel8.Height = 290;
            }else
            {
                panel8.Height = panel7.Height;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            EndResponsive();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized) { EndResponsive();}
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

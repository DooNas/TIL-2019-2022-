using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xml_parsing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bt_Open.Click += Bt_Open_Click;
        }

        private void Bt_Open_Click(object sender, EventArgs e)
        {
            string url = @"D:\Project_ForCoding\TIL\Mini_Project\OpenAPI\xml_parsing_Test\xml_parsing_Test\C19.xml";

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(url);

                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드

                foreach (XmlNode xn in xnList)
                {
                    string part1 = xn["createDt"].InnerText; //작성 날짜 불러오기
                    string part2 = xn["decideCnt"].InnerText; //확진자 불러오기

                    richTextBox1.AppendText(part1 + " | " + part2);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\r\n" + ex);
            }

        }

    }
}

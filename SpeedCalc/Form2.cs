using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedCalc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.BackColor = ColorTranslator.FromHtml("#230500");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" || textBox1.Text != " ")
            {
                char[] A = textBox1.Text.ToCharArray();
                bool cycle = false;
                for (int i = 0; i<A.Length; i++)
                {
                    if (A[i]==',')
                    {
                        MessageBox.Show("Error! Please Use dot separator [\".\"]");
                        cycle = true;
                        break;
                    }
                }
                if(cycle == false)
                {
                    if (comboBox1.Text == "MB/s")
                    {
                        bool res = double.TryParse(textBox1.Text, out double number);
                        double FinalRes = 0;
                        if (res == true)
                        {
                            textBox2.Visible = true;
                            label3.Visible = true;
                            FinalRes = number * 8;
                            textBox2.Text = Convert.ToString(FinalRes) + " MBits/s";
                        }
                        else
                        {
                            MessageBox.Show("Error! Please write a number!");
                        }
                    }
                    if (comboBox1.Text == "KB/s")
                    {
                        bool res = double.TryParse(textBox1.Text, out double number);
                        double FinalRes = 0;
                        if (res == true)
                        {
                            textBox2.Visible = true;
                            label3.Visible = true;
                            FinalRes = number * 8;
                            textBox2.Text = Convert.ToString(FinalRes) + " KBits/s";
                        }
                        else
                        {
                            MessageBox.Show("Error! Please write a number!");
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
        }
    }
}

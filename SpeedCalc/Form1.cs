using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace SpeedCalc
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
            label1.BackColor = ColorTranslator.FromHtml("#340b00");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#230500");
            button3.BringToFront();
            panel2.BackColor = ColorTranslator.FromHtml("#230500");
            textBox3.BackColor = label1.BackColor = ColorTranslator.FromHtml("#230500");
            button4.BackColor = ColorTranslator.FromHtml("#230500");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Point lastpoint;     
        private void pictureBox2_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void pictureBox2_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.FlatAppearance.BorderSize = 3;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.FlatAppearance.BorderSize = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label1.BackColor = ColorTranslator.FromHtml("#340b00");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#340b00");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string pattern = @"\s+";
            string target = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(textBox1.Text, target);
            string res2 = regex.Replace(textBox2.Text, target);
            if (result =="")
            {
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
            }
            if(res2=="")
            {
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox4.Visible = false;
            }
            if(comboBox1.Text==""||comboBox2.Text=="")
            {
                MessageBox.Show("Choose the options!");
            }
            if(result !="" || res2 !="")
            {
                if (!double.TryParse(textBox1.Text, out double num) || !double.TryParse(textBox2.Text, out double num1))
                {
                    MessageBox.Show("You entered invaled values! Please enter the numbers!");
                }
                else
                {
                    if (res2 != "" && result != "")
                    {
                        panel3.Visible = true;
                        Logic proccess = new Logic(result, comboBox1.Text, res2, comboBox2.Text);
                        await Task.Run(() =>
                        {
                            for (int i = 1; i <= 100; i++)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    UpdateProgBar(i);
                                }));
                                Thread.Sleep(1);
                            }
                        });
                        double Size = 0, Speed = 0;
                        string Parametr = proccess.GetSize();
                        string Parametr2 = proccess.GetSpeed();
                        if (Parametr != "no_data")
                        {
                            bool res = double.TryParse(Parametr, out double number);
                            if (res == true)
                            {
                                Size = number;
                            }
                            else
                            {
                                MessageBox.Show("You entered invaled values! Please enter the numbers!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Choose the size of your file!");
                        }
                        if (Parametr2 != "no_data")
                        {
                            bool res = double.TryParse(Parametr2, out double number);
                            if (res == true)
                            {
                                Speed = number / 8;
                            }
                            else
                            {
                                MessageBox.Show("You entered invaled values! Please enter the numbers!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Choose the speed of your Internet!");
                        }
                        panel3.Visible = false;
                        textBox3.Visible = true;
                        if (Speed != 0)
                        {
                            double S = Math.Round((Size / Speed));
                            var ts = TimeSpan.FromSeconds(S);
                            textBox3.Text = $"Day: {Convert.ToString(ts.Days)}. " + $"Hours: {Convert.ToString(ts.Hours)}. " + $"Minutes: {Convert.ToString(ts.Minutes)}.";
                        }
                    }
                }

            }
        }
            
        private void UpdateProgBar(int i)
        {
            if (i == progressBar1.Maximum)
            {
                progressBar1.Maximum = i + 1;
                progressBar1.Value = i + 1;
                progressBar1.Maximum = i;
            }
            else
            {
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = i;
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.FlatAppearance.BorderSize = 3;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.FlatAppearance.BorderSize = 1;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}

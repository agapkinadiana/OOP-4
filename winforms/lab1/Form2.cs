using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form2 : Form
    {
        List<int> list = new List<int>();
        readonly Random rand = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count;
                if (textBox1.Text.Equals("") || (count = Convert.ToInt32(textBox1.Text)) == 0)
                {
                    MessageBox.Show("no elements");
                    list = null;
                }
                else
                {
                    textBox2.Clear();
                    int size = Convert.ToInt32(textBox1.Text);
                    int[] mas = new int[size];
                    for (int b = 0; b < size; b++)
                        mas[b] = rand.Next(20);
                    foreach (var t in mas)
                        list.Add(t);
                    foreach (var num in list)
                        textBox2.Text += "num: " + Convert.ToString(num) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Clear();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("no elements");
                }
                else
                {
                    list.Sort();
                    foreach (var num in list)
                        textBox3.Text += "num: " + Convert.ToString(num) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Clear();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("no elements");
                }
                else
                {
                    list.Sort();
                    list.Reverse();
                    foreach (var num in list)
                        textBox3.Text += "num: " + Convert.ToString(num) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("no elements");
                }
                else
                {
                    textBox4.Text = Convert.ToString(list.Max());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("no elements");
                }
                else
                {
                    textBox4.Text = Convert.ToString(list.Min());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("no elements");
                }
                else
                {
                    textBox4.Text = Convert.ToString(list.Sum());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool reset = true;
        private bool masterreset = true;
        private int optype = -1;
        private double oper1 = 0;
        private double oper2 = 0;
        private int opcount = 0;

        private void AddString(string s)
        {
            if (reset == true)
            {
                reset = false;
                textBox1.Text = "";
            }
            if (masterreset == true)
            {
                masterreset = false;
                textBoxStack.Text = "";
            }
            textBox1.Text += s;
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            AddString("0");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddString("1");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AddString("2");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AddString("3");

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AddString("4");

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            AddString("5");
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            AddString("6");
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            AddString("7");
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            AddString("8");
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            AddString("9");
        }

        private void buttonComp_Click(object sender, RoutedEventArgs e)
        {
            string s = textBox1.Text;
            oper1 = Convert.ToDouble(textBox1.Text);
            oper1 = -oper1;
            textBox1.Text = oper1.ToString();
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            string s = textBox1.Text;

            bool bdotfound = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.')
                    bdotfound = true;
            }

            if( bdotfound == false)
                AddString(".");
        }

        private void buttonsl_Click(object sender, RoutedEventArgs e)
        {
            if (opcount == 0)
            {
                opcount = 1;
                oper1 = Convert.ToDouble(textBox1.Text);
                textBoxStack.Text += oper1.ToString();
                textBoxStack.Text += "/";
                textBox1.Text = "";
            }
            else if (opcount == 1)
            {
                opcount = 1;
                textBoxStack.Text += Convert.ToDouble(textBox1.Text).ToString();
                textBoxStack.Text += "/";
                if (optype == 1)
                    oper1 = oper1 + Convert.ToDouble(textBox1.Text);
                else if (optype == 2)
                    oper1 = oper1 - Convert.ToDouble(textBox1.Text);
                else if (optype == 3)
                    oper1 = oper1 * Convert.ToDouble(textBox1.Text);
                else if (optype == 4)
                    oper1 = oper1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
            }
            optype = 4;
        }

        private void buttonmul_Click(object sender, RoutedEventArgs e)
        {
            if (opcount == 0)
            {
                opcount = 1;
                oper1 = Convert.ToDouble(textBox1.Text);
                textBoxStack.Text += oper1.ToString();
                textBoxStack.Text += "*";
                textBox1.Text = "";
            }
            else if (opcount == 1)
            {
                opcount = 1;
                textBoxStack.Text += Convert.ToDouble(textBox1.Text).ToString();
                textBoxStack.Text += "*";
                if (optype == 1)
                    oper1 = oper1 + Convert.ToDouble(textBox1.Text);
                else if (optype == 2)
                    oper1 = oper1 - Convert.ToDouble(textBox1.Text);
                else if (optype == 3)
                    oper1 = oper1 * Convert.ToDouble(textBox1.Text);
                else if (optype == 4)
                    oper1 = oper1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
            }
            optype = 3;
        }

        private void buttonsub_Click(object sender, RoutedEventArgs e)
        {
            if (opcount == 0)
            {
                opcount = 1;
                oper1 = Convert.ToDouble(textBox1.Text);
                textBoxStack.Text += oper1.ToString();
                textBoxStack.Text += "-";
                textBox1.Text = "";
            }
            else if (opcount == 1)
            {
                opcount = 1;
                textBoxStack.Text += Convert.ToDouble(textBox1.Text).ToString();
                textBoxStack.Text += "-";
                if (optype == 1)
                    oper1 = oper1 + Convert.ToDouble(textBox1.Text);
                else if (optype == 2)
                    oper1 = oper1 - Convert.ToDouble(textBox1.Text);
                else if (optype == 3)
                    oper1 = oper1 * Convert.ToDouble(textBox1.Text);
                else if (optype == 4)
                    oper1 = oper1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = oper1.ToString();
                reset = true;
            }
            optype = 2;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (opcount == 0)
            {
                opcount = 1;
                oper1 = Convert.ToDouble(textBox1.Text);
                textBoxStack.Text += oper1.ToString();
                textBoxStack.Text += "+";
                textBox1.Text = "";
            }
            else if (opcount == 1)
            {
                opcount = 1;
                textBoxStack.Text += Convert.ToDouble(textBox1.Text).ToString();
                textBoxStack.Text += "+";

                if (optype == 1)
                    oper1 = oper1 + Convert.ToDouble(textBox1.Text);
                else if (optype == 2)
                    oper1 = oper1 - Convert.ToDouble(textBox1.Text);
                else if (optype == 3)
                    oper1 = oper1 * Convert.ToDouble(textBox1.Text);
                else if (optype == 4)
                    oper1 = oper1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = oper1.ToString();
                reset = true;
            }
            optype = 1;
        }

        private void buttonEQ_Click(object sender, RoutedEventArgs e)
        {
            if (opcount == 0)
            {
                opcount = 1;
                oper1 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = oper1.ToString();
                reset = true;
            }
            else if (opcount == 1)
            {
                opcount = 0;
                textBoxStack.Text += Convert.ToDouble(textBox1.Text).ToString();

                if(optype == 1)
                    oper1 = oper1 + Convert.ToDouble(textBox1.Text);
                else if (optype == 2)
                    oper1 = oper1 - Convert.ToDouble(textBox1.Text);
                else if (optype == 3)
                    oper1 = oper1 * Convert.ToDouble(textBox1.Text);
                else if (optype == 4)
                    oper1 = oper1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = oper1.ToString();
                reset = true;
                masterreset = true;
            }
        }

        private void buttonper_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "http://www.softwareandfinance.com";
            p.Start();
        }
    }
}

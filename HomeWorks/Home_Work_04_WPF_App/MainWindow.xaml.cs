using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home_Work_04_WPF_App
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

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid1 = double.TryParse(textBox1.Text,out double number1);
            bool isvalid2 = double.TryParse(textBox2.Text, out double number2);
            if (isvalid1)
            {
                if (isvalid2)
                {
                    double result = number1 + number2;
                    textBoxResult.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("You entered wrong input!");
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("You entered wrong input!");
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid1 = double.TryParse(textBox1.Text, out double number1);
            bool isvalid2 = double.TryParse(textBox2.Text, out double number2);
            if (isvalid1)
            {
                if (isvalid2)
                {
                    double result = number1 - number2;
                    textBoxResult.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("You entered wrong input!");
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("You entered wrong input!");
            }
        }

        private void Multiple_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid1 = double.TryParse(textBox1.Text, out double number1);
            bool isvalid2 = double.TryParse(textBox2.Text, out double number2);
            if (isvalid1)
            {
                if (isvalid2)
                {
                    double result = number1 * number2;
                    textBoxResult.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("You entered wrong input!");
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("You entered wrong input!");
            }
        }

        private void Devide_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid1 = double.TryParse(textBox1.Text, out double number1);
            bool isvalid2 = double.TryParse(textBox2.Text, out double number2);
            if (isvalid1)
            {
                if (isvalid2)
                {
                    if (number2 == 0)
                    {
                        textBox2.Text = "";
                        MessageBox.Show("You cannot devide by 0!");
                    }
                    else
                    {
                        double result = number1 / number2;
                        textBoxResult.Text = result.ToString();
                    }
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("You entered wrong input!");
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("You entered wrong input!");
            }
        }
    }
}

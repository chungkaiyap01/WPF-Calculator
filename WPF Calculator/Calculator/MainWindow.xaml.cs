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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal num1 = 0, num2 = 0, answer = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16((sender as Button).Content);

            if (operation == "")
            {
                num1 = (num1 * 10) + value;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + value;
                txtDisplay.Text = num2.ToString();
            }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();


            Eval();

            operation = value;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();


            Eval();

            operation = value;
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();


            Eval();

            operation = value;
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();


            Eval();

            operation = value;
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();

            txtDisplay.Text += value;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            txtDisplay.Text = "0";
        }

        private void BtnClearEntry_Click_1(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                num1 = 0;
                txtDisplay.Text = "0";
            }
            else
            {
                num2 = 0;
                txtDisplay.Text = "0";
            }
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            Eval();
            Clear();
        }

        private void Eval()
        {
            bool validate = true;

            switch (operation)
            {
                case "+":
                    answer = num1 + num2;
                    validate = true;
                    break;

                case "-":
                    answer = num1 - num2;
                    validate = true;
                    break;

                case "*":
                    answer = num1 * num2;
                    validate = true;
                    break;

                case "/":

                    if (num2 == 0)
                    {
                        Clear();
                        txtDisplay.Text = "Cannot Divide By Zero";
                        validate = false;
                    }
                    else
                    {
                        answer = num1 / num2;
                        validate = true;
                    }
                    break;

                default:
                    validate = false;
                    break;
            }


            if (validate == true)
            {
                num1 = answer;
                num2 = 0;
                operation = "";
                txtDisplay.Text = answer.ToString();
            }


        }

        private void Clear()
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            answer = 0;
        }




    }
}

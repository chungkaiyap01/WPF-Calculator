using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        char[] Operator = { '+', '-', '*', '/' };
        decimal num1 = 0, num2 = 0, answer = 0;
        string operation = "";
        string lastNumber = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            char BtnValue = Convert.ToChar((sender as Button).Content);
            Display(BtnValue);
        }

        //private void BtnPlus_Click(object sender, RoutedEventArgs e)
        //{
        //    string value = (sender as Button).Content.ToString();

        //    txtDisplay.Text += value;
        //}

        //private void BtnMinus_Click(object sender, RoutedEventArgs e)
        //{
        //    string value = (sender as Button).Content.ToString();
        //    txtDisplay.Text += value;
        //}

        //private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        //{
        //    string value = (sender as Button).Content.ToString();
        //    txtDisplay.Text += value;
        //}

        //private void BtnDivide_Click(object sender, RoutedEventArgs e)
        //{
        //    string value = (sender as Button).Content.ToString();
        //    txtDisplay.Text += value;
        //}

        //private void BtnDot_Click(object sender, RoutedEventArgs e)
        //{
        //    string value = (sender as Button).Content.ToString();
        //    txtDisplay.Text += value;
        //}

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

        private void Display(char BtnValue)
        {
            char LastValue = txtDisplay.Text[txtDisplay.Text.Length - 1];

            switch (BtnValue)
            {
                case '0':

                    if (string.IsNullOrEmpty(lastNumber))
                    {
                        txtDisplay.Text += LastValue != '0' && Operator.Contains(LastValue) ? BtnValue.ToString() : "";
                    }
                    else if(lastNumber[0] != '0')
                    {
                        txtDisplay.Text += BtnValue.ToString();
                    }


                    break;

                case '.':

                    if (!Operator.Contains(LastValue) && LastValue != '.' && !lastNumber.Contains('.'))
                    {
                        txtDisplay.Text += BtnValue.ToString();
                    }
                    else if (Operator.Contains(LastValue))
                    {
                        txtDisplay.Text += $"0{BtnValue.ToString()}";
                    }


                    break;

                default:

                    if (Char.IsDigit(BtnValue))
                    {
                        txtDisplay.Text = txtDisplay.Text == "0" ? BtnValue.ToString() : $"{txtDisplay.Text + BtnValue.ToString()}";
                    }
                    else
                    {
                        if (!Operator.Contains(LastValue) && LastValue != '.')
                        {
                            txtDisplay.Text += BtnValue.ToString();
                        }
                        else
                        {
                            txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1) + BtnValue.ToString();
                        }


                    }

                    break;
            }


            if (!Operator.Contains(BtnValue))
            {
                lastNumber += BtnValue.ToString();
            }
            else if (Operator.Contains(BtnValue))
            {
                lastNumber = "";
            }
        }




    }
}

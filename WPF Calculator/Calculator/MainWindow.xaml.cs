using System;
using System.Collections.Generic;
using System.Data;
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

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void BtnClearEntry_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            BackSpace();
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            Eval(txtDisplay.Text);
        }

        private void Eval(string expression)
        {
            bool validate = true;

            if (expression == "0")
                validate = false;

            if (expression.IndexOfAny(Operator) == -1)
                validate = false;

            if (string.IsNullOrEmpty(lastNumber))
                validate = false;


            if (validate)
            {
                var loDataTable = new DataTable();
                var loDataColumn = new DataColumn("Eval", typeof(double), expression);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);

                string answer = ((double)(loDataTable.Rows[0]["Eval"])).ToString();

                txtDisplay.Text = answer;
                lastNumber = answer;
            }

        }

        private void Clear()
        {
            txtDisplay.Text = "0";
            lastNumber = "";
        }

        private void Display(char BtnValue)
        {
            char LastValue = txtDisplay.Text[txtDisplay.Text.Length - 1];
            string screen = txtDisplay.Text == "0" ? "" : txtDisplay.Text;


            if (char.IsDigit(BtnValue))
            {
                if (BtnValue == '0')
                {
                    bool check = true;

                    if (lastNumber.Length >= 2)
                    {
                        if (lastNumber[0] == '0' && lastNumber[1] != '.')
                            check = false;
                    }
                    else if (lastNumber.Length == 1)
                    {
                        if (lastNumber == "0")
                            check = false;
                    }



                    if (check)
                    {
                        screen += BtnValue.ToString();
                        lastNumber += BtnValue.ToString();
                    }


                }
                else
                {
                    screen += BtnValue.ToString();

                    lastNumber += BtnValue.ToString();
                }

            }
            else if (Operator.Contains(BtnValue))
            {
                lastNumber = "";

                if (screen != "")
                {
                    if (char.IsDigit(LastValue))
                    {
                        screen += BtnValue.ToString();
                    }
                    else if (LastValue == '.')
                    {

                    }
                    else if (Operator.Contains(LastValue))
                    {
                        screen = screen.Remove(screen.Length - 1) + BtnValue.ToString();

                    }
                }
                else
                {
                    screen = "0";
                }
            }
            else
            {
                switch (BtnValue)
                {
                    case '.':

                        if (Operator.Contains(LastValue) || screen == "")
                        {
                            screen += $"0{BtnValue.ToString()}";
                            lastNumber += $"0{BtnValue.ToString()}";
                        }
                        else if (!Operator.Contains(LastValue) && LastValue != '.' && !lastNumber.Contains('.'))
                        {
                            screen += BtnValue.ToString();
                            lastNumber += BtnValue.ToString();
                        }

                        break;

                    default:
                        break;
                }
            }



            if (lastNumber == "0" && txtDisplay.Text.Length == 1)
            {
                lastNumber = "";
            }

            txtDisplay.Text = screen;

        }

        private void BackSpace()
        {
            string screen = txtDisplay.Text;

            if (screen != "0")
            {
                screen = screen.Remove(screen.Length - 1);

                if (screen == "")
                    screen = "0";

                if (!string.IsNullOrEmpty(lastNumber))
                    lastNumber = lastNumber.Remove(lastNumber.Length - 1);
            }

            txtDisplay.Text = screen;
        }
    }
}

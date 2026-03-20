using System;
using System.Windows;
using System.Windows.Controls;
using vizgalova_library1;

namespace vizgalova_calculator_2pr
{
    public partial class MainWindow : Window
    {
        string s = "";

        public MainWindow()
        {
            InitializeComponent();
            ResultText.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string t = b.Content.ToString();

            switch (t)
            {
                case "C":
                    s = "";
                    ResultText.Text = "0";
                    ExpressionText.Text = "";
                    break;

                case "=":
                    try
                    {
                        double r = Calc.Calculate(s);
                        ExpressionText.Text = s + " =";
                        ResultText.Text = r.ToString().Replace(',', '.');
                        s = r.ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Ошибка: деление на ноль!");
                        ResultText.Text = "∞";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                    }
                    break;

                default:
                    if (s.Length > 0 && IsOperator(t) && IsOperator(s[s.Length - 1].ToString()))
                        return;
                    if (t == "." && s.Length > 0 && s[s.Length - 1] == '.')
                        return;
                    if (t == "." && s.Length == 0)
                        s = "0";
                    s += t;
                    ResultText.Text = s;
                    break;
            }
        }

        bool IsOperator(string c)
        {
            return c == "+" || c == "-" || c == "*" || c == "/" || c == "^";
        }
    }
}

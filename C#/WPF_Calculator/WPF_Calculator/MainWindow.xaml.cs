using System;
using System.Linq;
using System.Windows;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool operatorExists = false;
        bool firstValSet = false;
        bool prevResult = false;
        string op = "";
        int[] values = new int[2];
        char[] ops = { '+', '-', '*', '/'};

        public MainWindow()
        {
            InitializeComponent();
            screen.IsReadOnly = true;
        }

        /// <summary>
        /// Checks which button is pressed, and performs the necessary action
        /// </summary>
        /// <param name="s">The text of the pressed button; used to identify which button is pressed</param>
        public void getInput(String s)
        {
            if(s == "clr")
            {
                screen.Clear();
                resetValues();
            }
            else if(s == "ret")
            {
                if (operatorExists)
                {
                    prevResult = true;
                    parseOperation();
                    resetValues();
                }
            }
            else if((s == "+" || s == "-" || s == "*" || s == "/") && !operatorExists && (firstValSet || prevResult))
            {
                screen.Text += s;
                op = s;
                operatorExists = true;
                firstValSet = true;
            }
            else if(s.Any(char.IsDigit))
            {
                if (!firstValSet)
                {
                    screen.Clear();
                    screen.Text += s;
                    firstValSet = true;
                    prevResult = false;
                }
                else
                {
                    screen.Text += s;
                }
            }
                
        }
        /// <summary>
        /// Parses the screen for a full operation and performs it, writing the result to the screen afterwards
        /// </summary>
        public void parseOperation()
        {
            string s = screen.Text;
            string result = "0";

            string[] temp = s.Split(ops);
            try
            {
                values[0] = Int32.Parse(temp[0]);
                values[1] = Int32.Parse(temp[1]);
            }
            catch (Exception e)
            {
                op = "";
                result = "Error: input was invalid";
                prevResult = false;
            }
            

            if (op == "+")
            {   
                result = "" + (values[0] + values[1]);
            }
            if (op == "-")
            {
                result = "" + (values[0] - values[1]);
            }
            if (op == "*")
            {
                result = "" + (values[0] * values[1]);
            }
            if (op == "/")
            {
                result = "" + (values[0] / values[1]);
            }
            screen.Clear();
            screen.Text = result;
        }
        /// <summary>
        /// Resets all values necessary for performing an operation
        /// </summary>
        public void resetValues()
        {
            values[0] = 0;
            values[1] = 0;
            op = "";
            operatorExists = false;
            firstValSet = false;
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            getInput(one.Content.ToString());
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            getInput(two.Content.ToString());
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            getInput(three.Content.ToString());
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            getInput(four.Content.ToString());
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            getInput(five.Content.ToString());
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            getInput(six.Content.ToString());
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            getInput(seven.Content.ToString());
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            getInput(eight.Content.ToString());
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            getInput(nine.Content.ToString());
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            getInput(zero.Content.ToString());
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            getInput(clear.Content.ToString());
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            getInput(ret.Content.ToString());
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            getInput(add.Content.ToString());
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            getInput(sub.Content.ToString());
        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            getInput(mul.Content.ToString());
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            getInput(div.Content.ToString());
        }
    }
}

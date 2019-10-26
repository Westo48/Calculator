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
        public MainWindow()
        {
            InitializeComponent();
        }

        Equation equation = new Equation();

        public void UpdateTextBox(string str, TextBox tb)
        {
            tb.Text = str;
        }
        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("0");
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("1");
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("2");
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("3");
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("4");
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("5");
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("6");
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("7");
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("8");
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.NumClick("9");
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.DecClick();
        }

        private void BtnExp_Click(object sender, RoutedEventArgs e)
        {
            equation.OpClick('^');
            txtBox.Text = "0";
        }
        private void BtnMult_Click(object sender, RoutedEventArgs e)
        {
            equation.OpClick('*');
            txtBox.Text = "0";
        }
        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            equation.OpClick('/');
            txtBox.Text = "0";
        }
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            equation.OpClick('+');
            txtBox.Text = "0";
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            equation.OpClick('-');
            txtBox.Text = "0";
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.Solve();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.BackClick();
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.ClearClick();
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            equation.ClearAllClick();
            txtBox.Text = "0";
        }

        private void BtnPosNeg_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = equation.PosNegClick();
        }
    }
}

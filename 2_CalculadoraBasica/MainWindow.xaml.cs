using System;
using System.Windows;
using System.Windows.Controls;

namespace _2_CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            calcularButton.IsEnabled = false; 
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double operando1 = double.Parse(operando1TextBox.Text);
                double operando2 = double.Parse(operando2TextBox.Text);
                string operador = operadorTextBox.Text;
                double resultado;
                switch (operador)
                {
                    case "+":
                        resultado = operando1 + operando2;
                        break;
                    case "-":
                        resultado = operando1 - operando2;
                        break;
                    case "*":
                        resultado = operando1 * operando2;
                        break;
                    case "/":
                        resultado = operando1 / operando2;
                        break;
                    default:
                        resultado = double.MinValue;
                        break;
                }
                if (resultado == double.MinValue)
                {
                    resultadoTextBox.Text = "";
                    MessageBox.Show("Operadores permitidos: + - * /");
                }   
                else
                    resultadoTextBox.Text = $"{resultado:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error.\nCausa: "+ ex.Message +"\nRecomendación: Revise los operandos.");
            }

        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            operando1TextBox.Text = "";
            operando2TextBox.Text = "";
            operadorTextBox.Text = "";
            resultadoTextBox.Text = "";
        }

        private void operadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (operadorTextBox.Text == "+" ||
                operadorTextBox.Text == "-" ||
                operadorTextBox.Text == "*" ||
                operadorTextBox.Text == "/")
                calcularButton.IsEnabled = true;
            else
                calcularButton.IsEnabled = false;
        }
    }
}

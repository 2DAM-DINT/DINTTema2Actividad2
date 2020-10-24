using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Actividad2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PATRON_OPERADORES = @"^(\+|-|\*|\/){1}$";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Operador_TextoCambiado(object sender, RoutedEventArgs e)
        {
            Regex expresionRegular = new Regex(PATRON_OPERADORES);
            Match coincidencia = expresionRegular.Match(operador.Text);

            if (coincidencia.Success)
                botonResultado.IsEnabled = true;
            else
                botonResultado.IsEnabled = false;
        }

        private void Resultado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double valor1 = double.Parse(operando1.Text);
                double valor2 = double.Parse(operando2.Text);

                double resultadoOperacion;

                switch (operador.Text)
                {
                    case "+":
                        resultadoOperacion = valor1 + valor2;
                        break;
                    case "-":
                        resultadoOperacion = valor1 - valor2;
                        break;
                    case "*":
                        resultadoOperacion = valor1 * valor2;
                        break;
                    case "/":
                        resultadoOperacion = valor1 / valor2;
                        break;
                    default:
                        resultadoOperacion = 0;
                        break;
                }
                resultado.Text = resultadoOperacion.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Los operandos no están bien, por favor,\n" +
                                "revisalos y pon un número entero o real.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Se ha producido un error\n"+
                                exception.Message);
            }
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            operando1.Text = "";
            operando2.Text = "";
            operador.Text = "";
            resultado.Text = "";
        }
    }
}

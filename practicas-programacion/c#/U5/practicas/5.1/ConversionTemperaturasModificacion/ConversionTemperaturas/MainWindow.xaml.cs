using System;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

namespace ConversionTemperaturas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textCentigrados_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textFahrenheit != null && textCentigrados.IsFocused)
                    textFahrenheit.Text = (Convert.ToDouble(textCentigrados.Text) * 1.8 + 32.0).ToString();
            }
            catch (Exception)
            {
                if (textCentigrados.Text != "" && textCentigrados.Text != "-")
                {
                    Alerta();
                    textCentigrados.Text = "";
                }
                
            }
        }

        private void textFahrenheit_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textCentigrados != null && textFahrenheit.IsFocused)
                    textCentigrados.Text = ((Convert.ToDouble(textFahrenheit.Text) - 32.0) / 1.8).ToString();
            }
            catch (Exception)
            {
               if (textFahrenheit.Text != "" && textFahrenheit.Text != "-")
                {
                    Alerta();
                    textFahrenheit.Text = "";
                }
            }
        }


        private void Alerta()
        {
            // Inicializa las variables
            string mensaje = "Cantidad no valida";
            string titulo = "Error de formato";
            MessageBoxButton boton = MessageBoxButton.OK;
            // Muestra MessageBox.
            MessageBox.Show(mensaje, titulo, boton);
        }
    }
}

using System;
using System.Windows;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textFahrenheit.Text = (Convert.ToDouble(textCentigrados.Text) * 1.8 + 32.0).ToString();
            }
            catch (Exception)
            {
                textCentigrados.Text = "";
            }
        }
    }
}

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

        private void textCentigrados_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                try
                {
                    textFahrenheit.Text = (Convert.ToDouble(textCentigrados.Text) * 9 / 5 + 32).ToString();
                    textCentigrados.SelectAll();

                }
                catch (Exception)
                {
                    textCentigrados.Text = "";
                }
            }

        }

        private void textFahrenheit_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                try
                {
                    textCentigrados.Text = ((Convert.ToDouble(textFahrenheit.Text) - 32)  * 5 / 9).ToString();
                    textFahrenheit.SelectAll();

                }
                catch (Exception)
                {
                    textFahrenheit.Text = "";
                }
            }
        }
    }
}

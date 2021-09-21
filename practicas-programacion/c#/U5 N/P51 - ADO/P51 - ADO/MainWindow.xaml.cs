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

namespace P51___ADO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboAdulto.ItemsSource = new List<String> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            comboMenor.ItemsSource = new List<String> { "0", "1", "2", "3" };
            comboDestino.ItemsSource = new List<Destino> {
                new Destino("México DF", 450.00),
                new Destino("Puebla", 350.00),
                new Destino("Xalapa", 130.00) 
            };
            comboDestino.DisplayMemberPath = "Nombre";
            comboAdulto.SelectedIndex = 0;
            comboMenor.SelectedIndex = 0;
            comboDestino.SelectedIndex = 0;
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            Destino miDestino = (Destino) comboDestino.SelectedItem;
            double total = 0.0;
            int adultos = Convert.ToInt32((String)comboAdulto.SelectedItem);
            int menores = Convert.ToInt32((String)comboMenor.SelectedItem);
            if (rbRedondo.IsChecked == true)
            {
                total = adultos * (miDestino.Precio * (1 - 0.01)) + menores * ((miDestino.Precio * 0.5) * (1 - 0.01));
            }
            else
            {
                total = adultos * miDestino.Precio + menores * (miDestino.Precio * 0.5);
            }
            txtTotal.Text = total.ToString();
        }
    }
}

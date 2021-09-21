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

namespace P52___COTIZACION
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Automovil> autos = new List<Automovil>();
        public bool toggle = false;
        public MainWindow()
        {
            InitializeComponent();
            autos.Add(new Automovil("Seat Ibiza",   12000.00));
            autos.Add(new Automovil("Seat Cordoba", 13000.00));
            autos.Add(new Automovil("Seat Leon",    16000.00));
            comboAutos.ItemsSource = autos;
            comboAutos.DisplayMemberPath = "Modelo";
            comboAutos.SelectedIndex = 0;
        }

        private void rbAgregarAuto_Click(object sender, RoutedEventArgs e)
        {
            toggle = !toggle;
            rbAgregarAuto.IsChecked = toggle;
            if (rbAgregarAuto.IsChecked == true)
            {
                buttonAgregar.IsEnabled = true;
                txtModelo.IsEnabled = true;
                txtPrecioBase.IsEnabled = true;
            }
            else
            {
                buttonAgregar.IsEnabled = false;
                txtModelo.IsEnabled = false;
                txtPrecioBase.IsEnabled = false;
                txtModelo.Text = "";
                txtPrecioBase.Text = "";
            }
        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            double precioBase = 0.00;
            if (txtPrecioBase.Text != "" && txtModelo.Text != "")
            {
                try
                {
                    precioBase = Convert.ToDouble(txtPrecioBase.Text);
                    if (precioBase > 0)
                    {
                        autos.Add(new Automovil(txtModelo.Text, precioBase));
                        comboAutos.ItemsSource = autos;
                        comboAutos.DisplayMemberPath = "Modelo";
                        comboAutos.Items.Refresh();
                        txtModelo.Text = "";
                        txtPrecioBase.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("El precio debe ser un numero positivo");
                        txtPrecioBase.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("El precio debe ser un numero");
                    txtPrecioBase.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Llenar todos los campos");
            }
        }

        private void buttonMensualidad_Click(object sender, RoutedEventArgs e)
        {
            double total = 0.00;
            Automovil miAuto = (Automovil) comboAutos.SelectedItem;
            total += miAuto.PrecioBase;
            if (rb1600cc.IsChecked == true)
                total += 1500.00;
            else if (rb1800cc.IsChecked == true)
                total += 3000.00;

            if (checkRin.IsChecked == true)
                total += 500.00;

            if (rb12meses.IsChecked == true)
                txtMensualidad.Text = (total / 12.00).ToString();
            else if (rb24meses.IsChecked == true)
                txtMensualidad.Text = (total / 24.00).ToString();
            else if (rb36meses.IsChecked == true)
                txtMensualidad.Text = (total / 36.00).ToString();
        }
    }
}

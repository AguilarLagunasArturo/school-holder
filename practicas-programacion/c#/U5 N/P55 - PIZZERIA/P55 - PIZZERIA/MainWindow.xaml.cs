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

namespace P55___PIZZERIA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Pedido> pedidos = new List<Pedido>();
        public double precioPorIngrediente = 20.0;
        public MainWindow()
        {
            InitializeComponent();
            List<Pizza> pizzas = new List<Pizza>();
            pizzas.Add(new PizzaMediana("Elaborando"));
            pizzas.Add(new PizzaGrande("Elaborando"));
            pizzas.Add(new PizzaFamiliar("Elaborando"));
            
            comboSize.ItemsSource = pizzas;
            comboSize.DisplayMemberPath = "Descripcion";
            comboSize.SelectedIndex = 0;
            comboSize.Items.Refresh();
        }

        private void buttonAdministrar_Click(object sender, RoutedEventArgs e)
        {
            VentanaAdministracion ventana = new VentanaAdministracion();
            ventana.ShowDialog();
        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCliente.Text != "" && txtTelefono.Text != "")
            {
                Pizza pizzaSeleccionada = (Pizza) comboSize.SelectedItem;

                int ingredientesExtra = 0;
                if (check1.IsChecked == true)
                    ingredientesExtra += 1;
                if (check2.IsChecked == true)
                    ingredientesExtra += 1;
                if (check3.IsChecked == true)
                    ingredientesExtra += 1;
                if (check4.IsChecked == true)
                    ingredientesExtra += 1;
                if (check5.IsChecked == true)
                    ingredientesExtra += 1;
                if (check6.IsChecked == true)
                    ingredientesExtra += 1;

                if (rbEntregado.IsChecked == true)
                    pedidos.Add(new Pedido(new Cliente(txtCliente.Text, txtTelefono.Text), ingredientesExtra, pizzaSeleccionada, precioPorIngrediente, "Entregado"));
                else
                    pedidos.Add(new Pedido(new Cliente(txtCliente.Text, txtTelefono.Text), ingredientesExtra, pizzaSeleccionada, precioPorIngrediente, "Elaborando"));

                MessageBox.Show(pedidos[pedidos.Count - 1].GeneraFactura());

                rbEntregado.IsChecked = false;
                rbElaborando.IsChecked = true;
                txtCliente.Text = "";
                txtTelefono.Text = "";
                check1.IsChecked = false;
                check2.IsChecked = false;
                check3.IsChecked = false;
                check4.IsChecked = false;
                check5.IsChecked = false;
                check6.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Hace falta llenar campos");
            }
        }
    }
}

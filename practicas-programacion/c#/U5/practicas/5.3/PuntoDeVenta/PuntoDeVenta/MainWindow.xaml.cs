using System;
using System.Collections.Generic;
using System.Windows;

namespace PuntoDeVenta
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Cliente> clientes;
        public MainWindow()
        {
            InitializeComponent();
            clientes = new List<Cliente>();
            comboClientes.ItemsSource = clientes;
        }

        private void buttonComprar_Click(object sender, RoutedEventArgs e)
        {
            // Asegurar que se llenen todos los campos
            if (textCliente.Text == "" || textPresupuesto.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos vacios");
                return;
            }

            // Se recupera el sexo del cliente
            char sexo;
            if (radioFemenino.IsChecked == true)
                sexo = 'F';
            else
                sexo = 'M';

            // Se recupera el presupuesto
            double presupuesto = 0;
            try
            {
                presupuesto = Convert.ToDouble(textPresupuesto.Text);
            }
            catch
            {
                MessageBox.Show("Presupuesto invalido.");
                textPresupuesto.Text = "";
                return;
            }

            // Se asegura que el presupuesto sea un valor positivo
            if (presupuesto <= 0)
            {
                MessageBox.Show("El presupuesto debe ser un valor positivo.");
                textPresupuesto.Text = "";
                return;
            }

            // Se crea una ventana wProductos para que el cliente realize sus compras
            WProductos ventanaProductos;
            ventanaProductos = new WProductos(new Cliente(
                textCliente.Text,
                presupuesto,
                sexo)
            );
            textCliente.Text = "";
            textPresupuesto.Text = "";
            ventanaProductos.ShowDialog();
            comboClientes.Items.Refresh();
            comboClientes.DisplayMemberPath = "Id";
        }

        // Cuando se cambia de seleccion
        private void comboClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (comboClientes.SelectedItem == null)
                return;
            Cliente clienteSeleccionado = (Cliente) comboClientes.SelectedItem;
            WHistorialCliente ventana = new WHistorialCliente(clienteSeleccionado);
            ventana.ShowDialog();
            comboClientes.SelectedItem = null;
        }
    }
}

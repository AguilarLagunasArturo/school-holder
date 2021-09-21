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
using System.Windows.Shapes;

namespace P55___PIZZERIA
{
    /// <summary>
    /// Lógica de interacción para VentanaAdministracion.xaml
    /// </summary>
    public partial class VentanaAdministracion : Window
    {
        public VentanaAdministracion()
        {
            InitializeComponent();
            comboEstado.ItemsSource = new List<String>() {"Elaborando", "Entregado"};
            comboEstado.SelectedIndex = 0;
            DGPedidos.DataContext = MainWindow.pedidos;
            labelTotal.Content = MainWindow.pedidos.Sum(p => p.Total());
        }

        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Pedido> aux;
                string buscaNombre = txtBuscarCliente.Text;

                aux = MainWindow.pedidos.FindAll(p => p.Cliente.Nombre.Contains(buscaNombre));

                DGPedidos.DataContext = aux;
            }
        }

        private void comboEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string estado = (string) comboEstado.SelectedItem;
            List<Pedido> aux;
            string buscaNombre = txtBuscarCliente.Text;

            aux = MainWindow.pedidos.FindAll(p => p.Estado.Contains(estado));

            DGPedidos.DataContext = aux;
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Pedido pedido = (Pedido) DGPedidos.SelectedItem;
            if (pedido != null && pedido.Estado != "Entregado")
            {
                MainWindow.pedidos.Remove(pedido);
                MessageBox.Show("Se cancelado el pedido");
                labelTotal.Content = MainWindow.pedidos.Sum(p => p.Total());
                DGPedidos.DataContext = null;
            }
            else
            {
                MessageBox.Show("No se puede cancelar pedido");
            }
        }
    }
}

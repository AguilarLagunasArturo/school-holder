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

namespace PuntoDeVenta
{
    /// <summary>
    /// Lógica de interacción para WHistorialCliente.xaml
    /// </summary>
    public partial class WHistorialCliente : Window
    {
        public WHistorialCliente(Cliente cliente)
        {
            InitializeComponent();
            // Se actualizan los datos del cliente
            labelCliente.Content = cliente.Nombre;
            labelPresupuesto.Content = "$ " + cliente.Presupuesto.ToString();
            labelCambio.Content = "$ " + (cliente.Presupuesto - cliente.Total()).ToString();
            scrollProductos.Content = cliente.Factura();
            BitmapImage bi3 = new BitmapImage();
            if (cliente.Sexo == 'M')
            {
                bi3.BeginInit();
                bi3.UriSource = new Uri("./src/hombre.png", UriKind.Relative);
                bi3.EndInit();
            }
            else
            {
                bi3.BeginInit();
                bi3.UriSource = new Uri("./src/mujer.png", UriKind.Relative);
                bi3.EndInit();
            }
            imgGenero.Source = bi3;
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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

namespace PagoServicios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Paquete> listaPaquetes = new List<Paquete>(){
            new Paquete("Basic",   100.0),
            new Paquete("Medium",  150.0),
            new Paquete("Premium", 400.0) 
        };

        public List<Cliente> listaClientes = new List<Cliente>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // delegate (Paquete p) { return p.Descripcion; }
            // List<string> nombres = listaPaquetes.ConvertAll(p => p.Descripcion);
            List<string> nombres = listaPaquetes.ConvertAll(DescripcionPaquete);
            cmbPaquetes.ItemsSource = nombres;
            cmbPaquetes.SelectedIndex = 0;
        }

        string DescripcionPaquete(Paquete p)
        {
            return p.Descripcion;
        }	


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // delegate (Paquete p) { return p.Descripcion == cmbPaquetes.SelectedItem.ToString(); }
            Paquete paquete = listaPaquetes.Find( p => p.Descripcion == cmbPaquetes.SelectedItem.ToString());
            Cliente cliente = new Cliente(txtNombre.Text, txtDireccion.Text, paquete);
            listaClientes.Add(cliente);

            MessageBox.Show("Se agrego a: " + txtNombre.Text);

            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Cliente> aux;
                string buscaNombre = txtBuscarNombre.Text;
                aux = listaClientes.FindAll(BuscarClientes);
                DGClientes.DataContext = aux;

            }

        }

        bool BuscarClientes(Cliente c)
        {
            return c.Nombre.Contains(txtBuscarNombre.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

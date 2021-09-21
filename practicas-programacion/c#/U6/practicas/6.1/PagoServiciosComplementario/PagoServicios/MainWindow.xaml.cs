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

            dGPaquetes.DataContext = listaPaquetes;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // delegate (Paquete p) { return p.Descripcion; }
            List<string> nombres = listaPaquetes.ConvertAll(p => p.Descripcion);
            cmbPaquetes.ItemsSource = nombres;
            cmbPaquetes.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtDireccion.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // delegate (Paquete p) { return p.Descripcion == cmbPaquetes.SelectedItem.ToString(); }
            Paquete paquete = listaPaquetes.Find( p => p.Descripcion == cmbPaquetes.SelectedItem.ToString());
            Cliente cliente = new Cliente(txtNombre.Text, txtDireccion.Text, paquete);
            listaClientes.Add(cliente);

            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Cliente> aux;
                string buscaNombre = txtBuscarNombre.Text;

                aux = listaClientes.FindAll(c => c.Nombre.Contains(buscaNombre));
                aux.Sort(delegate (Cliente cliente1, Cliente cliente2)
                {
                    return cliente1.Nombre.CompareTo(cliente2.Nombre);
                });

                DGClientes.DataContext = aux;
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DGClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente cliente = (Cliente) DGClientes.SelectedItem;
            if (cliente == null)
                return;
            txtCliente.Text = cliente.Nombre;
            txtPaquete.Text = cliente.Paquete.Descripcion;
            txtTotal.Text = (cliente.Paquete.Precio * 1.15).ToString();
            expanderDatos.IsExpanded = true;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombrePaquete.Text == "" || txtPago.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            double pago;
            try
            {
                pago = Convert.ToDouble(txtPago.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorrecto en pago");
                txtPago.Text = "";
                return;
            }

            if (pago <= 0)
            {
                MessageBox.Show("El pago debe ser un valor positivo");
                txtPago.Text = "";
                return;
            }

            listaPaquetes.Add(new Paquete(txtNombrePaquete.Text, pago));

            dGPaquetes.DataContext = null;
            dGPaquetes.DataContext = listaPaquetes;

            txtNombrePaquete.Text = "";
            txtPago.Text = "";

            List<string> nombres = listaPaquetes.ConvertAll(p => p.Descripcion);
            cmbPaquetes.ItemsSource = nombres;
            cmbPaquetes.SelectedIndex = 0;
        }
    }
}

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

namespace Restaurante
{
    /// <summary>
    /// Lógica de interacción para WEmpleado.xaml
    /// </summary>
    public partial class WEmpleado : Window
    {
        // VARIABLES GLOBALES
        public Empleado empleado = null; // EL QUE ATIENDE
        public Producto productoSeleccionado = null; // SE ACTUALIZA AL SELECCIONAR PRODUCTO
        public List<Producto> productos = new List<Producto>(); // SE ACTUALIZA AL AGREGAR UN PRODUCTO

        // SE PASA LA INFFORMACION DEL EMPLEADO QUE ESTA ATENDIENDO
        public WEmpleado(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
        }

        // CERRAR
        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // BUSCAR
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // AL DAR ANTER
            if (e.Key == Key.Return)
            {
                // BUSCAR PRODUCTOS EN LA BASE DE DATOS
                List<Producto> protuctosEncontrados = DBRestaurante.BuscarP(txtBuscar.Text);

                // SI NO HAY PRODUCTOS CON ESE NOMBRE, INFORMAR
                if (protuctosEncontrados.Count < 1)
                {
                    MessageBox.Show("No se han encontrado productos");
                    return;
                }

                // SE ACTUALIZA DATAGRID
                DGProductos.ItemsSource = protuctosEncontrados;
            }
        }

        // CUANDO SE SELECCIONA UN ELEMENTO DEL DATAGRID
        private void DGProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SI SE SELECCIONO UNO SOLO
            if (DGProductos.SelectedItems.Count == 1)
            {
                // SE ACTUALIZA VARIABLE GLOBAL
                productoSeleccionado = (Producto)DGProductos.SelectedItem;
            }
            else // SI SE SELECCIONA MAS DE UNO
            {
                productoSeleccionado = null;
            }
        }

        // SE AGREGA UN PRODUCTO A LA FACTURA
        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            // CHECA QUE HAYA UN PRODUCTO SELECCIONADO
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Favor seleccionar un elemento del menu");
                return;
            }

            // SE ACTIALIZA LA LISTA DE PRODUCTOS
            productos.Add(productoSeleccionado);
            
            // SE ACTUALIZA EL SUBTOTAL
            labelSubtotal.Content = (productos.Sum(p => p.Precio)).ToString();

            // productos.Sum(p => p.Precio) : SUMA TODOS LOS PRECIOS QUE ESTAN EN LA LISTA
        }

        // QUITAR ELEMENTO DE LA LISTA
        private void buttonQuitar_Click(object sender, RoutedEventArgs e)
        {
            // CORROBORAR QUE SE HAYA SELECCIONADO UN PRODUCTO
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Favor seleccionar algo del menu");
                return;
            }
            // CHECHA SI HAY PRODUCTOS EN LA LISTA
            if(productos.Count < 1)
            {
                MessageBox.Show("No hay elementos que quitar");
                return;
            }

            // QUITA EL PRODUCTO SELECCIONADO
            foreach (Producto p in productos)
            {
                if (p.Nombre.Equals(productoSeleccionado.Nombre)) // EL NOMBRE DEBE DE COINCIDIR PARA QUITARLO DE LA LSTA
                {
                    // SE QUITA DE LA LISTA
                    productos.Remove(p);
                    MessageBox.Show("Se ha quitado el elemento seleccionado");
                    break;
                }
            }

            // SE ACTUALIZA EL SUBTOTAL
            labelSubtotal.Content = labelSubtotal.Content = (productos.Sum(p => p.Precio)).ToString();
            // productos.Sum(p => p.Precio) : SUMA TODOS LOS PRECIOS QUE ESTAN EN LA LISTA
        }

        // FACTURAR COMPRA
        private void buttonFacturar_Click(object sender, RoutedEventArgs e)
        {
            // CORROBORAR QUE LOS CAMPOS ESTEN COMPLETOS
            if (txtCliente.Text == "" || txtPago.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // CORROBORAR QUE EL PAGO SEA VALIDO
            double monto = 0;
            // CONFIRMA QUE SEA UN NUMERO
            try
            {
                monto = Convert.ToDouble(txtPago.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorrecto");
                txtPago.Text = "";
                return;
            }

            // CONFIRMA QUE EL NUMERO SEA POSITIVO
            if (monto < 1)
            {
                MessageBox.Show("El monto debe ser un numero positivo");
                txtPago.Text = "";
                return;
            }

            // SE CALCULA EL CAMBIO PARA EL CLIENTE
            double total = productos.Sum(p => p.Precio);
            double cambio = monto - total;

            // CONFIRMA QUE EL PAGO SEA SUFICIENTE
            if (cambio < 0)
            {
                MessageBox.Show("El monto del cliente no es suficiente para pagar");
                txtPago.Text = "";
                return;
            }

            // SE GENERA LA FACTURA
            string info = "=== COMPRA ===\n\n";
            info += "Cliente: " + txtCliente.Text + "\n";
            info += "Atendio: " + empleado.Nombre + "\n";
            foreach (Producto p in productos) // SE ITERAN TODOS LOS PRODUCTOS DE LA LISTA
            {
                info += String.Format("\n{0}:\t${1}", p.Nombre, p.Precio); // ANEXAN A LA FACTURA
            }
            info += "\n\nTotal: " + total.ToString();
            info += "\nPago: " + monto.ToString();
            info += "\nCambio: " + cambio.ToString();

            // SE AGREGA FACTURA A LA BASE DE DATOS
            DBRestaurante.AgregarF(new Factura(txtCliente.Text, empleado.Nombre, monto, total, cambio, info));

            // SE MUESTRA FACTURA
            MessageBox.Show(info);

            // SE RESETEAN LAS VARIABLES
            txtCliente.Text = "";
            txtPago.Text = "";
            labelSubtotal.Content = "0.00";

            productoSeleccionado = null;
            productos = new List<Producto>();
        }
    }
}

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
    /// Lógica de interacción para WAdministrador.xaml
    /// </summary>
    public partial class WAdministrador : Window
    {
        // VARIABLES GLOBALES
        public static Producto productoSeleccionado = null; // SE ACTUALIZA CUANDO SE SELECCIONA UN PRODUCTO
        public static Empleado empleadoSeleccionado = null; // SE ACTUALIZA CUANDO SE SELECCIONA UN EMPLEADOS

        public WAdministrador()
        {
            InitializeComponent();
        }

        // CERRAR LA VENTANA
        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // ADMINISTRACION DE PRODUCTOS
        private bool CamposProductosLlenos() // VERIFICA SI TODOS CAMPOS ESTAN LLENOS
        {
            if (txtNombreProducto.Text == "" || txtPrecioProducto.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return false;
            }
            // Asegurarse que el campo precio sea un numero
            double precio = 0.0;
            try
            {
                precio = Convert.ToDouble(txtPrecioProducto.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorrecto");
                txtPrecioProducto.Text = "";
                return false;
            }
            // Asegurarse que el campo precio sea un numero positivo
            if (precio <= 0)
            {
                MessageBox.Show("Formato incorrecto");
                txtPrecioProducto.Text = "";
                return false;
            }
            return true;
        }

        // AL DAR CLIC EN AGREGAR
        private void buttonAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            // Asegurarse que todos los campos esten llenos
            if (CamposProductosLlenos())
            {
                // ENTONCES AGREGAMOS EL PRODUCTO A LA DB
                DBRestaurante.AgregarP(new Producto(txtNombreProducto.Text, Convert.ToDouble(txtPrecioProducto.Text)));
                // SE RESETEAN LOS CAMPOS
                txtNombreProducto.Text = "";
                txtPrecioProducto.Text = "";
            }
        }

       // BUSCAR
        private void txtBuscarProductos_KeyDown(object sender, KeyEventArgs e)
        {
            // AL DAR ENTER EN EL BUSCADOR
            if (e.Key == Key.Return)
            {
                // GENERA LISTA DE PRODUCTOS
                List<Producto> productosEncontrados = DBRestaurante.BuscarP(txtBuscarProductos.Text);

                // SI HAY 0 PRODUCTOS
                if (productosEncontrados.Count < 1)
                {
                    // NOTIFICAR AL USUARIO
                    MessageBox.Show("No se han encontrado productos");
                    return;
                }

                // SE ACTUALIZA DATAGRID
                DGProductos.ItemsSource = productosEncontrados;
            }
        }

        // BOTON MODIFICAR
        private void buttonModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            // Asegurarse que todos los campos esten llenos & se comprueba que se haya seleccionado un producto
            if (CamposProductosLlenos() && productoSeleccionado != null)
            {
                // CUANDO SE SELECCIONA UN PRODUCTO SE MODIFICAN LOS CAMPOS
                productoSeleccionado.Nombre = txtNombreProducto.Text;
                productoSeleccionado.Precio = Convert.ToDouble(txtPrecioProducto.Text);
                DBRestaurante.ModificarP(productoSeleccionado); // SE COMUNICA LA BD PARA HACER LOS CAMBIOS

                // SE NOTIFICAN LOS CAMBIOS
                MessageBox.Show("Se ha modificado el producto");

                // SE REINICIAN LOS CAMPOS
                DGProductos.ItemsSource = null;

                txtNombreProducto.Text = "";
                txtPrecioProducto.Text = "";
            }
            else
            {
                // se notifica al usuario
                MessageBox.Show("Favor de seleccionar un producto");
            }
        }

        // 
        private void DGProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SI SE SELECCIONA UN PRODUCTO
            if (DGProductos.SelectedItems.Count == 1)
            {
                // MUESTRO LOS CAMPOS EN LA INTERFAZ GRAFICA
                productoSeleccionado = (Producto)DGProductos.SelectedItem; // SE RECUPERA EL PRODUCTO
                txtNombreProducto.Text = productoSeleccionado.Nombre; // SE ASIGNA EL NOMBRE SELECCIONADO
                txtPrecioProducto.Text = productoSeleccionado.Precio.ToString(); // SE PRECIO EL NOMBRE SELECCIONADO
            }
            else // MAS DE UN PRODUCTO
            {
                // RESETEAR CAMPOS
                productoSeleccionado = null;
                txtNombreProducto.Text = "";
                txtPrecioProducto.Text = "";
            }
        }

        // ELIMINAR
        private void buttonEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            // SE CORROBORA QUE EL PRODUCTO ESTE SELECCIONADO
            if (productoSeleccionado == null)
            {
                // SE NOTIFICA AL USUARIO
                MessageBox.Show("Favor de seleccionar un producto");
                return;
            }
            else 
            {
                // SE SELECCIONO UN OBJETO
                DBRestaurante.EliminarP(productoSeleccionado); // SE ELIMINA DE LA DB

                // SE NOTIFICA AL USUARIO
                MessageBox.Show("Se ha eliminado el producto");

                // RESETEAR CAMPOS
                productoSeleccionado = null;
                txtNombreProducto.Text = "";
                txtPrecioProducto.Text = "";
            }
        }

        // ADMINISTRACION DE EMPLEADOS
        private bool CamposEmpleadoLlenos()
        {
            if (txtNombreEmpleado.Text == "" || txtSueldoEmpleado.Text == "" || txtUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return false;
            }
            // Asegurarse que el campo precio sea un numero
            double sueldo = 0.0;
            try
            {
                sueldo = Convert.ToDouble(txtSueldoEmpleado.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorrecto");
                txtSueldoEmpleado.Text = "";
                return false;
            }
            // Asegurarse que el campo precio sea un numero positivo
            if (sueldo <= 0)
            {
                MessageBox.Show("Formato incorrecto");
                txtSueldoEmpleado.Text = "";
                return false;
            }
            return true;
        }

        private void buttonAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            // Asegurarse que todos los campos esten llenos
            if (CamposEmpleadoLlenos())
            {
                int esAdmin = 1;
                if (radioAdmin.IsChecked == false)
                    esAdmin = 0;
                DBRestaurante.AgregarE(new Empleado(txtNombreEmpleado.Text, Convert.ToDouble(txtSueldoEmpleado.Text), txtUsuario.Text, txtPassword.Text, esAdmin));
                txtNombreEmpleado.Text = "";
                txtSueldoEmpleado.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
        }

        private void txtBuscarEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Empleado> empleadosEncontrados = DBRestaurante.BuscarE(txtBuscarEmpleados.Text);
                if (empleadosEncontrados.Count < 1)
                {
                    MessageBox.Show("No se han encontrado empleados");
                    return;
                }
                DGEmpleados.ItemsSource = empleadosEncontrados;
            }
        }

        private void buttonModificarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            // Asegurarse que todos los campos esten llenos
            if (CamposEmpleadoLlenos() && empleadoSeleccionado != null)
            {
                empleadoSeleccionado.Nombre = txtNombreEmpleado.Text;
                empleadoSeleccionado.Sueldo = Convert.ToDouble(txtSueldoEmpleado.Text);
                empleadoSeleccionado.Usuario = txtUsuario.Text;
                empleadoSeleccionado.Password = txtPassword.Text;
                
                if (radioAdmin.IsChecked == true)
                    empleadoSeleccionado.EsAdmin = 1;
                else
                    empleadoSeleccionado.EsAdmin = 0;

                DBRestaurante.ModificarE(empleadoSeleccionado);

                MessageBox.Show("Se ha modificado el empleado");

                DGEmpleados.ItemsSource = null;

                txtNombreEmpleado.Text = "";
                txtSueldoEmpleado.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un empleado");
            }
        }

        private void DGEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGEmpleados.SelectedItems.Count == 1)
            {
                empleadoSeleccionado = (Empleado)DGEmpleados.SelectedItem;

                txtNombreEmpleado.Text = empleadoSeleccionado.Nombre;
                txtSueldoEmpleado.Text = empleadoSeleccionado.Sueldo.ToString();
                txtUsuario.Text = empleadoSeleccionado.Usuario;
                txtPassword.Text = empleadoSeleccionado.Password;

                // SI ES ADMINISTRADOR ASIGNA CHECKED AL ADMINISTRADOR
                if (empleadoSeleccionado.EsAdmin == 1)
                {
                    radioAdmin.IsChecked = true;
                    radioEmpleado.IsChecked = false;
                }
                else // SI NO ES ADMINISTRADOR ASIGNA CHECKED AL EMPLEADO
                {
                    radioEmpleado.IsChecked = true;
                    radioAdmin.IsChecked = false;
                }
            }
            else
            {
                empleadoSeleccionado = null;
                txtNombreEmpleado.Text = "";
                txtSueldoEmpleado.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
        }

        private void buttonEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (empleadoSeleccionado == null)
            {
                MessageBox.Show("Favor de seleccionar un empleado");
                return;
            }
            else
            {
                DBRestaurante.EliminarE(empleadoSeleccionado);
                MessageBox.Show("Se ha eliminado el empleado");
                empleadoSeleccionado = null;
                txtNombreEmpleado.Text = "";
                txtSueldoEmpleado.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
        }

        // BUSQUEDA DE FACTURAS

        private void txtBuscarFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Factura> facturasEncontradas = DBRestaurante.BuscarF(txtBuscarFactura.Text);
                if (facturasEncontradas.Count < 1)
                {
                    MessageBox.Show("No se han encontrado facturas");
                    return;
                }
                DGFacturas.ItemsSource = facturasEncontradas;
            }
        }
    }
}

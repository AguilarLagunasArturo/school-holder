using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PuntoDeVenta
{
    /// <summary>
    /// Lógica de interacción para WProductos.xaml
    /// </summary>
    public partial class WProductos : Window
    {
        // Variables gobales
        public Cliente cliente;
        public List<Producto> productos;
        public int cantidad;
        public WProductos(Cliente cliente)
        {
            InitializeComponent();

            // Se inicializan las variables globales
            this.cliente = cliente;
            labelCliente.Content = cliente.Nombre;
            
            // Se agregan los productos disponibles
            productos = new List<Producto>();
            productos.Add(new Producto("Arduino Nano", "Microcontrolador", 140.0));
            productos.Add(new Producto("Audífonos Bluetooth", "Marca Jecoo", 399.0));
            productos.Add(new Producto("Audífonos Gaming", "HyperX Cloud Stinger Core", 659.0));
            productos.Add(new Producto("Micrófono USB", "HyperX QuadCast", 2999.0));
            productos.Add(new Producto("MPU-6050", "Acelerometro y giroscopio", 75.0));
            productos.Add(new Producto("Transistor 2n2222", "Dispositivo semiconductor", 3.0));

            // Se refresca el componente ComboBox
            comboProductos.ItemsSource = productos;
            comboProductos.Items.Refresh();
            comboProductos.DisplayMemberPath = "Nombre";
            cantidad = 1;

            // Se actualizan los datos del cliente
            labelPresupuesto.Content = "$ " + cliente.Presupuesto.ToString();
            labelPrecioCantidadNumerica.Content = "$ 0";
            labelCambio.Content = "$ " + (cliente.Presupuesto - cliente.Total()).ToString();
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

        // Boton para finalizar compra
        private void buttonFinalizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias por su compra.");
            MainWindow.clientes.Add(cliente);
            Close();
        }

        // Boton para agregar al carrito de compra
        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            // Se recupera el producto seleccionado
            Producto productoSeleccionado = (Producto) comboProductos.SelectedItem;
            
            // Se asegura que se haya seleccionado un producto antes de continuar
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto antes de agregar.");
            }
            else
            {
                // Se recupera la cantidad de productos que el usuario desea comprar
                int cantidad = Convert.ToInt32(labelCantidad.Content);

                // Se asegura de que le alcance el dinero al usuario
                if (cliente.Total() + (productoSeleccionado.Precio * cantidad) > cliente.Presupuesto)
                    MessageBox.Show("Su presupuesto no le alcanza para agregar al carrito de compras.");
                else
                {
                    // Se agrega la cantidad n de productos seleccionados
                    for (int i = 0; i < cantidad; i++)
                        cliente.Productos.Add(productoSeleccionado);
                    // Se actualizan los datos del cliente
                    scrollProductos.Content = cliente.Factura();
                    scrollProductos.ScrollToEnd();
                    labelCambio.Content = "$ " + (cliente.Presupuesto - cliente.Total()).ToString();
                    if ((cliente.Presupuesto - productoSeleccionado.Precio * cantidad - cliente.Total()) < 0)
                        labelPrecioCantidadNumerica.Foreground = Brushes.Red;
                    else
                        labelPrecioCantidadNumerica.Foreground = Brushes.Black;
                }
            }
        }

        // Boton para eliminar productos agregados
        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Se recupera el producto seleccionado
            Producto productoSeleccionado = (Producto)comboProductos.SelectedItem;

            // Se asegura que el producto se haya seleccionado
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto antes de quitarlo.");
            }
            else
            {
                // Se agrega la cantidad N de productos seleccionados
                for (int i = 0; i < Convert.ToInt32(labelCantidad.Content); i++)
                    cliente.Productos.Remove(productoSeleccionado);
                // Se actualizan los datos del cliente
                scrollProductos.Content = cliente.Factura();
                scrollProductos.ScrollToEnd();
                labelCambio.Content = "$ " + (cliente.Presupuesto - cliente.Total()).ToString();
                if ((cliente.Presupuesto - productoSeleccionado.Precio * cantidad - cliente.Total()) < 0)
                    labelPrecioCantidadNumerica.Foreground = Brushes.Red;
                else
                    labelPrecioCantidadNumerica.Foreground = Brushes.Black;
            }
        }

        // Boton decremento para cantidad de productos
        private void buttonDecremento_Click(object sender, RoutedEventArgs e)
        {
            // No permitir una cantidad menor a 1
            if (cantidad == 1)
                return;
            // Se decrementa la cantidad
            cantidad -= 1;
            labelCantidad.Content = cantidad;
            labelPrecioCantidad.Content = "Precio (x" + cantidad.ToString() + ")";
            // Si ya hay un producto seleccionado
            if (labelPrecioCantidadNumerica.Content.ToString() != "$ 0")
            {
                // Actualizar datos del producto
                Producto productoSeleccionado = (Producto)comboProductos.SelectedItem;
                labelPrecioCantidadNumerica.Content = "$ " + (productoSeleccionado.Precio * cantidad).ToString();
                if ((cliente.Presupuesto - productoSeleccionado.Precio * cantidad - cliente.Total()) < 0)
                    labelPrecioCantidadNumerica.Foreground = Brushes.Red;
                else
                    labelPrecioCantidadNumerica.Foreground = Brushes.Black;
            }

        }

        // Boton incremento para cantidad de productos
        private void buttonIngremento_Click(object sender, RoutedEventArgs e)
        {
            // No permitir un valor mayor a 10
            if (cantidad == 10)
                return;
            // Se incrementa la cantidad
            cantidad += 1;
            labelCantidad.Content = cantidad;
            labelPrecioCantidad.Content = "Precio (x" + cantidad.ToString() + ")";
            // Si ya hay un producto seleccionado
            if (labelPrecioCantidadNumerica.Content.ToString() != "$ 0")
            {
                // Actualizar datos del producto
                Producto productoSeleccionado = (Producto)comboProductos.SelectedItem;
                labelPrecioCantidadNumerica.Content = "$ " + (productoSeleccionado.Precio * cantidad).ToString();
                if ((cliente.Presupuesto - productoSeleccionado.Precio * cantidad - cliente.Total()) < 0)
                    labelPrecioCantidadNumerica.Foreground = Brushes.Red;
                else
                    labelPrecioCantidadNumerica.Foreground = Brushes.Black;
            }
        }

        // Seleccion de ComboBox cambio
        private void comboProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtener producto seleccionado
            Producto productoSeleccionado = (Producto) comboProductos.SelectedItem;
            // Actualizar datos del producto
            labelPrecio.Content = "$ " + productoSeleccionado.Precio.ToString();
            labelPrecioCantidad.Content = "Precio (x" + cantidad.ToString() + ")";
            labelPrecioCantidadNumerica.Content = "$ " + (productoSeleccionado.Precio * cantidad).ToString();
            if ((cliente.Presupuesto - productoSeleccionado.Precio * cantidad - cliente.Total()) < 0)
                labelPrecioCantidadNumerica.Foreground = Brushes.Red;
            else
                labelPrecioCantidadNumerica.Foreground = Brushes.Black;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("./src/productos/" + productoSeleccionado.Nombre + ".jpg", UriKind.Relative);
            bi3.EndInit();
            imgProducto.Source = bi3;
        }
    }
}

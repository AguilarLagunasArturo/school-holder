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

namespace Banco
{
    /// <summary>
    /// Lógica de interacción para WAdmin.xaml
    /// </summary>
    public partial class WAdmin : Window
    {
        public WAdmin()
        {
            InitializeComponent();

            // Se inicializan componentes
            comboCuenta.ItemsSource = new List<string>() { "Debito", "Credito" };
            comboCuenta.SelectedIndex = 0;

            comboBusqueda.ItemsSource = new List<string>() { "Nombre", "No. Cuenta" };
            comboBusqueda.SelectedIndex = 0;
        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            // Se asegura que todos los campos esten llenos
            if (textCalle.Text == "" || textCodigoPostal.Text == "" 
                || textNombre.Text == "" || textLocalidad.Text == ""
                || textColonia.Text == "" || textNumero.Text == ""
                || textSaldo.Text == "" || textNip.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // Se asegura que el campo saldo tenga el formato correcto
            double saldo;
            try
            {
                saldo = Convert.ToDouble(textSaldo.Text);
            }
            catch
            {
                MessageBox.Show("El campo saldo solo acepta numeros");
                textSaldo.Text = "";
                return;
            }

            if (saldo <= 0)
            {
                MessageBox.Show("El saldo debe ser un valor positivo");
                textSaldo.Text = "";
                return;
            }

            // Se asegura que el NIP tenga el formato correcto
            string nip = textNip.Text;
            int nipAux;
            try
            {
                nipAux = Convert.ToInt32(nip);
            }
            catch
            {
                MessageBox.Show("El NIP debe ser un numero entero");
                textNip.Text = "";
                return;
            }
            if (nipAux < 0)
            {
                MessageBox.Show("El NIP debe ser un numero entero");
                textNip.Text = "";
                return;
            }

            // Se recuperan los campos de texto
            string tipoCuenta = comboCuenta.SelectedItem.ToString();
            string nombreUsuario = textNombre.Text;
            string noCuenta = nombreUsuario.Replace(" ", "+");
            
            // Se crea la cuenta de Debito o Credito
            if (tipoCuenta == "Debito")
            {
                noCuenta = "d+" + noCuenta.ToLower();
                MainWindow.cuentas.Add(new CuentaDebito(
                    noCuenta,
                    new Cliente(
                        nombreUsuario,
                        textCalle.Text,
                        textCodigoPostal.Text,
                        textColonia.Text,
                        textLocalidad.Text,
                        textNumero.Text
                        ),
                    nip,
                    saldo
                    ));
            }
            else
            {
                noCuenta = "c+" + noCuenta.ToLower();
                MainWindow.cuentas.Add( new CuentaCredito(
                    noCuenta,
                    new Cliente(
                        nombreUsuario,
                        textCalle.Text,
                        textCodigoPostal.Text,
                        textColonia.Text,
                        textLocalidad.Text,
                        textNumero.Text
                        ),
                    nip,
                    saldo
                    ));
            }

            // Se informa al administrador el numero de cuenta
            MessageBox.Show(String.Format(
                "Se ha agregado un cliente\n\nNo. Cuenta:\t{0}\nNIP:\t\t{1}\nTipo de Cuenta:\t{2}",
                noCuenta,
                nip,
                tipoCuenta)
            );

            // Se vacian los campos para generar un nuevo cliente
            textNombre.Text = "";
            textCalle.Text = "";
            textCodigoPostal.Text = "";
            textColonia.Text = "";
            textLocalidad.Text = "";
            textNumero.Text = "";
            textSaldo.Text = "";
            textNip.Text = "";
        }

        // Se crea una lista de cuentas auxiliar
        List<Cuenta> aux;
        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar la letra enter en el buscador
            if (e.Key == Key.Return)
            {
                // Se recupera el texto del buscador
                string buscar = textBuscar.Text;

                // Se determina que tipo de busqueda efectuar
                if (comboBusqueda.SelectedItem.ToString() == "Nombre")
                    aux = MainWindow.cuentas.FindAll(c => c.Cliente.Nombre.Contains(buscar));
                else
                    aux = MainWindow.cuentas.FindAll(c => c.Numero.Contains(buscar));

                // Se actualizan los datos en el componente DataGrid
                dGConsulta.DataContext = aux;
            }
        }

        private void buttonFinalizar_Click(object sender, RoutedEventArgs e)
        {
            // Boton finalizar cierra la ventana
            Close();
        }

        private void comboCuenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = comboCuenta.SelectedItem.ToString();
            if (item.Equals("Debito"))
                labelSaldo.Content = "Saldo";
            else
                labelSaldo.Content = "Limite de credito";
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Se recupera la cuenta a eliminar
            Cuenta c = (Cuenta)dGConsulta.SelectedItem;

            // Se asegura que no sea un valor nulo
            if (c == null)
            {
                MessageBox.Show("Seleccione la cuenta a eliminar");
                return;
            }

            // Se elimina la cuenta seleccionada
            MainWindow.cuentas.Remove(c);
            aux.Remove(c);

            // Se actializa el elemento DataGrid
            dGConsulta.DataContext = null;
            dGConsulta.DataContext = aux;

            // Se informa al admin
            MessageBox.Show(String.Format("Se ha eliminado la cuenta:\n\nNumero:\t{0}\nNIP:\t{1}", c.Numero, c.Nip));
        }

        private void buttonConsultaTodo_Click(object sender, RoutedEventArgs e)
        {
            // Se consultan todas las cuentas registradas
            aux = MainWindow.cuentas;

            // Se actualiza el contenido de DataGrid
            dGConsulta.DataContext = null;
            dGConsulta.DataContext = aux;
        }
    }
}

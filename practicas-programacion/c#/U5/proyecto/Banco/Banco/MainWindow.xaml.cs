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

namespace Banco
{
   
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Cuenta> cuentas;

        public MainWindow()
        {
            InitializeComponent();
            cuentas = new List<Cuenta>();
        }

        private void buttonIngresar_Click(object sender, RoutedEventArgs e)
        {
            // Se asegura que todos los campos esten llenos
            if (!(textNoCuenta.Text != "" && pass.Password != ""))
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            string usuario = textNoCuenta.Text;
            string password = pass.Password;

            // Se crea la ventana correspondiente
            if (radioAdmin.IsChecked == true)
            {
                if (! (usuario.Equals("root") && password.Equals("pass")))
                {
                    textNoCuenta.Text = "";
                    pass.Password = "";
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    return;
                }
                WAdmin v = new WAdmin();
                v.ShowDialog();
            }
            else
            {
                usuario= textNoCuenta.Text;
                password = pass.Password;

                WUsuario v = null;
                foreach (Cuenta c in cuentas)
                {
                    if (c.Numero.Equals(usuario) && c.Nip.Equals(password))
                    {
                        v = new WUsuario(c);
                    }
                }

                textNoCuenta.Text = "";
                pass.Password = "";

                if (v == null)
                {
                    MessageBox.Show("Numero de cuenta o NIP incorrectos");
                    return;
                }

                v.ShowDialog();
            }
        }

        private void radioAdmin_Checked(object sender, RoutedEventArgs e)
        {
            // Se inicializan labels
            labelUsuario.Content = "Nombre de usuario:";
            labelPass.Content = "Contraseña:";
            textNoCuenta.Text = "root";
            pass.Password = "pass";
        }

        private void radioCliente_Checked(object sender, RoutedEventArgs e)
        {
            // Se inicializan labels
            if (labelUsuario != null)
                labelUsuario.Content = "No. Cuenta:";
            if (labelPass != null)
                labelPass.Content = "NIP:";
            if (textNoCuenta != null)
                textNoCuenta.Text = "";
            if (pass != null)
                pass.Clear();
        }
    }
}

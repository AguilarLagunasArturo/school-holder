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

namespace Restaurante
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBRestaurante.DBConectar(); // SE CONECTA A LA DB
        }

        private void buttonIngresar_Click(object sender, RoutedEventArgs e)
        {
            // NECESITAMOS CHECAR SI EL USUARIO ES VALIDO
            List<Empleado> empleadosEncontrados = DBRestaurante.BuscarUsuario(txtUsuario.Text);

            // BUSCAR QUE EL EMPLEADO Y PASSWORD COINCIDAN
            Empleado empleado = null;
            foreach (Empleado emp in empleadosEncontrados)
            {
                if (emp.Password.Equals(pass.Password))
                {
                    empleado = emp;
                    break;
                }
            }
            // SI NO COINCIDEN INFORMAR AL USUARIO
            if (empleado == null)
            {
                MessageBox.Show("No hay empleados con ese usuario o password");
                txtUsuario.Text = "";
                pass.Password = "";
                return;
            }

            // ENTRAR A VENTANA CORRESPONDIENTE
            if (rbEsAdmin.IsChecked == true)
            {
                // EMPLEADO NO CUENTA CON PERMISOS DE ADMINISTRADOR NO PUEDE ENTRAR
                if (empleado.EsAdmin == 0)
                {
                    MessageBox.Show("El empleado no tiene permisos de administrador");
                    txtUsuario.Text = "";
                    pass.Password = "";
                    return; // RETURN -> NO CONTINUA EJECUTANDO CODIGO
                }
                // ENTRA A LA VENTANA ADMINISTRADOR
                WAdministrador ventanaAdmin = new WAdministrador();
                ventanaAdmin.ShowDialog();
            }
            else
            {
                // ENTRA A LA VENTANA EMPLEADO
                WEmpleado ventanaEmpleado = new WEmpleado(empleado);
                ventanaEmpleado.ShowDialog();
            }
        }

        // CERRAR
        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

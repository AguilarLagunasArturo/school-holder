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
    /// Lógica de interacción para WUsuario.xaml
    /// </summary>
    public partial class WUsuario : Window
    {
        private Cuenta cuenta;
        private Boolean a = false;
        private List<string> operaciones = new List<string>() { "Deposito", "Retiro", "Pago de servicio" };


    public WUsuario(Cuenta cuenta)
        {
            InitializeComponent();
            this.a = true;
            this.cuenta = cuenta;
            labelNombre.Content = cuenta.Cliente.Nombre;
            labelNoCuenta.Content = cuenta.Numero;
            labelSaldo.Content = cuenta.Saldo;

            comboConsulta.ItemsSource = operaciones;
            comboConsulta.SelectedIndex = 0;
        }

        // Se cierra la ventana
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // DEPOSITO a cuenta identificada con el numero de cuenta
        private void btnDepositar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDeposito.Text == "" || txtNoCuenta.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            if (txtNoCuenta.Text.ElementAt(0) == 'c')
            {
                MessageBox.Show("No se puede depositar a una cuenta de credito");
                txtNoCuenta.Text = "";
                txtDeposito.Text = "";
                return;
            }
                
            double deposito;
            try
            {
                deposito = Convert.ToDouble(txtDeposito.Text);
            }
            catch
            {
                MessageBox.Show("El monto debe ser un numero positivo");
                txtDeposito.Text = "";
                return;
            }

            if (deposito > cuenta.Saldo)
            {
                MessageBox.Show(String.Format("Saldo insuficiente para depositar ${0}", deposito));
                txtDeposito.Text = "";
                return;
            }

            if (deposito <= 0)
            {
                MessageBox.Show(String.Format("Formato invalido ${0}", deposito));
                txtDeposito.Text = "";
                return;
            }


            Boolean aux = false;

            //Se busca en la lista la cuenta a depositar y se realiza el deposito
            foreach (Cuenta c in MainWindow.cuentas)
            {
                if (c.Numero == txtNoCuenta.Text)
                {
                    cuenta.Depositar(-deposito);
                    cuenta.Operaciones[cuenta.Operaciones.Count - 1].Descripcion = "Has realizado un deposito";
                    c.Depositar(deposito);
                    c.Operaciones[c.Operaciones.Count - 1].Descripcion = "Te han depositado";
                    labelSaldo.Content = cuenta.Saldo;
                    aux = true;
                    break;
                }
            }
            if (aux == false)
                MessageBox.Show(String.Format("No se encontró el número de cuenta {0} en el registro", txtNoCuenta.Text));
            else
            {
                labelSaldo.Content = cuenta.Saldo.ToString();
                MessageBox.Show(String.Format("Se han depositado ${0} al número de cuenta {1}", deposito, txtNoCuenta.Text));
            }

            txtNoCuenta.Text = "";
            txtDeposito.Text = "";
        }

        private void btnPagoServicio_Click(object sender, RoutedEventArgs e)
        {
            // Se asegura que los campos esten llenos
            if (txtMontoServicio.Text == "" || txtServicio.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // Se asegura que tengan el formato correcto
            double monto;
            try
            {
                monto = Convert.ToDouble(txtMontoServicio.Text);
            }
            catch
            {
                MessageBox.Show("El monto debe ser un numero positivo");
                txtMontoServicio.Text = "";
                return;
            }

            if (monto > cuenta.Saldo)
            {
                MessageBox.Show(String.Format("Saldo insuficiente para pagar servicio ${0}", monto));
                txtMontoServicio.Text = "";
                return;
            }

            if(monto <= 0)
            {
                MessageBox.Show(String.Format("Formato invalido ${0}", monto));
                txtMontoServicio.Text = "";
                return;
            }

            // Se paga el servicio
            cuenta.PagoServicio(monto, txtServicio.Text);
            labelSaldo.Content = cuenta.Saldo;
            txtMontoServicio.Text = "";
            txtServicio.Text = "";
            MessageBox.Show("Se ha pagado el servicio");
        }

        private void btnRetirar_Click(object sender, RoutedEventArgs e)
        {
            // Se asegura que los campos esten llenos
            if (txtRetiro.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // Se asegura que tengan el formato correcto
            double retiro;
            try
            {
                retiro = Convert.ToDouble(txtRetiro.Text);
            }
            catch
            {
                MessageBox.Show("El monto debe ser un numero positivo");
                txtRetiro.Text = "";
                return;
            }

            if (retiro > cuenta.Saldo)
            {
                MessageBox.Show(String.Format("Saldo insuficiente para retirar ${0}", retiro));
                txtRetiro.Text = "";
                return;
            }

            if (retiro <= 0)
            {
                MessageBox.Show(String.Format("Formato invalido ${0}", retiro));
                txtRetiro.Text = "";
                return;
            }

            cuenta.Retirar(retiro);
            cuenta.Operaciones[cuenta.Operaciones.Count - 1].Descripcion = "Has realizado un retiro";
            labelSaldo.Content = cuenta.Saldo;
            MessageBox.Show(String.Format("Se han retirado ${0}", retiro));
            txtRetiro.Text = "";
        }

        private void comboConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dGConsulta.DataContext = null;
            foreach (string o in operaciones)
            {
                if (comboConsulta.SelectedItem.ToString() == o)
                    dGConsulta.DataContext = cuenta.Operaciones.FindAll(op => op.Tipo.Equals(o));
            }
        }
    }
}
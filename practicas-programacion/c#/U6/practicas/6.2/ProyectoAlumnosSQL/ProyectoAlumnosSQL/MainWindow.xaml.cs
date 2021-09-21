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

namespace ProyectoAlumnosSQL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBAlumnos.DBConectar();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtMateria.Text == "" || txtCalificacion.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            Alumno alumno = new Alumno();

            alumno.Nombre = txtNombre.Text;
            alumno.Materia = txtMateria.Text;
            try
            {
                alumno.Calificacion = Convert.ToInt32(txtCalificacion.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorrecto en calificacion");
                txtCalificacion.Text = "";
                return;
            }

            if (alumno.Calificacion < 0 || alumno.Calificacion > 100)
            {
                MessageBox.Show("La calificacion enta fuera del rango [0 - 100]");
                txtCalificacion.Text = "";
                return;
            }

            DBAlumnos.Agregar(alumno);

            txtNombre.Text = "";
            txtMateria.Text = "";
            txtCalificacion.Text = "";
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            WConsulta w = new WConsulta();
            w.ShowDialog();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

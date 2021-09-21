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

namespace ProyectoAlumnosSQL
{
    /// <summary>
    /// Lógica de interacción para WConsulta.xaml
    /// </summary>
    public partial class WConsulta : Window
    {
        public static Alumno alumnoSeleccionado = null;

        public WConsulta()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Alumno> alumnosEncontrados = DBAlumnos.BuscarAlumno(txtBuscarNombre.Text);
                if (alumnosEncontrados.Count < 1)
                {
                    MessageBox.Show("No se han encontrado alumnos");
                    return;
                }
                DGAlumnos.ItemsSource = alumnosEncontrados.OrderBy(a => a.Nombre);
            }

        }

        private void DGAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGAlumnos.SelectedItems.Count == 1)
            {
                alumnoSeleccionado = (Alumno)DGAlumnos.SelectedItem;
                txtNombre.Text = alumnoSeleccionado.Nombre;
                txtMateria.Text = alumnoSeleccionado.Materia;
                txtCalificacion.Text = alumnoSeleccionado.Calificacion.ToString();
            }
            else
            {
                txtNombre.Text = ""; txtMateria.Text = ""; txtCalificacion.Text = "";
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtMateria.Text == "" || txtCalificacion.Text == "")
            {
                MessageBox.Show("Favor de seleccionar un alumno");
                return;
            }

            alumnoSeleccionado.Nombre = txtNombre.Text;
            alumnoSeleccionado.Materia = txtMateria.Text;
            alumnoSeleccionado.Calificacion = Convert.ToInt32(txtCalificacion.Text);
            DBAlumnos.Modificar(alumnoSeleccionado);

            MessageBox.Show("Se ha modificado el alumno");

            DGAlumnos.ItemsSource = null;
            txtNombre.Text = ""; txtMateria.Text = ""; txtCalificacion.Text = "";

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtMateria.Text == "" || txtCalificacion.Text == "")
            {
                MessageBox.Show("Favor de seleccionar un alumno");
                return;
            }

            DBAlumnos.Eliminar(alumnoSeleccionado);
            MessageBox.Show("Se ha eliminado el alumno");

            DGAlumnos.ItemsSource = null;
            txtNombre.Text = ""; txtMateria.Text = ""; txtCalificacion.Text = "";
        }
    }
}

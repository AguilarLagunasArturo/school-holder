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

namespace Ventanas
{
    /// <summary>
    /// Lógica de interacción para wConsulta.xaml
    /// </summary>
    public partial class wConsulta : Window
    {
        Alumno a;
        public wConsulta(Alumno a)
        {
            InitializeComponent();
            this.a = a;
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void labelNombre_Loaded(object sender, RoutedEventArgs e)
        {
            labelNombre.Content = a.Nombre;
        }

        private void labelCalificacion_Loaded(object sender, RoutedEventArgs e)
        {
            labelCalificacion.Content = a.Calificacion.ToString();
        }
    }
}

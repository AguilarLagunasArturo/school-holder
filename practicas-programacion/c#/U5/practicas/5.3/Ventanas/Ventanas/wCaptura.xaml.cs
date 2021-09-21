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
    /// Lógica de interacción para wCaptura.xaml
    /// </summary>
    public partial class wCaptura : Window
    {
        
        public wCaptura()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.alumnos.Add(new Alumno(textNombre.Text, Convert.ToDouble(textCalificacion.Text)));
            Close();
        }
    }
}

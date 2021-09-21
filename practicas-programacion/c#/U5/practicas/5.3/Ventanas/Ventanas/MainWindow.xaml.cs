using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ventanas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Alumno> alumnos;
        public MainWindow()
        {
            InitializeComponent();
            alumnos = new List<Alumno>();
            comboAlumnos.ItemsSource = alumnos;
        }

        private void buttonRegistro_Click(object sender, RoutedEventArgs e)
        {
            
            wCaptura vCaptura = new wCaptura();
            vCaptura.ShowDialog();
            comboAlumnos.Items.Refresh();
            comboAlumnos.DisplayMemberPath = "Nombre";
        }

        private void comboAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wConsulta v = new wConsulta((Alumno) comboAlumnos.SelectedItem);
            v.ShowDialog();
        }
    }
}

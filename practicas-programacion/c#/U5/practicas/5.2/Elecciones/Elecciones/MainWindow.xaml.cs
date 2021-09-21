using System.Windows;

namespace Elecciones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        Partido bronco = new Partido("Bronco");
        Partido morena = new Partido("Morena");
        Partido pan = new Partido("PAN");

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = "Partido: ";

            if (radioBronco.IsChecked == true)
            {
                mensaje += "Bronco\n";
                bronco.Votos += 1;
                mensaje += "Genero: ";

                if (radioFemenino.IsChecked == true)
                {
                    mensaje += "Femenino\n";
                    bronco.VotosFemenino += 1;
                }
                else if (radioMasculino.IsChecked == true)
                {
                    mensaje += "Masculino\n";
                    bronco.VotosMasculino += 1;
                }
            } else if (radioMorena.IsChecked == true)
            {
                mensaje += "Morena\n";
                morena.Votos += 1;
                mensaje += "Genero: ";

                if (radioFemenino.IsChecked == true)
                {
                    mensaje += "Femenino\n";
                    morena.VotosFemenino += 1;
                }
                else if (radioMasculino.IsChecked == true)
                {
                    mensaje += "Masculino\n";
                    morena.VotosMasculino += 1;
                }
            } else if (radioPan.IsChecked == true)
            {
                mensaje += "PAN\n";
                pan.Votos += 1;
                mensaje += "Genero: ";

                if (radioFemenino.IsChecked == true)
                {
                    mensaje += "Femenino\n";
                    pan.VotosFemenino += 1;
                }
                else if (radioMasculino.IsChecked == true)
                {
                    mensaje += "Masculino\n";
                    pan.VotosMasculino += 1;
                }
            }

            if (checkLicenciatura.IsChecked == true)
            {
                mensaje += "\nLicenciatura\n";
            }

            if (checkMayoresDeCuarenta.IsChecked == true)
            {
                mensaje += "\nMayor de 40 años\n";
            }

            if (radioPorcentajeTodos.IsChecked == true)
            {
                int votos = pan.Votos + morena.Votos + bronco.Votos;
                progress1.Value = bronco.Porcentaje(votos);
                progress2.Value = morena.Porcentaje(votos);
                progress3.Value = pan.Porcentaje(votos);
            }
            else if (radioPorcentajeFemenino.IsChecked == true)
            {
                int votosFemeninos = pan.VotosFemenino + morena.VotosFemenino + bronco.VotosFemenino;
                progress1.Value = bronco.PorcentajeFemenino(votosFemeninos);
                progress2.Value = morena.PorcentajeFemenino(votosFemeninos);
                progress3.Value = pan.PorcentajeFemenino(votosFemeninos);
            }
            else if (radioPorcentajeMasculino.IsChecked == true)
            {
                int votosMasculinos = pan.VotosMasculino + morena.VotosMasculino + bronco.VotosMasculino;
                progress1.Value = bronco.PorcentajeMasculino(votosMasculinos);
                progress2.Value = morena.PorcentajeMasculino(votosMasculinos);
                progress3.Value = pan.PorcentajeMasculino(votosMasculinos);
            }

            MessageBox.Show(mensaje);
        }

        private void radioPorcentajeTodos_Checked(object sender, RoutedEventArgs e)
        {
            int votos = pan.Votos + morena.Votos + bronco.Votos;
            progress1.Value = bronco.Porcentaje(votos);
            progress2.Value = morena.Porcentaje(votos);
            progress3.Value = pan.Porcentaje(votos);
        }

        private void radioPorcentajeFemenino_Checked(object sender, RoutedEventArgs e)
        {
            int votosFemeninos = pan.VotosFemenino + morena.VotosFemenino + bronco.VotosFemenino;
            progress1.Value = bronco.PorcentajeFemenino(votosFemeninos);
            progress2.Value = morena.PorcentajeFemenino(votosFemeninos);
            progress3.Value = pan.PorcentajeFemenino(votosFemeninos);
        }

        private void radioPorcentajeMasculino_Checked(object sender, RoutedEventArgs e)
        {
            int votosMasculinos = pan.VotosMasculino + morena.VotosMasculino + bronco.VotosMasculino;
            progress1.Value = bronco.PorcentajeMasculino(votosMasculinos);
            progress2.Value = morena.PorcentajeMasculino(votosMasculinos);
            progress3.Value = pan.PorcentajeMasculino(votosMasculinos);
        }
    }
}

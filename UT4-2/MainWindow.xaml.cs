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

namespace UT4_2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Superheroe> heroesLista = new List<Superheroe>();
        private int posLista;
        public MainWindow()
        {
            InitializeComponent();
            heroesLista = Superheroe.GetSamples();
            datosTab.DataContext = heroesLista[0];
            posLista = 1;
            totalTextBlock.Text =posLista +"/" + heroesLista.Count.ToString();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ((posLista+1) <= heroesLista.Count)
            {         
                posLista++;
                datosTab.DataContext = heroesLista[(posLista-1)];
                totalTextBlock.Text = posLista +"/"+ heroesLista.Count;
            }
            else MessageBox.Show("Error, no hay más héroes/villanos");
            
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if ((posLista-1) != 0)
            {
                posLista--;
                datosTab.DataContext = heroesLista[(posLista-1)];
                totalTextBlock.Text = posLista + "/" + heroesLista.Count;
            }
            else MessageBox.Show("Error, no hay más héroes/villanos");
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Superheroe heroe = new Superheroe();
            heroe.Nombre = heroenombreTextBox.Text;
            heroe.Imagen = imagenTextBox.Text;
            if ((bool)heroeRadio.IsChecked)
            {
                heroe.Heroe = true;
                heroe.Villano = false;
                if ((bool)vengadorCheckBox.IsChecked)
                {
                    heroe.Vengador = true;
                } else { heroe.Vengador = false; }
                if ((bool)xmenCheckBox.IsChecked)
                {
                    heroe.Xmen = true;
                } else { heroe.Xmen = false; }
                
            }
            else { heroe.Heroe = false; heroe.Villano = true; }

            heroesLista.Add(heroe);
            posLista = 1;
            totalTextBlock.Text = posLista + "/" + heroesLista.Count.ToString();
            MessageBox.Show("¡Superhéroe insertado con exito!", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            limpiartodo();
        }

        private void limpiartodo()
        {
            heroenombreTextBox.Clear();
            imagenTextBox.Clear();
            vengadorCheckBox.IsChecked = false;
            xmenCheckBox.IsChecked = false;
            heroeRadio.IsChecked = true;
        }
        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiartodo();
        }

        private void villanoRadio_Checked(object sender, RoutedEventArgs e)
        {
            vengadorCheckBox.IsEnabled = false;
            xmenCheckBox.IsEnabled = false;
            vengadorCheckBox.IsChecked = false;
            xmenCheckBox.IsChecked = false;
        }

        private void villanoRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            vengadorCheckBox.IsEnabled = true;
            xmenCheckBox.IsEnabled = true;
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Tamagochi_Layouts
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        MainWindow padre;
        private MediaPlayer mediaPlayer = new MediaPlayer();


        public Window1(MainWindow padre)
        {
            string path = Directory.GetCurrentDirectory();

            mediaPlayer.Open(new Uri(path + "/Audios/Marvel Opening Theme.m4a"));
            mediaPlayer.Play();

            InitializeComponent();
            mediaPlayer.Volume = 1;


            this.padre = padre;
            eventoBienvenida();

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path + "/Fotos/gif capi.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gifCapi, image);

            var image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(path + "/Fotos/capi bienvenida.gif");
            image2.EndInit();
            ImageBehavior.SetAnimatedSource(capiCentrado, image2);
        }

        private async void enviarNombreAsync(object sender, RoutedEventArgs e)
        {
            if (txtBoxNombre.Text == "")
            {
                MessageBox.Show("!El Capitán América quiere saber quién será su cuidador!", "Campo nombre vacío", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                padre.setNombre(txtBoxNombre.Text);
                capiCentrado.Visibility = Visibility.Hidden;
                gifCapi.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                mediaPlayer.Stop();
                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.enviarNombreAsync(sender, e);
        }

        private void eventoBienvenida()
        {
            Storyboard bienvenida = (Storyboard)this.Resources["Bienvenida"];
            bienvenida.Begin();
        }
    }
}

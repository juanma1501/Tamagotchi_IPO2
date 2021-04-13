using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace Tamagochi_Layouts
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string nombre;
        private string ruta = Directory.GetCurrentDirectory();
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private MediaPlayer mediaAnimaciones = new MediaPlayer();
        private DispatcherTimer t1;
        private DispatcherTimer t2;
        private DispatcherTimer t3;
        private DispatcherTimer seg;
        private DispatcherTimer min;
        private DispatcherTimer general;
        private int incremento = 10;
        private int decremento = 5;
        private int puntos = 0;
        private int comer_ = 0;
        private Boolean botonOculto_ = true;
        private Boolean ojo = true;
        private Boolean primera_prenda = true;
        private Boolean primer_credito = true;
        OleDbConnection conexion;
        OleDbCommand sentencia;

        public MainWindow()
        {
            InitializeComponent();
            Window1 bienvenida = new Window1(this);
            bienvenida.ShowDialog();
            mediaAnimaciones.Volume = 1;

            establecerConexion();
            leerBBDD();

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(10000);
            t1.Tick += new EventHandler(energia);
            t1.Start();

            t2 = new DispatcherTimer();
            t2.Interval = TimeSpan.FromMilliseconds(15000);
            t2.Tick += new EventHandler(alimentacion);
            t2.Start();

            t3 = new DispatcherTimer();
            t3.Interval = TimeSpan.FromMilliseconds(20000);
            t3.Tick += new EventHandler(diversion);
            t3.Start();

            seg = new DispatcherTimer();
            seg.Interval = TimeSpan.FromMilliseconds(15000);
            seg.Tick += new EventHandler(sobrevive15seg);
            seg.Start();

            min = new DispatcherTimer();
            min.Interval = TimeSpan.FromMilliseconds(60000);
            min.Tick += new EventHandler(sobrevive1min);
            min.Start();

            general = new DispatcherTimer();
            general.Interval = TimeSpan.FromMilliseconds(1000);
            general.Tick += new EventHandler(tiempoGeneral);
            general.Start();

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/predeterminado.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgFondo, image);

            var image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(ruta + "/Fotos/zzz.gif");
            image2.EndInit();
            ImageBehavior.SetAnimatedSource(gifDormir, image2);

            mediaPlayer.Volume = 1;
            mediaPlayer.Open(new Uri(ruta + "/Audios/animal.mp3"));
            mediaPlayer.Play();

        }

        private void establecerConexion()
        {
            conexion = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ruta + "/Puntuaciones.accdb");
            conexion.Open();
        }

        private void leerBBDD()
        {
            sentencia = conexion.CreateCommand();
            sentencia.CommandText = "SELECT (SELECT COUNT(*) FROM Puntuaciones AS T1 WHERE T1.Puntos >= T2.Puntos) AS Posicion, Nombre, Puntos, Fecha FROM Puntuaciones AS T2 ORDER BY Puntos DESC";
            sentencia.Connection = conexion;
            OleDbDataReader rd = sentencia.ExecuteReader();
            gridRanking.ItemsSource = rd;
        }

        private void alimentacion(object sender, EventArgs e)
        {
            this.barraComer.Value -= decremento;
            if (this.barraComer.Value <= 0)
            {
                morir();
            }

        }

        private void tiempoGeneral(object sender, EventArgs e)
        {
            puntos += 1;
            lblPuntos.Content = "PUNTOS " + puntos;
        }

        private void diversion(object sender, EventArgs e)
        {
            this.barraJugar.Value -= decremento;
            if (this.barraJugar.Value <= 0)
            {
                morir();
            }
        }

        private void energia(object sender, EventArgs e)
        {
            this.barraEnergia.Value -= decremento;
            if (this.barraEnergia.Value <= 0)
            {
                morir();
            }
        }

        private void cambiar_fondo(object sender, MouseButtonEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/halloween.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgFondo, image);
        }

        private void eventoDescansar(object sender, RoutedEventArgs e)
        {

            btnDescansar.IsEnabled = false;
            DoubleAnimation cerrarOjoDer = new DoubleAnimation();
            cerrarOjoDer.To = 10;
            cerrarOjoDer.Duration = new Duration(TimeSpan.FromSeconds(1));
            cerrarOjoDer.AutoReverse = true;
            cerrarOjoDer.Completed += new EventHandler(finCerrarOjoDer);

            DoubleAnimation cerrarOjoIzq = new DoubleAnimation();
            cerrarOjoIzq.To = 10;
            cerrarOjoIzq.Duration = new Duration(TimeSpan.FromSeconds(1));
            cerrarOjoIzq.AutoReverse = true;

            ojoDer.BeginAnimation(System.Windows.Shapes.Path.HeightProperty, cerrarOjoDer);
            ojoIzq.BeginAnimation(System.Windows.Shapes.Path.HeightProperty, cerrarOjoIzq);

        }

        private void finCerrarOjoDer(object sender, EventArgs e)
        {
            btnDescansar.IsEnabled = true;
        }

        private void acercaDe(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Programa realizado por \n\n Juan Manuel Porrero \n\n ¿Desea salir?", "Acerca De", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                if (primer_credito == true)
                {
                    primer_credito = false;
                    desplegarLogro();
                    credito.Visibility = Visibility.Visible;
                    imgFiesta.Visibility = Visibility.Visible;
                }
            }
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
            this.txtBienvenido.Text = "BIENVENIDO VENGADOR " + nombre;
        }

        private void comer(object sender, RoutedEventArgs e)
        {
            path.Opacity = 100;
            path1.Opacity = 100;
            path2.Opacity = 100;
            path3.Opacity = 100;
            path4.Opacity = 100;
            path5.Opacity = 100;
            path6.Opacity = 100;
            btnComer.IsEnabled = false;
            eventoComer(sender, e);
        }

        private void eventoComer(object sender, RoutedEventArgs e)
        {
            Storyboard comer = (Storyboard)this.Resources["animacionComer2"];
            comer.Completed += new EventHandler(finComer);
            comer.Begin();

            comer_++;
            puntos += 10;

            if (comer_ == 3)
            {
                desplegarLogro();
                comer3veces.Visibility = Visibility.Visible;
                imgMartilloMini.Visibility = Visibility.Visible;
            }

            puntos += 10;

            barraComer.Value += incremento;

            mediaPlayer.Volume = 0.2;
            mediaAnimaciones.Open(new Uri(ruta + "/Audios/comer.mp3"));
            mediaAnimaciones.Play();
        }

        private void finComer(object sender, EventArgs e)
        {
            btnComer.IsEnabled = true;
            path.Opacity = 0;
            path1.Opacity = 0;
            path2.Opacity = 0;
            path3.Opacity = 0;
            path4.Opacity = 0;
            path5.Opacity = 0;
            path6.Opacity = 0;

            mediaAnimaciones.Stop();
            mediaPlayer.Volume = 1;

        }

        private void fondo_navidad(object sender, MouseButtonEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/navidad.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgFondo, image);
        }

        private void fondo_default(object sender, MouseButtonEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/predeterminado.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgFondo, image);
        }

        private void musica_endgame(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(ruta + "/Audios/portals.mp3"));
            mediaPlayer.Play();
        }

        private void musica_army(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(ruta + "/Audios/army.mp3"));
            mediaPlayer.Play();
        }

        private void musica_despacito(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(ruta + "/Audios/mario.mp3"));
            mediaPlayer.Play();
        }

        private void musica_comecocos(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(ruta + "/Audios/comecocos.mp3"));
            mediaPlayer.Play();
        }

        private void fondo_espacio(object sender, MouseButtonEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/espacio.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgFondo, image);
        }

        private void arrastrarGafas(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarCigarro(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarMartillo(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarGorro(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void ponerObjeto(object sender, DragEventArgs e)
        {
            Image aux = (Image)e.Data.GetData(typeof(Image));
            switch (aux.Name)
            {
                case "imgCigarroMini":
                    imgCigarro.Visibility = Visibility.Visible;
                    mediaAnimaciones.Open(new Uri(ruta + "/Audios/colocar.mp3"));
                    mediaAnimaciones.Play();
                    break;
                case "imgGafasMini":
                    imgGafas.Visibility = Visibility.Visible;
                    mediaAnimaciones.Open(new Uri(ruta + "/Audios/colocar.mp3"));
                    mediaAnimaciones.Play();
                    break;
                case "imgMartilloMini":
                    imgMartillo.Visibility = Visibility.Visible;
                    mediaAnimaciones.Open(new Uri(ruta + "/Audios/colocar.mp3"));
                    mediaAnimaciones.Play();
                    break;
                case "imgGorroMini":
                    imgGorro.Visibility = Visibility.Visible;
                    mediaAnimaciones.Open(new Uri(ruta + "/Audios/colocar.mp3"));
                    mediaAnimaciones.Play();
                    break;
                case "imgMascarillaMini":
                    imgMascarilla.Visibility = Visibility.Visible;
                    mediaAnimaciones.Open(new Uri(ruta + "/Audios/colocar.mp3"));
                    mediaAnimaciones.Play();
                    break;
            }

            if (primera_prenda)
            {
                desplegarLogro();
                imgHalloween.Visibility = Visibility.Visible;
                vestir.Visibility = Visibility.Visible;
                primera_prenda = false;
            }
        }

        private void quitarAccesorios(object sender, RoutedEventArgs e)
        {
            imgCigarro.Visibility = Visibility.Hidden;
            imgGafas.Visibility = Visibility.Hidden;
            imgMartillo.Visibility = Visibility.Hidden;
            imgGorro.Visibility = Visibility.Hidden;
            imgMascarilla.Visibility = Visibility.Hidden;
        }

        private void arrastrarMascarilla(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void jugar(object sender, RoutedEventArgs e)
        {
            btnJugar.IsEnabled = false;
            Storyboard jugar = (Storyboard)this.Resources["animacionJugar"];
            jugar.Completed += new EventHandler(finJugar);
            jugar.Begin();

            barraJugar.Value += incremento;

            mediaPlayer.Volume = 0.2;
            mediaAnimaciones.Open(new Uri(ruta + "/Audios/saltar.mp3"));
            mediaAnimaciones.Play();
        }

        private void finJugar(object sender, EventArgs e)
        {
            btnJugar.IsEnabled = true;
            mediaPlayer.Volume = 1;
            puntos += 10;
        }

        private void descansar(object sender, RoutedEventArgs e)
        {
            btnDescansar.IsEnabled = false;
            Storyboard descansar = (Storyboard)this.Resources["animacionDescansar"];
            descansar.Completed += new EventHandler(finDescansar);
            descansar.Begin();

            barraEnergia.Value += incremento;

            mediaPlayer.Volume = 0.2;
            mediaAnimaciones.Open(new Uri(ruta + "/Audios/dormir.mp3"));
            mediaAnimaciones.Play();

        }

        private void finDescansar(object sender, EventArgs e)
        {
            btnDescansar.IsEnabled = true;
            mediaAnimaciones.Stop();
            mediaPlayer.Volume = 1;
            puntos += 10;
        }

        private void easterEggOjo(object sender, MouseButtonEventArgs e)
        {
            if (ojo)
            {
                ojo = false;
                desplegarLogro();
                //DESBLOQUEAS LA MASCARILLA
                imgMascarillaMini.Visibility = Visibility.Visible;
                logroOjo.Visibility = Visibility.Visible;
            }


        }

        private void easterEggBoton(object sender, RoutedEventArgs e)
        {
            if (botonOculto_)
            {
                botonOculto_ = false;
                desplegarLogro();
                imgGorroMini.Visibility = Visibility.Visible;
                botonOculto.Visibility = Visibility.Visible;
            }

        }

        private void desplegarLogro()
        {
            gridLogro.Visibility = Visibility.Visible;
            Storyboard logro = (Storyboard)this.Resources["animacionLogro"];
            logro.Completed += new EventHandler(finLogro);
            puntos += 30;

            mediaAnimaciones.Stop();
            mediaPlayer.Volume = 0;
            mediaAnimaciones.Open(new Uri(ruta + "/Audios/logro.mp3"));
            mediaAnimaciones.Play();

            incremento = incremento + 5;

            logro.Begin();
        }

        private void finLogro(object sender, EventArgs e)
        {
            gridLogro.Visibility = Visibility.Hidden;
            mediaPlayer.Volume = 1;
        }

        private void sobrevive15seg(object sender, EventArgs e)
        {
            desplegarLogro();
            seg.Stop();
            imgArmy.Visibility = Visibility.Visible;
            logro15seg.Visibility = Visibility.Visible;
            decremento += 2;
        }

        private void sobrevive1min(object sender, EventArgs e)
        {
            desplegarLogro();
            min.Stop();

            imgNavidad.Visibility = Visibility.Visible;
            logro1minuto.Visibility = Visibility.Visible;
            decremento += 5;
        }

        private void morir()
        {
            mediaPlayer.Volume = 0;
            mediaAnimaciones.Open(new Uri(ruta + "/Audios/ataud.mp3"));
            mediaAnimaciones.Play();
            t1.Stop();
            t2.Stop();
            t3.Stop();
            seg.Stop();
            min.Stop();
            general.Stop();

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(ruta + "/Fotos/ataud.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gifMuerte, image);

            Storyboard morir = (Storyboard)this.Resources["animacionMuerte"];
            morir.Completed += new EventHandler(finMuerte);

            morir.Begin();


        }

        private void finMuerte(object sender, EventArgs e)
        {
            MessageBox.Show("El Capitán América ha muerto. Tu puntuación es " + puntos, "Fin de partida", MessageBoxButton.OK);
            insertBBDD();
            this.Close();
        }

        private void insertBBDD()
        {
            sentencia = conexion.CreateCommand();
            sentencia.CommandText = "INSERT INTO Puntuaciones (Nombre, Fecha, Puntos) VALUES ('" + this.nombre + "','" + DateTime.Now + "'," + puntos + ")";
            sentencia.Connection = conexion;
            OleDbDataReader rd = sentencia.ExecuteReader();
        }

        private void cerrar_ventana(object sender, CancelEventArgs e)
        {
            insertBBDD();

        }



    }

}

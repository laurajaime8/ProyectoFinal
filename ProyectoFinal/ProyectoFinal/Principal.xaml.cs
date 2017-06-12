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
using System.Xml;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        MainWindow padre;

        /*public Principal()
        {
            InitializeComponent();
            toopTils();
        }*/
        Rectangle gameOver;
        public Principal(MainWindow padre_, Rectangle gameOver)
        {
            padre = padre_;
            this.gameOver = gameOver;
            
            InitializeComponent();
            toopTils();

            if (gameOver.Visibility == Visibility.Visible) {
                btnResumen.IsHitTestVisible = false;
                btnResumen.Background = Brushes.LightGray;
            }

        }

        public Principal()
        {
        }

        public void toopTils() {
            btnJuegos.ToolTip = "Juegos disponibles";
            btnAyuda.ToolTip = "Ayuda";
            btnMiPerfil.ToolTip = "Perfil del Usuario";
            btnNuevaPartida.ToolTip = "Cargar Nueva Partida";
            btnResumen.ToolTip = "Continuar Partida";
            btnSalir.ToolTip = "Salir de la aplicación";
        }
        

        private void ayuda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Este juego ha sido creado por: Oliva Galvez y Laura Jaime. Cuando la oruga es desatendida por un tiempo largo y sus necesidades se ven agotadas, la oruga morirá.");
        }

      

        private void miPerfil(object sender, RoutedEventArgs e)
        {
            MiPerfil frm = new MiPerfil(this.btnJuegos, this.btnMiPerfil,
            this.btnNuevaPartida, this.btnResumen, this.btnSalir, this.btnAyuda);
            botonDeshabilitados();

            frm.Show();
        }


     

        private void salir(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?.",
                "Heimlich - Salir Aplicación",
                MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
                this.Close();
            padre.Close();
        }

        private void nuevaPartida(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea empezar una nueva partida? No se guardará la anterior.",
                "Heimlich - Nueva Partida",
           MessageBoxButton.YesNo, MessageBoxImage.Question)
            == MessageBoxResult.Yes)
            {
                padre.Close();
                padre.musica();

                XmlTextReader myXMLreader = new XmlTextReader("PartidaNueva.xml");
                XmlTextReader myXMLreader2 = new XmlTextReader("LogrosNuevaPartida.xml");
                MiPerfil perfil = new MiPerfil(myXMLreader2);
               
               // perfil.InitializeComponent();
                MainWindow main = new MainWindow(myXMLreader);
                main.InitializeComponent();
                main.Show();
                //perfil.Close();
                this.Close();
            }
        }

        private void resume(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Quieres continuar con la partida guardada?", "Heimlich - Resume",
            MessageBoxButton.YesNo, MessageBoxImage.Question)
             == MessageBoxResult.Yes)
            {
                this.Close();
                padre.ShowDialog();
            }
           
        }

        private void juego(object sender, RoutedEventArgs e)
        {
       
            //XmlTextReader perfilXML = new XmlTextReader("Perfil.xml");
            Laberinto laberinto = new Laberinto(this.btnJuegos, this.btnMiPerfil,
            this.btnNuevaPartida, this.btnResumen, this.btnAyuda, this.btnSalir);
            botonDeshabilitados();
            laberinto.Show();
        }

        public void botonDeshabilitados() {
            btnMiPerfil.IsHitTestVisible = false;
            btnResumen.IsHitTestVisible = false;
            btnNuevaPartida.IsHitTestVisible = false;
            btnJuegos.IsHitTestVisible = false;
            btnSalir.IsHitTestVisible = false;
            btnAyuda.IsHitTestVisible = false;
        }
        public void botonResumeFalse ()
        {
            btnResumen.IsHitTestVisible = false;

        }
       
    }
}

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
       /* public Principal()
        {
            InitializeComponent();
        }*/
        public Principal(MainWindow padre_)
        {
            padre = padre_;
            
            InitializeComponent();
         
        }

        private void ayuda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Este juego ha sido creado por: Oliva Galvez y Laura Jaime. Cuando la oruga es desatendida por un tiempo largo y dos de sus necesidades se ven agotadas, la oruga morirá.");
        }

        private void miPerfinl(object sender, RoutedEventArgs e)
        {

        }

        private void miPerfil(object sender, RoutedEventArgs e)
        {
            MiPerfil frm = new MiPerfil();
            frm.Show();
        }

        private void juegos(object sender, RoutedEventArgs e)
        {
            Juegos frm2 = new Juegos();
            frm2.Show();
        }

        private void resumen(object sender, RoutedEventArgs e)
        {
            this.Close();
            padre.ShowDialog();
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            this.Close();
            padre.Close();
        }

        private void nuevaPartida(object sender, RoutedEventArgs e)
        {
            padre.Close();
            XmlTextReader myXMLreader = new XmlTextReader("PartidaNueva.xml");
            MainWindow main = new MainWindow( myXMLreader);
            main.Show();
        }
    }
}

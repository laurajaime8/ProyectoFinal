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

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Juegos.xaml
    /// </summary>
    public partial class Juegos : Window
    {
        MainWindow frm = new MainWindow();
        public Juegos()
        {
            InitializeComponent();
        }

        private void juegoMosca(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            frm.imgMosca.Visibility = Visibility.Visible;
            // frm.imgMosca.DragEnter += mosquita;
           
        }

       /* private void mosquita(object sender, DragEventArgs e)
        {
           // frm.imgMosca;

            throw new NotImplementedException();

        }*/
    }
}

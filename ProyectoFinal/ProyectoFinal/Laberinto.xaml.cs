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
    /// Lógica de interacción para Laberinto.xaml
    /// </summary>
    public partial class Laberinto : Window
    {
        public Laberinto()
        {
            InitializeComponent();
        }

       
        private void Empezar() {
            
            
        }

       /* private void inicio(object sender, MouseButtonEventArgs e)
        {
           DataObject dataO = new DataObject(((Label)sender));
            DragDrop.DoDragDrop((Label)sender, dataO, DragDropEffects.Move);
        }

        private void final(object sender, DragEventArgs e)
        {
           Label label = (Label)e.Data.GetData(typeof(Label));
            MessageBox.Show("Bien hecho!");
       
        }*/

        private void pared_colision(object sender, MouseEventArgs e)
        {
            if (btnInicio.IsEnabled == false)
            {
                MessageBox.Show("Fail");
                btnInicio.IsEnabled = true;
                btnFinal.IsEnabled = false;
            }
        }

        private void inicio(object sender, MouseEventArgs e)
        {
            btnInicio.IsEnabled = false;
            btnFinal.IsEnabled = true;

        }

        private void final(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Enhorabuena, reto conseguido!");
            btnInicio.IsEnabled = true;
            btnFinal.IsEnabled = false;
        }
    }
}

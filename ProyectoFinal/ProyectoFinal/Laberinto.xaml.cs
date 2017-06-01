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
            btnFinal.IsHitTestVisible = false;

        }


  

        private void pared_colision(object sender, MouseEventArgs e)
        {
            if (btnInicio.IsHitTestVisible == false)
            {
                MessageBox.Show("Fail");
                btnInicio.IsHitTestVisible = true;
                btnFinal.IsHitTestVisible = false;
            }
        }

        private void inicio(object sender, MouseEventArgs e)
        {
            btnInicio.IsHitTestVisible = false;
            btnFinal.IsHitTestVisible = true;

        }

        private void final(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Enhorabuena, reto conseguido!");
            btnInicio.IsHitTestVisible = true;
            btnFinal.IsHitTestVisible = false;
        }

        private void cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        
        private void informacion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bienvenido al juego del laberinto! En primer lugar deberás de poner el ratón sobre la hormiga y tendrás que guiarlo por el laberinto hasta llegar al final. No podrás tocar las paredes ya que si no tendrás que empezar de nuevo. Buena suerte!",
               "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

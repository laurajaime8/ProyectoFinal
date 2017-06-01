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
using System.Windows.Threading;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Laberinto.xaml
    /// </summary>
    public partial class Laberinto : Window
    {
        DispatcherTimer t1;
        int seg = 0;
        int min = 0;
        int hora = 0;

        public Laberinto()
        {
            InitializeComponent();
            btnFinal.IsHitTestVisible = false;

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(1.0);
            t1.Tick += new EventHandler(reloj);
            

        }

        private void reloj(object sender, EventArgs e)
        {

            seg++;

            if (seg == 60)
            {
                min++;
                seg = 0;
            }
            else if (min == 60) {
                hora++;
                min = 0;
            }

            lblCronometro.Content = hora.ToString().PadLeft(2, '0') + ":" 
                + min.ToString().PadLeft(2, '0') +
                ":" + seg.ToString().PadLeft(2, '0');

            
        }



        private void pared_colision(object sender, MouseEventArgs e)
        {
            if (btnInicio.IsHitTestVisible == false)
            {
                MessageBox.Show("Fail");
                t1.Stop();
                lblCronometro.Content = "00:00:00";
                seg = 0;
                min = 0;
                hora = 0;
                btnInicio.IsHitTestVisible = true;
                btnFinal.IsHitTestVisible = false;
                
            }
        }

        private void inicio(object sender, MouseEventArgs e)
        {
            lblCronometro.Content = "00:00:00";
            btnInicio.IsHitTestVisible = false;
            btnFinal.IsHitTestVisible = true;
            t1.IsEnabled = true;
        }

        private void final(object sender, MouseEventArgs e)
        {
            t1.Stop();
            if (MessageBox.Show("¿Desea guardar el tiempo conseguido en tu perfil?.",
              "Heimlich - Laberinto",
              MessageBoxButton.YesNo, MessageBoxImage.Question)
              == MessageBoxResult.Yes) {
                MessageBox.Show("Guardado correctamente!");
            }

            btnInicio.IsHitTestVisible = true;
            btnFinal.IsHitTestVisible = false;
            

            seg = 0;
            min = 0;
            hora = 0;
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

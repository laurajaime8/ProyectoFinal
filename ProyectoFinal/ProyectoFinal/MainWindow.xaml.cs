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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(10.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }

        private void reloj(object sender, EventArgs e)
        {
            pbEnergia.Value -= 10;
            pbApetito.Value -= 10;
            pbDiversion.Value -= 10;

            Storyboard moverOjos;
            moverOjos = (Storyboard)this.Resources["sbMoverParpado"];

            Storyboard tenerHambre;
            tenerHambre = (Storyboard)this.Resources["sbApetito0"];

            Storyboard estarCansado;
            estarCansado = (Storyboard)this.Resources["sbEnergia0"];

            Storyboard estarAburrido;
            estarAburrido = (Storyboard)this.Resources["sbDiversion0"];

            Storyboard lleno100;
            lleno100 = (Storyboard)this.Resources["sbApetito100"];

            Storyboard energia100;
            energia100 = (Storyboard)this.Resources["sbEnergia100"];

            Storyboard diversion100;
            diversion100 = (Storyboard)this.Resources["sbDiversion100"];

            moverOjos.Begin(this);

            //Para las progressBar NEGATIVAS
            if (pbApetito.Value <= 10)
            {
                elLengua.Visibility = Visibility.Visible;
                tenerHambre.Begin(this);
            }
            else if (pbApetito.Value > 10)
            {
                tenerHambre.Remove(this);
                elLengua.Visibility = Visibility.Collapsed;
            }

            if (pbEnergia.Value <= 10)
            {
                estarCansado.Begin(this);                
            }
            else if (pbEnergia.Value > 10)
            {
                estarCansado.Remove(this);
            }

            if (pbDiversion.Value <= 10)
            {
                estarAburrido.Begin(this);
            }
            else if (pbDiversion.Value > 10)
            {
                estarAburrido.Remove(this);
            }

            //Para las progressBar POSITIVAS

            if (pbApetito.Value >= 90)
            {
                lleno100.Begin(this);
            }

            if (pbEnergia.Value >= 90)
            {
                energia100.Begin(this);
               
            }

            if (pbDiversion.Value >= 100)
            {
                diversion100.Begin(this);
            }
             

        }


        private void btDormir_Click(object sender, RoutedEventArgs e)
        {
            pbEnergia.Value += 20;

            Storyboard dormir;
            dormir = (Storyboard)this.Resources["sbDormir"];
            dormir.Begin();
            
        }

        private void btComer_Click(object sender, RoutedEventArgs e)
        {
            pbApetito.Value += 20;
            /*
            Storyboard comer;
            comer = (Storyboard)this.Resources["sbComer"];
            comer.SpeedRatio = 4.0;
            comer.Begin(this);
            */

        }

        private void btJugar_Click(object sender, RoutedEventArgs e)
        {
            
            cvMariposa.Visibility = Visibility.Visible;

            pbDiversion.Value += 20;

            
            Storyboard mariposa;
            mariposa = (Storyboard)this.Resources["sbMariposa"];
            mariposa.SpeedRatio = 3.0;
            mariposa.Begin(this);
           
        /*
            ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 20, 150);
            volarCanvas.AutoReverse = true;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(2));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
        */
            }
        


        private void alegrar(object sender, MouseButtonEventArgs e)
        {
            /*
            Storyboard sbAlegrar = (Storyboard)cvCabeza.Resources["subirCabezaKey"];
            Storyboard sbPupilaIzq = (Storyboard)pupilaIzq.Resources["pupilaIzqGrandeKey"];
            Storyboard sbPupilaDer = (Storyboard)pupilaDer.Resources["pupilaDerGrandeKey"];
            sbAlegrar.Begin();
            sbPupilaIzq.Begin();
            sbPupilaDer.Begin();
            */
        }

  

        private void matarOruga(object sender, MouseButtonEventArgs e)
        {
            cvMataMoscas.Visibility = Visibility.Visible;
            Storyboard matar;
            matar = (Storyboard)this.Resources["sbMatarOruga"];
            matar.Begin(); 

        }
    }
}

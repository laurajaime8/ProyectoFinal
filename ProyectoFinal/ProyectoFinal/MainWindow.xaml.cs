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
            t1.Interval = TimeSpan.FromSeconds(7.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }

        private void reloj(object sender, EventArgs e)
        {
            pbEnergia.Value -= 10;
            pbApetito.Value -= 30;
            pbDiversion.Value -= 20;

            Storyboard moverOjos;
            moverOjos = (Storyboard)this.Resources["sbMoverParpado"];

            Storyboard tenerHambre;
            tenerHambre = (Storyboard)this.Resources["sbApetito0"];

            Storyboard estarCansado;
            estarCansado = (Storyboard)this.Resources["sbEnergia0"];

            //Cambio de accion al estar aburrido
            Storyboard estarAburrido;
            estarAburrido = (Storyboard)this.Resources["sbAburrido"];

            Storyboard lleno100;
            lleno100 = (Storyboard)this.Resources["sbApetito100"];

            Storyboard energia100;
            energia100 = (Storyboard)this.Resources["sbEnergia100"];

            Storyboard diversion100;
            diversion100 = (Storyboard)this.Resources["sbDiversion100"];

            Storyboard muerto;
            muerto = (Storyboard)this.Resources["sbMuerto"];

            moverOjos.Begin(this);

            elLengua.Visibility = Visibility.Hidden;
            cvZetas.Visibility = Visibility.Hidden;
            
            //Para las progressBar NEGATIVAS
            if (pbApetito.Value == 0 && pbDiversion.Value ==0 && pbEnergia.Value == 0)
            {
                muerto.Begin(this);
                cvCabeza.Visibility = Visibility.Hidden;
                calavera.Visibility = Visibility.Visible;
            }
            
            else if ((pbApetito.Value == pbDiversion.Value)&& (pbApetito.Value == pbEnergia.Value) && (pbEnergia.Value == pbDiversion.Value)) {
                //Si se solapan no hacer nada
                muerto.Stop();
                estarAburrido.Stop();
                estarCansado.Stop();
            }
            if (pbApetito.Value<= 10)
            {
                elLengua.Visibility = Visibility.Visible;
                tenerHambre.Begin(this);
                spAlimentos.Visibility = Visibility.Visible;
                
                if(pbApetito.Value > 10)
                {
                  // elLengua.Visibility = Visibility.Hidden;
                   tenerHambre.Remove(this);
                    
                }
            }
             
                
   

            //Sueño
          /* if (pbEnergia.Value <= 10)
            {
                
                cvZetas.Visibility = Visibility.Visible;
                estarCansado.Begin(this);
                
                         
            }
            else if (pbEnergia.Value > 10)
            {
                estarCansado.Remove(this);
                cvZetas.Visibility = Visibility.Hidden;
            }*/

            //Diversion
          /*  if (pbDiversion.Value <= 10)
            {
               estarAburrido.Begin(this);

            }
            else if (pbDiversion.Value > 10)
            {
                estarAburrido.Remove(this);
            }*/

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

       
        private void btJugar_Click(object sender, RoutedEventArgs e)
        {
            
            cvMariposa.Visibility = Visibility.Visible;
            pbDiversion.Value += 20;
            Storyboard mariposa;
            mariposa = (Storyboard)this.Resources["sbMariposa"];
            mariposa.SpeedRatio = 3.0;
            mariposa.Begin(this);
            cvMariposa.Visibility = Visibility.Hidden;


            ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 20, 150);
            volarCanvas.AutoReverse = true;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(2));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
            }
        

        private void matarOruga(object sender, MouseButtonEventArgs e)
        {
            cvMataMoscas.Visibility = Visibility.Visible;
            Storyboard matar;
            matar = (Storyboard)this.Resources["sbMatarOruga"];
            matar.Begin(); 

        }

        private void arrastrarHelado(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
;        }

        private void arrastrarManzana(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarLechuga(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarZanahoria(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void arrastrarBurguer(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }


        private void cvCabeza_Drop(object sender, DragEventArgs e)
        {
           Image imagen = (Image)e.Data.GetData(typeof(Image));
            switch (imagen.Name)
            {
                case "manzana":comerManzana(imagen);
                    break;
                case "helado":comerHelado(imagen);
                    break;
                case "lechuga":comerLechuga(imagen);
                    break;
                case "zanahoria":comerZanahoria(imagen);
                    break;
                case "burguer":comerBurguer(imagen);
                    break;
            }
        }

        private void comerHelado(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerManzana(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerLechuga(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerZanahoria(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
        }

        private void comerBurguer(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

    }
}

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
            pbApetito.Value -= 20;
            pbDiversion.Value -= 20;

            Storyboard moverOjos;
            moverOjos = (Storyboard)this.Resources["sbMoverParpado"];

            //Cuando tienen las barras casi vacías
            Storyboard tenerHambre;
            tenerHambre = (Storyboard)this.Resources["sbApetito0"];

            Storyboard estarCansado;
            estarCansado = (Storyboard)this.Resources["sbEnergia0"];

            Storyboard estarAburrido;
            estarAburrido = (Storyboard)this.Resources["sbAburrido"];

            //Cuando tienen las barras llenas

            Storyboard lleno100;
            lleno100 = (Storyboard)this.Resources["sbApetito100"];

            Storyboard energia100;
            energia100 = (Storyboard)this.Resources["sbEnergia100"];

            Storyboard diversion100;
            diversion100 = (Storyboard)this.Resources["sbDiversion100"];


            //Bicho muerto -> Todas las barras a 0
            Storyboard muerto;
            muerto = (Storyboard)this.Resources["sbMuerto"];

            moverOjos.Begin(this);

            elLengua.Visibility = Visibility.Hidden;
            cvZetas.Visibility = Visibility.Hidden;

            if ((pbApetito.Value <= 10 && pbDiversion.Value <= 10) ||
                (pbApetito.Value <= 10 && pbEnergia.Value <= 10) ||
                (pbDiversion.Value <= 10 && pbEnergia.Value <= 10) ||
                (pbDiversion.Value <= 10 && pbEnergia.Value <= 10 && pbApetito.Value <= 10))
            {
                cvCabeza.Visibility = Visibility.Hidden;
                calavera.Visibility = Visibility.Visible;
                estarAburrido.Remove();
                estarCansado.Remove();
                tenerHambre.Remove();
                btJugar.IsHitTestVisible = false;
                btDormir.IsHitTestVisible = false;

            }
            else {
                cvCabeza.Visibility = Visibility.Visible;
                calavera.Visibility = Visibility.Hidden;
            }


            //Sueño
            if (pbEnergia.Value <= 10 && pbApetito.Value > 10 && pbDiversion.Value > 10) {
                cvZetas.Visibility = Visibility.Visible;
                estarCansado.Begin(this);
            
            } 
            else if (pbEnergia.Value > 10)
            {
               estarCansado.Remove(this);
               cvZetas.Visibility = Visibility.Hidden;
            }

            //Diversion
            if (pbDiversion.Value <= 10 && pbApetito.Value > 10 && pbEnergia.Value > 10)
            {
                estarAburrido.Begin(this);
            }
            else if (pbDiversion.Value > 10)
            {
                estarAburrido.Remove(this);
            }
            


            //Apetito
           if (pbApetito.Value<= 10 && pbDiversion.Value > 10 && pbEnergia.Value > 10)
           {
               elLengua.Visibility = Visibility.Visible;
               tenerHambre.Begin(this);
               spAlimentos.Visibility = Visibility.Visible;

            }

            if (pbApetito.Value > 10)
            {
                elLengua.Visibility = Visibility.Hidden;
                tenerHambre.Remove(this);
                spAlimentos.Visibility = Visibility.Hidden;
            }
            
            //Para las progressBar POSITIVAS

            if (pbApetito.Value >= 90 && pbEnergia.Value < 90 && pbDiversion.Value < 90)
            {
                lleno100.Begin(this);
            }

            if (pbEnergia.Value >= 90 && pbApetito.Value < 90 && pbDiversion.Value < 90)
            {
                energia100.Begin(this);

            }

            if (pbDiversion.Value >= 100 && pbEnergia.Value < 90 && pbApetito.Value < 90)
            {
                diversion100.Begin(this);
            }
            
        }



        private void btDormir_Click(object sender, RoutedEventArgs e)
        {
    
            Storyboard dormir;
            dormir = (Storyboard)this.Resources["sbDormir"];
            dormir.Begin();
            //btJugar.IsHitTestVisible = false;

            pbEnergia.Value += 20;

          
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

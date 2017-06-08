using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using System.Threading;


namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        private SoundPlayer simpleSound = new SoundPlayer("bostezo.wav");
        private SoundPlayer gameOver = new SoundPlayer("gameOver.wav");
        private MediaPlayer sonido;


        public MainWindow()
        {

            
            InitializeComponent();
            txtLevel.Text = "1";
            etiquetas();

            sonido = new MediaPlayer();
            sonido.Volume = 0.01;


            sonido.Open(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\bin\\Debug\\cancionBichos.wav"));
            sonido.MediaEnded += new EventHandler(Media_Ended);
            sonido.Play();


            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();

            cvMariposa.Visibility = Visibility.Hidden;

            persistenciaEntrar();

         }

        public MainWindow(XmlTextReader myXMLreader)
        {

            InitializeComponent();
            etiquetas();

            sonido = new MediaPlayer();
            sonido.Volume = 0.01;

            sonido.Open(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\bin\\Debug\\cancionBichos.wav"));
            sonido.MediaEnded += new EventHandler(Media_Ended);
            sonido.Play();

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();

            cvMariposa.Visibility = Visibility.Hidden;

            persistenciaEntrarPartidaNueva(myXMLreader);

        }

        private void Media_Ended(object sender, EventArgs e)
        {
            sonido.Open(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\bin\\Debug\\cancionBichos.wav"));
            sonido.Play();
        }

        public void  etiquetas() {
            btnCasa.ToolTip = "Menú Principal";
            btnSalir.ToolTip = "Salir de la Aplicación";
            btJugar.ToolTip = "Jugar";
            btDormir.ToolTip = "Dormir";
        }


        private void reloj(object sender, EventArgs e)
        {
           
            //Decrementar la barra en:
            pbEnergia.Value -= 4;
            pbApetito.Value -= 2;
            pbDiversion.Value -= 3;
            

            //STORYBOARDS////////
            Storyboard moverOjos;
            moverOjos = (Storyboard)this.Resources["sbMoverParpado"];

            //Cuando tienen las barras casi vacías
            Storyboard tenerHambre;
            tenerHambre = (Storyboard)this.Resources["sbApetito0"];

            Storyboard estarCansado;
            estarCansado = (Storyboard)this.Resources["sbEnergia0"];

            Storyboard estarAburrido;
            estarAburrido = (Storyboard)this.Resources["sbDiversion0"];

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
            //////////////////////////////////////

            moverOjos.Begin(this);
            elLengua.Visibility = Visibility.Hidden;
            cvZetas.Visibility = Visibility.Hidden;

            //imgMosca.Visibility = Visibility.Hidden;


            Storyboard medioMuerto;
            medioMuerto = (Storyboard)this.Resources["sbTodoBajo"];

            int contadorMuertes = 0;
            int contadorDormir = 0;
            //Acciones
        
                
                if ((pbApetito.Value == 0 && pbDiversion.Value == 0) ||
                (pbApetito.Value == 0 && pbEnergia.Value == 0) ||
                (pbDiversion.Value == 0 && pbEnergia.Value == 0))
                {
                   /* cvCabeza.Visibility = Visibility.Hidden;
                    calavera.Visibility = Visibility.Visible;
                    estarAburrido.Remove();
                    estarCansado.Remove();
                    tenerHambre.Remove();
                    btJugar.IsHitTestVisible = false;
                    btDormir.IsHitTestVisible = false;
                    */
                    GameOver.Visibility = Visibility.Visible;
                    lblLevel.Content = "";
                    txtLevel.Text = "";
                    sonido.Stop();
                   // gameOver.Play();
                    
                   /* if (MessageBox.Show("¿Quieres empezar una nueva partida?.",
                   "Has perdido...",
                   MessageBoxButton.YesNo, MessageBoxImage.Question)
                   == MessageBoxResult.Yes)
                    {
                       // gameOver.Stop();

                        pbApetito.Value = 10;
                        pbDiversion.Value = 10;
                        pbEnergia.Value = 10;
                        Principal pr = new Principal(this);
                        GameOver.Visibility = Visibility.Hidden;
                        pr.botonResumeFalse();
                        pr.Show();
                    }
                    contadorMuertes = contadorMuertes + 1;
                    */
                }
            

          

            //Barras iguales a 10 todas
            if (pbEnergia.Value <= 10 && pbApetito.Value <= 10 && pbDiversion.Value <= 10)
            {
                medioMuerto.Begin();
                
            } else if (pbEnergia.Value > 10 || pbApetito.Value > 10 || pbDiversion.Value > 10)
            {
                medioMuerto.Stop();
            }

            //Dos barras bajas
            if((pbEnergia.Value <= 10 && pbApetito.Value <= 10) || (pbEnergia.Value <= 10 && pbDiversion.Value <= 10) && (pbApetito.Value <= 10 || pbDiversion.Value <= 10))
            {
                medioMuerto.Begin();
            }else
            {
                medioMuerto.Remove();
            }

            //Sueño
            if (pbEnergia.Value <= 10 && pbApetito.Value > 10 && pbDiversion.Value > 10) {
                cvZetas.Visibility = Visibility.Visible;
                estarCansado.Begin(this);
                contadorDormir = contadorDormir + 1;
            } else if (pbEnergia.Value > 10 && pbApetito.Value > 10 && pbDiversion.Value > 10)
            {
                estarCansado.Stop();
                estarCansado.Remove();
                cvZetas.Visibility = Visibility.Hidden;
            }

            if (contadorDormir >= 5)
            {
                txtLevel.Text = "2";
            }

            //Diversion
              if (pbDiversion.Value <= 10 && pbApetito.Value > 10 && pbEnergia.Value > 10)
              {
                       estarAburrido.Begin();
                       cvAburrido.Visibility = Visibility.Visible;

              }else if (pbDiversion.Value > 10 && pbApetito.Value > 10 && pbEnergia.Value > 10)
              {
                estarAburrido.Stop();
                estarAburrido.Remove();
                cvAburrido.Visibility = Visibility.Hidden;
              }
              

              

            //Apetito
            if (pbApetito.Value < 20)
            {
                spAlimentos.Visibility = Visibility.Visible;
            }else if (pbApetito.Value > 50)
            {
                spAlimentos.Visibility = Visibility.Hidden;
            }
           

            if (pbApetito.Value <= 10 && pbDiversion.Value > 10 && pbEnergia.Value > 10)
            {
                elLengua.Visibility = Visibility.Visible;
                cvHambre.Visibility = Visibility.Visible;
                tenerHambre.Begin();
            }else if (pbApetito.Value > 10 && pbDiversion.Value > 10 && pbEnergia.Value > 10)
            {
                elLengua.Visibility = Visibility.Hidden;
                cvHambre.Visibility = Visibility.Hidden;
                tenerHambre.Stop();
                tenerHambre.Remove();
            }

        }

        private void EstarCansado_Completed(object sender, EventArgs e)
        {
           // MessageBox.Show("Funciona");
            btJugar.IsHitTestVisible = true;
            btDormir.IsHitTestVisible = true;
            cvMariposa.Visibility = Visibility.Collapsed;
            simpleSound.Stop();
        }



        private void btDormir_Click(object sender, RoutedEventArgs e)
        {
            
            Storyboard dormir;
            dormir = (Storyboard)this.Resources["sbDormir"];
            dormir.Completed += Dormir_Completed;
            dormir.Begin();
            btJugar.IsHitTestVisible = false;
            btDormir.IsHitTestVisible = false;

            pbEnergia.Value += 50;
        
            simpleSound.Play();
            
        }

        private void Dormir_Completed(object sender, EventArgs e)
        {
            //MessageBox.Show("Funciona");
            btJugar.IsHitTestVisible = true;
            btDormir.IsHitTestVisible = true;
         


        }

        private void btJugar_Click(object sender, RoutedEventArgs e)
        {

            Storyboard mariposa;
            mariposa = (Storyboard)this.Resources["sbMariposa"];
            mariposa.SpeedRatio = 3.0;

          
           
            mariposa.Completed += EstarCansado_Completed;
            mariposa.Begin(this);
            btJugar.IsHitTestVisible = false;
            btDormir.IsHitTestVisible = false;
            cvMariposa.Visibility = Visibility.Visible;
            pbDiversion.Value += 50;

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


        //COMIDA
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
          //  imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 10;
        }

        private void comerManzana(Image imgOrigen)
        {
           // imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerLechuga(Image imgOrigen)
        {
          //  imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerZanahoria(Image imgOrigen)
        {
         //   imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 20;
        }

        private void comerBurguer(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 30;
        }

       private void volarMosca(object sender, DragEventArgs e)
        {
            
            Storyboard mosca;
            mosca = (Storyboard)this.Resources["sbMosca"];

            //mosca.Begin();
            //if(imgMosca)
        }

        private void menuPrinc(object sender, RoutedEventArgs e)
        {
            Principal frm2 = new Principal(this);
            //persistenciaSalir();
            this.Hide();
            frm2.ShowDialog();
            
        }

        private void terminar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            persistenciaSalir();
        }

        public void persistenciaSalir() {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (XmlWriter writer = XmlWriter.Create("Cthulhu.xml", settings))
            {
                writer.WriteStartElement("Atributos");
                writer.WriteElementString("Comida", pbApetito.Value + "");
                writer.WriteElementString("Energia", pbEnergia.Value + "");
                writer.WriteElementString("Diversion", pbDiversion.Value + "");
                writer.WriteEndElement();
                writer.Flush();
                // writer.Close();
            }
        }
        public void persistenciaEntrar() {
            XmlTextReader myXMLreader = new XmlTextReader("Cthulhu.xml");
            while (myXMLreader.Read())
            {
                if (myXMLreader.NodeType == XmlNodeType.Element)
                {
                    if (myXMLreader.Name == "Diversion")
                    {
                        myXMLreader.Read();
                        pbDiversion.Value = myXMLreader.ReadContentAsDouble();
                    }
                    if (myXMLreader.Name == "Comida")
                    {
                        myXMLreader.Read();
                        pbApetito.Value = myXMLreader.ReadContentAsDouble();
                    }
                    if (myXMLreader.Name == "Energia")
                    {
                        myXMLreader.Read();
                        pbEnergia.Value = myXMLreader.ReadContentAsDouble();
                    }
                }
            }
            myXMLreader.Close();
        }
        public void persistenciaEntrarPartidaNueva(XmlTextReader myXMLreader)
        {
            
            while (myXMLreader.Read())
            {
                if (myXMLreader.NodeType == XmlNodeType.Element)
                {
                    if (myXMLreader.Name == "Diversion")
                    {
                        myXMLreader.Read();
                        pbDiversion.Value = myXMLreader.ReadContentAsDouble();
                    }
                    if (myXMLreader.Name == "Comida")
                    {
                        myXMLreader.Read();
                        pbApetito.Value = myXMLreader.ReadContentAsDouble();
                    }
                    if (myXMLreader.Name == "Energia")
                    {
                        myXMLreader.Read();
                        pbEnergia.Value = myXMLreader.ReadContentAsDouble();
                    }
                }
            }
            myXMLreader.Close();
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            //Preguntar
            sonido.Stop();
            gameOver.Stop();
            this.Hide();
            persistenciaSalir();
            this.Close();
        }
        public void musica() {

            sonido.Volume = 0;
        }
    }
    
}

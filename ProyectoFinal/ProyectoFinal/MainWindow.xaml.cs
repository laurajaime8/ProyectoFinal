using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml;


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
        private int contadorExp = 0;
        

        public MainWindow()
        {

            
            InitializeComponent();
           
            etiquetas();

            sonido = new MediaPlayer();
            sonido.Volume = 1;


            sonido.Open(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\bin\\Debug\\cancionBichos.wav"));
            sonido.MediaEnded += new EventHandler(Media_Ended);
            sonido.Play();


            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();

            cvMariposa.Visibility = Visibility.Hidden;

            persistenciaEntrar();
            btnPonerVolumen.IsHitTestVisible = false;

         }

        public MainWindow(XmlTextReader myXMLreader)
        {

            InitializeComponent();
            etiquetas();

            sonido = new MediaPlayer();
            sonido.Volume = 1;

            sonido.Open(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\bin\\Debug\\cancionBichos.wav"));
            sonido.MediaEnded += new EventHandler(Media_Ended);
            sonido.Play();

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();

            cvMariposa.Visibility = Visibility.Hidden;

            persistenciaEntrarPartidaNueva(myXMLreader);
            btnPonerVolumen.IsHitTestVisible = false;
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
            btnPonerVolumen.ToolTip = "Poner Volumen";
            btnQuitarVolumen.ToolTip = "Quitar Volumen";
            btnInfo.ToolTip = "Información acerca del juego";
        }


        private void reloj(object sender, EventArgs e)
        {

            if (txtLevel.Text == "0")
            {
                //Decrementar la barra en:
                pbEnergia.Value -= 4;
                pbApetito.Value -= 2;
                pbDiversion.Value -= 3;
            } else if (txtLevel.Text == "1") {
                pbEnergia.Value -= 8;
                pbApetito.Value -= 4;
                pbDiversion.Value -= 6;

            } else if (txtLevel.Text == "2") {

                pbEnergia.Value -= 16;
                pbApetito.Value -= 8;
                pbDiversion.Value -= 12;
            }
            else if (txtLevel.Text == "3") {
                pbEnergia.Value -= 4;
                pbApetito.Value -= 2;
                pbDiversion.Value -= 3;

            }
            

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


            Storyboard medioMuerto;
            medioMuerto = (Storyboard)this.Resources["sbTodoBajo"];

            //Acciones
            int contadorMuertes=0;
                
                if ((pbApetito.Value == 0 && pbDiversion.Value == 0) ||
                (pbApetito.Value == 0 && pbEnergia.Value == 0) ||
                (pbDiversion.Value == 0 && pbEnergia.Value == 0))
                {
                    spAlimentos.Visibility = Visibility.Hidden;
                    GameOver.Visibility = Visibility.Visible;
                    lblLevel.Content = "";
                    txtLevel.Text = "";
                    lblExperiencia.Content = "";
                    txtExp.Text = "";
                    sonido.Stop();
                contadorMuertes = contadorMuertes + 1;
                if (contadorMuertes > 5)
                {
                    //Mostrar el logro de asesinato nato
                }
                   
               }


            //Barras iguales a 10 todas
            if (pbEnergia.Value <= 10 && pbApetito.Value <= 10 && pbDiversion.Value <= 10)
            {
                medioMuerto.Begin();
                
            } else if (pbEnergia.Value > 10 || pbApetito.Value > 10 || pbDiversion.Value > 10)
            {
                medioMuerto.Stop();
            }

            //Sueño
            if (pbEnergia.Value <= 10 && pbApetito.Value > 10 && pbDiversion.Value > 10) {
                cvZetas.Visibility = Visibility.Visible;
                estarCansado.Begin(this);
               
            } else if (pbEnergia.Value > 10 )
            {
                estarCansado.Stop();
                estarCansado.Remove();
                cvZetas.Visibility = Visibility.Hidden;
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

            if (txtLevel.Text == "0") {
                nivel1();
            }
            else if (txtLevel.Text == "1") {
                nivel2();
            }
            else if (txtLevel.Text == "2") {
                nivel3();
            } 
            
           
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

            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }

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
            pbApetito.Value += 10;
            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }
        }

        private void comerManzana(Image imgOrigen)
        {
            pbApetito.Value += 20;
            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }
        }

        private void comerLechuga(Image imgOrigen)
        {
            pbApetito.Value += 20;
            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }
        }

        private void comerZanahoria(Image imgOrigen)
        {
            pbApetito.Value += 20;
            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }
        }

        private void comerBurguer(Image imgOrigen)
        {
            imgOrigen.Visibility = Visibility.Hidden;
            pbApetito.Value += 30;
            if (txtLevel.Text == "0")
            {
                nivel1();
            }
            else if (txtLevel.Text == "1")
            {
                nivel2();
            }
            else if (txtLevel.Text == "2")
            {
                nivel3();
            }
        }

       private void volarMosca(object sender, DragEventArgs e)
        {
            
            Storyboard mosca;
            mosca = (Storyboard)this.Resources["sbMosca"];
        }

        private void menuPrinc(object sender, RoutedEventArgs e)
        {
            Principal frm2 = new Principal(this);
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
                writer.WriteElementString("Nivel", txtLevel.Text + "");
                writer.WriteElementString("Experiencia", txtExp.Text + "");
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
                    if (myXMLreader.Name == "Nivel")
                    {
                        myXMLreader.Read();
                        txtLevel.Text = myXMLreader.ReadContentAsString();
                    }
                    if (myXMLreader.Name == "Experiencia")
                    {
                        myXMLreader.Read();
                        txtExp.Text = myXMLreader.ReadContentAsString();
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
                    if (myXMLreader.Name == "Nivel")
                    {
                        myXMLreader.Read();
                        txtLevel.Text = myXMLreader.ReadContentAsString();
                    }
                    if (myXMLreader.Name == "Experiencia")
                    {
                        myXMLreader.Read();
                        txtExp.Text = myXMLreader.ReadContentAsString();
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

        private void volumenQuitar(object sender, RoutedEventArgs e)
        {
            sonido.Volume = 0;
            btnQuitarVolumen.IsHitTestVisible = false;
            btnPonerVolumen.IsHitTestVisible = true;
        }

        private void ponerVolumen(object sender, RoutedEventArgs e)
        {
            sonido.Volume = 1;
            btnQuitarVolumen.IsHitTestVisible = true;
            btnPonerVolumen.IsHitTestVisible = false;
        }

        public Boolean subidaNivel1() {
            Boolean vale = false;

            if (contadorExp == 20) {
                vale = true;
                
            }
            return vale;

        }
        public Boolean subidaNivel2()
        {
            Boolean vale = false;

            if (contadorExp == 180)
            {
                vale = true;

            }
            return vale;

        }
        public Boolean subidaNivel3()
        {
            Boolean vale = false;

            if (contadorExp >= 300)
            {
                vale = true;

            }
            return vale;

        }

        public void nivel1() {
            contadorExp += 10;
            txtExp.Text = contadorExp.ToString();
            Boolean vale;
            vale = subidaNivel1();

            if (vale == true)
            {
                MessageBox.Show("Enhorabuena, acabas de subir al nivel 1");
                txtLevel.Text = "1";
                
           
            }

        }
        public void nivel2()
        {
            contadorExp += 5;
            txtExp.Text = contadorExp.ToString();
            Boolean vale;
            vale = subidaNivel2();

            if (vale == true)
            {
                MessageBox.Show("Enhorabuena, acabas de subir al nivel 2");
                txtLevel.Text = "2";
            }
        }

        public void nivel3()
        {
            contadorExp += 1;
            txtExp.Text = contadorExp.ToString();
            Boolean vale;
            vale = subidaNivel3();

            if (vale == true)
            {
                MessageBox.Show("Enhorabuena, acabas de subir al nivel 3 y por tanto has completado todos los niveles");
                txtLevel.Text = "3";
                MessageBox.Show("Nuevo logro desbloqueado: ¡Campeón!",
               "Logro", MessageBoxButton.OK, MessageBoxImage.Information);
                XmlTextReader myXMLreader = new XmlTextReader("Logros.xml");
                MiPerfil mp = new MiPerfil(myXMLreader);
                Laberinto lab = new Laberinto();
                int valorC = 1;
                int valorT = 0;
                int valorR = 0;
                int valorP = 0;
                lab.persistenciaEscribir(valorT, valorR, valorP, valorC);
                mp.mCampeon.Visibility = Visibility.Visible;

            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bienvenido a este juego, las reglas son muy básicas, deberás de dar de comer a Heimlich, jugar con él y ponerle a dormir. Si no cumples una de estos dos objetivos la oruga se morirá y tendrás que empezar una nueva partida. Cada vez que realices alguna de estas tres opciones ganarás puntos de experiencia y con ello subirás de nivel. ¡Cuidado! Si subes de nivel las barras decrecerán cada vez más deprisa. ¡Mucho ánimo y suerte!",
              "Información sobre el Juego", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void btnTienda_Click(object sender, RoutedEventArgs e)
        {
            Tienda t= new Tienda(contadorExp);
            t.Show();

        }

    }
    
}

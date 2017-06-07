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
using System.Xml;

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
        MiPerfil perfil = new MiPerfil();
        Button b1, b2, b3, b4, b5, b6;
      
        public Laberinto(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6)
        {
            InitializeComponent();
            btnFinal.IsHitTestVisible = false;

            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;
            this.b5 = b5;
            this.b6 = b6;


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

            if (seg == 5)
            {
                perfil.mRapido.Visibility = Visibility.Visible;
                MessageBox.Show("Has desbloqueado el logro: Super rápido",
                  "Logro desbloqueado", MessageBoxButton.OK, MessageBoxImage.Information);
                perfil.pbNivel.Value += 10;

            }
            if (seg == 20)
            {
                perfil.lblTortuga.Visibility = Visibility.Visible;
                MessageBox.Show("Has desbloqueado el logro: Tortugo",
                  "Logro desbloqueado", MessageBoxButton.OK, MessageBoxImage.Information);
                perfil.pbNivel.Value += 10;
              
            }

            seg = 0;
            min = 0;
            hora = 0;
        }


      

        
        private void informacion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bienvenido al juego del laberinto! En primer lugar deberás de poner el ratón sobre la hormiga y tendrás que guiarlo por el laberinto hasta llegar al final. No podrás tocar las paredes ya que si no tendrás que empezar de nuevo. Buena suerte!",
               "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public void persistenciaSalir()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (XmlWriter writer = XmlWriter.Create("Perfil.xml", settings))
            {
                writer.WriteStartElement("Atributos");
                writer.WriteElementString("Nivel", perfil.pbNivel.Value + "");
                
                writer.WriteEndElement();
                writer.Flush();
                // writer.Close();
            }
        }
        public void persistenciaEntrar()
        {
            XmlTextReader myXMLreader = new XmlTextReader("Perfil.xml");
            while (myXMLreader.Read())
            {
                if (myXMLreader.NodeType == XmlNodeType.Element)
                { }
                    if (myXMLreader.Name == "Nivel")
                    {
                        myXMLreader.Read();
                        perfil.pbNivel.Value = myXMLreader.ReadContentAsDouble();
                    }
                
                }
            myXMLreader.Close();
            }

        private void terminar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            b1.IsHitTestVisible = true;
            b2.IsHitTestVisible = true;
            b3.IsHitTestVisible = true;
            b4.IsHitTestVisible = true;
            b5.IsHitTestVisible = true;
            b6.IsHitTestVisible = true;
        }
    }
    }

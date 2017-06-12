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
        Button b1, b2, b3, b4, b5, b6;
        
        int valorT;
        int valorR;
        int valorP;
        int valorC;
        int valorL;
      
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

        int contadorColision = 0;
        private void pared_colision(object sender, MouseEventArgs e)
        {
            if (btnInicio.IsHitTestVisible == false)
            {
                MessageBox.Show("Error, empieza de nuevo!");
                t1.Stop();
                lblCronometro.Content = "00:00:00";
                seg = 0;
                min = 0;
                hora = 0;
                btnInicio.IsHitTestVisible = true;
                btnFinal.IsHitTestVisible = false;
                contadorColision = contadorColision + 1;

                if (contadorColision > 5)
                {
                    MessageBox.Show("Has desbloqueado el logro: Patoso number ONE",
                      "Logro desbloqueado", MessageBoxButton.OK, MessageBoxImage.Information);
                    persistenciaEntrar();
                    valorP = 1;
                    persistenciaEscribir(valorT, valorR, valorP, valorC, valorL);
                }
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
            btnInicio.IsHitTestVisible = true;
            btnFinal.IsHitTestVisible = false; 

            MessageBox.Show("Has tardado " + min+ " minutos con " + seg + " segundos",
                 "Tiempo tardado", MessageBoxButton.OK, MessageBoxImage.Information);

            if (seg <= 5)
            {
                MessageBox.Show("Has desbloqueado el logro: Super rápido",
                  "Logro desbloqueado", MessageBoxButton.OK, MessageBoxImage.Information);
                persistenciaEntrar();
                valorR = 1;
                persistenciaEscribir(valorT, valorR, valorP, valorL, valorC);

            }

            if (valorC == 1 && valorP == 1 && valorR == 1 && valorT == 1)
            {
                MessageBox.Show("¡¡¡ENHORABUENA, HAS DESBLOQUEADO TODOS LOS LOGROS!!!",
                 "Todos los losgros desbloqueados", MessageBoxButton.OK, MessageBoxImage.Information);
                persistenciaEntrar();
                valorL = 1;
                persistenciaEscribir(valorT, valorR, valorP, valorL, valorC);
            }

            

            if (seg >= 15)
            {
                MessageBox.Show("Has desbloqueado el logro: Tortuga",
                    "Logro desbloqueado", MessageBoxButton.OK, MessageBoxImage.Information);
                persistenciaEntrar();
                valorT = 1;
                persistenciaEscribir(valorT, valorR, valorP, valorC, valorL);
            }

            seg = 0;
            min = 0;
            hora = 0;

         

        }

 
        private void informacion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bienvenido al minijuego del laberinto! En primer lugar deberás de poner el ratón sobre la hormiga y tendrás que guiarlo por el laberinto hasta llegar al final. No podrás tocar las paredes ya que si no tendrás que empezar de nuevo. Buena suerte!",
               "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public void persistenciaEscribir(int valorT, int valorR, int valorP, int valorL, int valorC)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (XmlWriter writer = XmlWriter.Create("Logros.xml", settings))
            {
                writer.WriteStartElement("Atributos");
                writer.WriteElementString("LogroTortuga", valorT + "");
                writer.WriteElementString("LogroRapido", valorR + "");
                writer.WriteElementString("LogroPatoso", valorP + "");
                writer.WriteElementString("LogroTodos", valorL + "");
                writer.WriteElementString("LogroCampeon", valorC + "");
                writer.WriteEndElement();
                writer.Flush();
                // writer.Close();
            }
        }

        public void persistenciaEntrar()
        {
            XmlTextReader myXMLreader = new XmlTextReader("Logros.xml");
            while (myXMLreader.Read())
            {
                if (myXMLreader.NodeType == XmlNodeType.Element)
                {
                    if (myXMLreader.Name == "LogroTortuga")
                    {
                        myXMLreader.Read();
                        valorT = myXMLreader.ReadContentAsInt();
                    }
                    if (myXMLreader.Name == "LogroRapido")
                    {
                        myXMLreader.Read();
                        valorR = myXMLreader.ReadContentAsInt();
                    }
                    if (myXMLreader.Name == "LogroPatoso")
                    {
                        myXMLreader.Read();
                        valorP = myXMLreader.ReadContentAsInt();
                    }
                    if (myXMLreader.Name == "LogroTodos")
                    {
                        myXMLreader.Read();
                        valorL = myXMLreader.ReadContentAsInt();
                    }
                    if (myXMLreader.Name == "LogroCampeon")
                    {
                        myXMLreader.Read();
                        valorC = myXMLreader.ReadContentAsInt();
                    }
                }
            }
            myXMLreader.Close();
        }
    }
    }

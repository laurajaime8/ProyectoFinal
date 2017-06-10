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
using System.Xml;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class MiPerfil : Window
    {
        Button b1, b2, b3, b4, b5, b6;

        private void terminar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            b1.IsHitTestVisible = true;
            b2.IsHitTestVisible = true;
            b3.IsHitTestVisible = true;
            b4.IsHitTestVisible = true;
            b5.IsHitTestVisible = true;
            b6.IsHitTestVisible = true;
        }

        public MiPerfil(XmlTextReader myXMLreader) {

            InitializeComponent();
            int valor = 0;
            persistenciaEscribir(valor);
            //this.Close();
        }

        public MiPerfil(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6)
        {
            InitializeComponent();

            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;
            this.b5 = b5;
            this.b6 = b6;

            persistenciaEntrar();
            
        }
        public void persistenciaEntrar()
        {
            int valor;
            XmlTextReader myXMLreader = new XmlTextReader("Logros.xml");

            while (myXMLreader.Read())
            {
                if (myXMLreader.NodeType == XmlNodeType.Element)
                {

                    if (myXMLreader.Name == "LogroTortuga")
                    {
                        myXMLreader.Read();
                         valor = myXMLreader.ReadContentAsInt();
                        if (valor == 1) {
                            mTortuga.Visibility = Visibility.Visible;
                        }
                    }



                    if (myXMLreader.Name == "LogroRapido")
                    {
                        myXMLreader.Read();
                        valor = myXMLreader.ReadContentAsInt();
                        if (valor == 1)
                        {
                            mRapido.Visibility = Visibility.Visible;
                        }
                    }


                    if (myXMLreader.Name == "LogroPatoso")
                    {
                        myXMLreader.Read();
                        valor = myXMLreader.ReadContentAsInt();
                        if (valor == 1)
                        {
                            mPatoso.Visibility = Visibility.Visible;
                        }
                    }

                    if (myXMLreader.Name == "LogroCampeon")
                    {
                        myXMLreader.Read();
                        valor = myXMLreader.ReadContentAsInt();
                        if (valor == 1)
                        {
                            mCampeon.Visibility = Visibility.Visible;
                        }
                    }

                }
            }
            myXMLreader.Close();
        }
        public void persistenciaEscribir(int valor)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (XmlWriter writer = XmlWriter.Create("Logros.xml", settings))
            {
                writer.WriteStartElement("Atributos");
                writer.WriteElementString("LogroTortuga", valor + "");
                writer.WriteElementString("LogroRapido", valor + "");
                writer.WriteElementString("LogroCampeon", valor + "");
                writer.WriteEndElement();
                writer.Flush();
                // writer.Close();
            }
        }

    }
        
        }
    
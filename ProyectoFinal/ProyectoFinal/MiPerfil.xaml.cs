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

        public MiPerfil(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6)
        {
            InitializeComponent();

            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;
            this.b5 = b5;
            this.b6 = b6;

            Laberinto lab = new Laberinto();

            this.Show();
            if (mTortuga.Visibility == Visibility.Visible)
            {
                mTortuga.Visibility = Visibility.Visible;
            }
            if (mRapido.Visibility == Visibility.Visible)
            {

                mRapido.Visibility = Visibility.Visible;
            }
            if (mAsesino.Visibility == Visibility.Visible)
            {

                mAsesino.Visibility = Visibility.Visible;
            }
            if (mPatoso.Visibility == Visibility.Visible)
            {

                mPatoso.Visibility = Visibility.Visible;

            }
            if (mLogro.Visibility == Visibility.Visible)
            {

                mLogro.Visibility = Visibility.Visible;
            }
        }

    }
        
        }
    
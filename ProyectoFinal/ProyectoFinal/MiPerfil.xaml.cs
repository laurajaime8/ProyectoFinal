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
        Button b1, b2, b3, b4;
        public MiPerfil(Button b1, Button b2, Button b3, Button b4)
        {
            InitializeComponent();

            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;


        }
        public MiPerfil()
        {
            InitializeComponent();


        }
    }
}

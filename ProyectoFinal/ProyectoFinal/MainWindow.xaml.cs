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
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }

        private void btDormir_Click(object sender, RoutedEventArgs e)
        {
            pbEnergia.Value += 20;
        }

        private void btComer_Click(object sender, RoutedEventArgs e)
        {
            pbApetito.Value += 20;

        }

        private void btJugar_Click(object sender, RoutedEventArgs e)
        {
            pbDiversion.Value += 20;
        }
        private void reloj(object sender, EventArgs e)
        {
            pbEnergia.Value -= 10;
            pbApetito.Value -= 10;
            pbDiversion.Value -= 10;
        }

        private void moverAntenas(object sender, MouseButtonEventArgs e)
        {
            Storyboard sbAntenas = (Storyboard)cvAntenas.Resources["moverAntenasKey"];
            sbAntenas.Begin();
        }

        private void moverAntenaIzq(object sender, MouseButtonEventArgs e)
        {
            Storyboard sbAntenaIzq = (Storyboard)cvAntenas.Resources["moverAntenaIzqKey"];
            sbAntenaIzq.Begin();
        }
    }
}

﻿using System;
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
            t1.Interval = TimeSpan.FromSeconds(5.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }



        private void btDormir_Click(object sender, RoutedEventArgs e)
        {
            pbEnergia.Value += 20;
             
            Storyboard sbCerrarOjoIzq = (Storyboard)ojoIzq.Resources["cerrarOjoIzqKey"];
            Storyboard sbCerrarOjoDer = (Storyboard)ojoDer.Resources["cerrarOjoDerKey"];
            Storyboard sbCerrarPupilaIzq = (Storyboard)pupilaIzq.Resources["pupilaIzqCerrarKey"];
            Storyboard sbCerrarPupilaDer = (Storyboard)pupilaDer.Resources["pupilaDerCerrarKey"];
            sbCerrarOjoIzq.Begin();
            sbCerrarOjoDer.Begin();
            sbCerrarPupilaDer.Begin();
            sbCerrarPupilaIzq.Begin();

        }

        private void btComer_Click(object sender, RoutedEventArgs e)
        {
            pbApetito.Value += 20;
            Storyboard comer;
            comer = (Storyboard)this.Resources["sbComer"];
            comer.SpeedRatio = 4.0;
            comer.Begin(this);


        }

        private void btJugar_Click(object sender, RoutedEventArgs e)
        {
            cvMariposa.Visibility = Visibility.Visible;
            pbDiversion.Value += 20;
            Storyboard mariposa;
            mariposa = (Storyboard)this.Resources["sbMariposa"];
            mariposa.SpeedRatio = 3.0;
            mariposa.Begin(this);
            Storyboard jugar;
            jugar = (Storyboard)this.Resources["sbJugar"];
            jugar.SpeedRatio = 4.0;
            jugar.Begin(this);

            /*ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 20, 150);
            volarCanvas.AutoReverse = true;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(2));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);*/
        }
        private void reloj(object sender, EventArgs e)
        {
            pbEnergia.Value -= 10;
            pbApetito.Value -= 10;
            pbDiversion.Value -= 10;

            if(pbEnergia.Value == 10)
            {
                Storyboard sueno;
                sueno = (Storyboard)this.Resources["sbCansado"];
                sueno.Begin(this);
                //Deja de mover los ojos. No funciona
                Storyboard ojosCerrados;
                ojosCerrados = (Storyboard)this.Resources["sbMoverParpado"];
                ojosCerrados.Stop(this);

            }

            if (pbApetito.Value == 10)
            {
                
                elLengua.Visibility = Visibility.Visible;
                Storyboard hambre;
                hambre = (Storyboard)this.Resources["sbHambre"];
                hambre.Begin(this);
                //Ocultar la lengua despues de mostrar hambre???
               //elLengua.Visibility = Visibility.Hidden;

            }
            if(pbApetito.Value == 90)
            {
               
                Storyboard sbGordo = (Storyboard)aro5.Resources["gordoComerKey"];
                sbGordo.Begin();
            }

            if(pbDiversion.Value == 10)
            {
                Storyboard aburrido;
                aburrido = (Storyboard)this.Resources["sbAburrido"];
                aburrido.Begin(this);
            }

            if (pbDiversion.Value == 90)
            {
                Storyboard alegre;
                alegre = (Storyboard)this.Resources["sbAlegre"];
                alegre.Begin(this);
            }

        }

        private void moverAntenas(object sender, MouseButtonEventArgs e)
        {
           /* Storyboard sbAntenas = (Storyboard)cvAntenas.Resources["moverAntenasKey"];
            sbAntenas.Begin();*/
        }

        private void moverAntenaIzq(object sender, MouseButtonEventArgs e)
        {
            /*Storyboard sbAntenaIzq = (Storyboard)cvAntenas.Resources["moverAntenaIzqKey"];
            sbAntenaIzq.Begin();*/
        }

      
        private void alegrar(object sender, MouseButtonEventArgs e)
        {
            Storyboard sbAlegrar = (Storyboard)cvCabeza.Resources["subirCabezaKey"];
            Storyboard sbPupilaIzq = (Storyboard)pupilaIzq.Resources["pupilaIzqGrandeKey"];
            Storyboard sbPupilaDer = (Storyboard)pupilaDer.Resources["pupilaDerGrandeKey"];
            sbAlegrar.Begin();
            sbPupilaIzq.Begin();
            sbPupilaDer.Begin();

        }

        //Salta al tocarle el pie1
        private void saltar1(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin; 
            volarCanvas.To = new Thickness(0, 0, 0, 150);
            volarCanvas.AutoReverse = false;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(1));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
        }
        //Salta al tocarle el pie2
        private void saltar2(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation volarCanvas = new ThicknessAnimation();

            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 0, 150);
            volarCanvas.AutoReverse = false;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(1));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
        }
        //Salta al tocarle el pie3
        private void saltar3(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 0, 150);
            volarCanvas.AutoReverse = false;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(1));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
        }
        //Salta al tocarle el pie4
        private void saltar4(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation volarCanvas = new ThicknessAnimation();
            volarCanvas.From = cvHeimlich.Margin;
            volarCanvas.To = new Thickness(0, 0, 0, 150);
            volarCanvas.AutoReverse = false;
            volarCanvas.Duration = new Duration(TimeSpan.FromSeconds(1));
            cvHeimlich.BeginAnimation(Canvas.MarginProperty, volarCanvas);
        }
    }
}

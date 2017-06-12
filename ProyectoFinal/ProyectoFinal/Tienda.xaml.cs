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
    /// Lógica de interacción para Tienda.xaml
    /// </summary>
    public partial class Tienda : Window
    {

        int puntos;
        MainWindow padre;
        TextBlock txt;
        int contadorFondo2 = 0;
        int contadorFondo1 = 0;
        int contadorFondo3 = 0;
        int contadorFondo4 = 0;


        public Tienda(int puntos, TextBlock txt, MainWindow padre_)
        {
            padre = padre_;
            InitializeComponent();
            toopTils();
            this.puntos = puntos;
            this.txt = txt;
            txtExp.Text = puntos.ToString();
        }

        public void toopTils()
        { 
            btnFondo1.ToolTip = "Comprar Fondo 1";
            btnFondo2.ToolTip = "Comprar Fondo 2";
            btnFondo3.ToolTip = "Comprar Fondo 3";
            btnFondo4.ToolTip = "Comprar Fondo 4";
            lblFondos.ToolTip = "Haz click en los fondos para comprar alguno de ellos y canjearlos por puntos.";
        }
        private void btnFondo2_click(object sender, RoutedEventArgs e)
        {

            if (contadorFondo2 > 0)
            {

                padre.cambiarFondo2();
            }
            else {
                if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 20", "Comprar Fondo 2",
             MessageBoxButton.YesNo, MessageBoxImage.Question)
              == MessageBoxResult.Yes)
                 {
               
                    if (this.puntos < 20)
                    {
                        MessageBox.Show("No tienes suficientes puntos para comprarlo",
                  "Puntos insuficientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (this.puntos >= 20)
                    {
                        puntos = puntos - 20;
                        txtExp.Text = puntos.ToString();
                        padre.cambiarFondo2();

                    }
                }
            }
            contadorFondo2 += 1;
        }

        private void btnFondo1_click(object sender, RoutedEventArgs e)
        {
            if (contadorFondo1 > 0)
            {

                padre.cambiarFondo1();
            }
            else {
                if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 30", "Comprar Fondo 1",
            MessageBoxButton.YesNo, MessageBoxImage.Question)
             == MessageBoxResult.Yes)
                {
                    if (this.puntos < 30)
                    {
                        MessageBox.Show("No tienes suficientes puntos para comprarlo",
                  "Puntos insuficientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (this.puntos >= 30)
                    {
                        puntos = puntos - 30;
                        txtExp.Text = puntos.ToString();
                        padre.cambiarFondo1();

                    }
                }
            }
            contadorFondo1 += 1;
        }


        private void terminar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txt.Text = puntos.ToString();
        }

        private void btnFondo3_click(object sender, RoutedEventArgs e)
        {
            if (contadorFondo3 > 0)
            {

                padre.cambiarFondo3();
            }
            else
            {
                if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 15", "Comprar Fondo 3",
            MessageBoxButton.YesNo, MessageBoxImage.Question)
             == MessageBoxResult.Yes)
                {
                    if (this.puntos < 15)
                    {
                        MessageBox.Show("No tienes suficientes puntos para comprarlo",
                  "Puntos insuficientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (this.puntos >= 15)
                    {
                        puntos = puntos - 15;
                        txtExp.Text = puntos.ToString();
                        padre.cambiarFondo3();

                    }
                }
            }
            contadorFondo3 += 1;
        }

        private void btnFondo4_click(object sender, RoutedEventArgs e)
        {
            if (contadorFondo4 > 0)
            {

                padre.cambiarFondo4();
            }
            else
            {
                if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 50", "Comprar Fondo 4",
            MessageBoxButton.YesNo, MessageBoxImage.Question)
             == MessageBoxResult.Yes)
                {
                    if (this.puntos < 50)
                    {
                        MessageBox.Show("No tienes suficientes puntos para comprarlo",
                  "Puntos insuficientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (this.puntos >= 50)
                    {
                        puntos = puntos - 50;
                        txtExp.Text = puntos.ToString();
                       
                        padre.cambiarFondo4();

                    }
                }
            }
            contadorFondo4 += 1;
        }
    }
}

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


        public Tienda(int puntos, TextBlock txt, MainWindow padre_)
        {
            padre = padre_;
            InitializeComponent();
            this.puntos = puntos;
            this.txt = txt;
            txtExp.Text = puntos.ToString();
        }

        /*public Tienda(MainWindow padre_)
        {
            padre = padre_;

            InitializeComponent();
            txtExp.Text = padre.contador();
        }*/

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
    }
}

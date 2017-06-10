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

        public Tienda(int puntos)
        {
            InitializeComponent();
            this.puntos = puntos;
            txtExp.Text = puntos.ToString();
        }

        private void btnFondo2_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 20", "Comprar Fondo 2",
             MessageBoxButton.YesNo, MessageBoxImage.Question)
              == MessageBoxResult.Yes)
            {
                puntos = puntos - 20;
                txtExp.Text = puntos.ToString();
                //poner fondo en la ventana principal
            }
        }

        private void btnFondo1_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea adquirir este fondo? Puntos = 30", "Comprar Fondo 1",
            MessageBoxButton.YesNo, MessageBoxImage.Question)
             == MessageBoxResult.Yes)
            {
                puntos = puntos - 30;
                txtExp.Text = puntos.ToString();
            }
        }
    }
}

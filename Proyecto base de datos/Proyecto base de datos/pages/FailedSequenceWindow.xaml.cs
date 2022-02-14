using Proyecto_base_de_datos.pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.pages
{
    /// <summary>
    /// Interaction logic for FailedSequenceWindow.xaml
    /// </summary>
    public partial class FailedSequenceWindow : Window
    {
        public FailedSequenceWindow(string ErrorMessage)
        {
            InitializeComponent();
            ErrorText.Text = ErrorMessage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

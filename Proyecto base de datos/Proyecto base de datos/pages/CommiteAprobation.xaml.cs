using Proyecto_base_de_datos.Class;
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

namespace Proyecto_base_de_datos.Pages
{
    /// <summary>
    /// Interaction logic for CommiteAprobation.xaml
    /// </summary>
    public partial class CommiteAprobation : Window
    {
        public CommiteAprobation(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            titleTextBlock.Text = degreeWorks.Title;
            modalityTextBlock.Text = degreeWorks.Title;
            correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();
          
        }

        private void approveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}

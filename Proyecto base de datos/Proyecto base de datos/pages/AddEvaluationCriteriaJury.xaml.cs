using Npgsql;
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
    /// Interaction logic for AddEvaluationCriteriaJury.xaml
    /// </summary>
    public partial class AddEvaluationCriteriaJury : Window
    {

        DegreeWorks degreeWorks;
        private List<String> listIDCriteria;
        public AddEvaluationCriteriaJury(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            if (degreeWorks.Modality == "I")
            {
                
            }
            else if (degreeWorks.Modality == "E")
            {
              
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

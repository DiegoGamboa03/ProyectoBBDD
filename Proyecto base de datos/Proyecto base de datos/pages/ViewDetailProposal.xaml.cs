using System;
using Proyecto_base_de_datos.Class;
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
    /// Interaction logic for ViewDetailProposal.xaml
    /// </summary>
    public partial class ViewDetailProposal : Window
    {
        public ViewDetailProposal(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            nrocorr.Text = degreeWorks.CorrelativeNumber.ToString();
            titlepro.Text = degreeWorks.Title;
            date.Text = degreeWorks.CreationDate;
            if (degreeWorks.Modality == "I")
                modality.Text = "Instrumental";
            else
                modality.Text = "Experimental";
            observations.Text = degreeWorks.Observations;
            ncouncil.Text = degreeWorks.CouncilNumber;
            ncomitte.Text = degreeWorks.IdCouncil;
            student.Visibility = Visibility.Collapsed;
            studentName1.Text = "Nombre de prueba";
            studentName2.Text = "Nombre de prueba";

        }
    }
}

using Npgsql;
using Proyecto_base_de_datos.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ReviewerAprobationWindow.xaml
    /// </summary>
    public partial class ReviewerAprobationWindow : Window
    {
        DegreeWorks degreeWorks;
        EvaluationCriteria evaluationCriteria;
        public ReviewerAprobationWindow(DegreeWorks degreeWorks, EvaluationCriteria evaluationCriteria)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            Trace.WriteLine("En reviwerAprobationwindow: " + degreeWorks.CorrelativeNumber.ToString());
            this.evaluationCriteria = evaluationCriteria;
            this.titleTextBlock.Text = degreeWorks.Title;
            this.modalityTextBlock.Text = degreeWorks.Modality;
            this.correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();
            this.evaluationCriteriaTitleTextBlock.Text = evaluationCriteria.Description; 
        }

        private void ApprobationButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            if (degreeWorks.Modality == "I")
            {
                Trace.WriteLine("En reviwerAprobationwindow: " + degreeWorks.CorrelativeNumber.ToString());
                using (var command = new NpgsqlCommand("UPDATE evaluacriterioi SET aprueba = true WHERE ncorrelativo = '"+ degreeWorks.CorrelativeNumber.ToString() + "' AND codigo = @n2", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }else if(degreeWorks.Modality == "E")
            {
                using (var command = new NpgsqlCommand("UPDATE evaluacriterioe SET aprueba = true WHERE ncorrelativo = '"+ degreeWorks.CorrelativeNumber.ToString() + "' AND codigo = @n2", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }
            this.Close();
        }

        private void disapprovalButton_Click(object sender, RoutedEventArgs e)
        {
            conn.openConnection();
            if (degreeWorks.Modality == "I")
            {
                using (var command = new NpgsqlCommand("UPDATE evaluacriterioi SET aprueba = false WHERE ncorrelativo = '" + degreeWorks.CorrelativeNumber.ToString() +"' AND codigo = @n2", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }
            else if (degreeWorks.Modality == "E")
            {
                using (var command = new NpgsqlCommand("UPDATE evaluacriterioe SET aprueba = false WHERE ncorrelativo = '"+ degreeWorks.CorrelativeNumber.ToString() +"' AND codigo = @n2", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }
            this.Close();
        }
    }
}

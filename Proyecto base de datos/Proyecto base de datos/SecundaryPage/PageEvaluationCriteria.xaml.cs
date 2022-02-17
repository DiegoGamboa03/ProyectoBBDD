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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for PageEvaluationCriteria.xaml
    /// </summary>
    public partial class PageEvaluationCriteria : Page
    {

        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                numberupdownTextBox.Text = value.ToString();
            }
        }

        public PageEvaluationCriteria()
        {
            InitializeComponent();
            numberupdownTextBox.Text = _numValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();

            if (reviewerExperimentalRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevpr_e (codigo,descripcion,estatus) VALUES (nextval('secuenciacriteriosevpr_e'),@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if(reviewerInstrumentalRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevpr_i (codigo,descripcion,estatus) VALUES (nextval('secuenciacriteriosevpr_i'),@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if(JuryExperimentalRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevj_e (codigo,puntajemax,descripcion,estatus) VALUES (nextval('secuenciacriteriosevj_e'), @n1,@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if(JuryInstrumentalRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevj_i (codigo,puntajemax,descripcion,estatus) VALUES (nextval('secuenciacriteriosevj_i'), @n1,@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if (tutorExperimentalRadioButton.IsChecked == true) 
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevta_e (codigo,puntajemax,descripcion,estatus) VALUES (nextval('secuenciacriteriosevta_e'), @n1,@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if (tutorInstrumentalRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevta_i (codigo,puntajemax,descripcion,estatus) VALUES (nextval('secuenciacriteriosevta_i'), @n1,@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
            else if(businessTutorRadioButton.IsChecked == true)
            {
                using (var command = new NpgsqlCommand("INSERT INTO criteriosevte_i (codigo,puntajemax,descripcion,estatus) VALUES (nextval('secuenciacriteriosevte_i'), @n1,@n2,'A')", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("n2", descriptionTextBox.Text.Trim());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
        }

        private void numberupdownTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (numberupdownTextBox == null)
            {
                return;
            }

            if (!int.TryParse(numberupdownTextBox.Text, out _numValue))
                numberupdownTextBox.Text = _numValue.ToString();
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumValue < 20)
            {
                NumValue++;
            }
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumValue > 0)
            {
                NumValue--;
            }
        }
    }
}

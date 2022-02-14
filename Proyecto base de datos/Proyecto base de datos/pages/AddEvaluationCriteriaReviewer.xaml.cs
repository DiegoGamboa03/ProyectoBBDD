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
    /// Interaction logic for AddEvaluationCriteriaReviewer.xaml
    /// </summary>
    public partial class AddEvaluationCriteriaReviewer : Window
    {
        DegreeWorks degreeWorks;
        private List<String> listIDCriteria;
        public AddEvaluationCriteriaReviewer(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            var conn = new Connection();
            conn.openConnection();
            if (degreeWorks.Modality == "I")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM criteriosevpr_i WHERE estatus = 'A'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String id = (String)reader["codigo"];
                        int topNote = Int32.Parse((String)reader["puntajemax"]);
                        String description = (String)reader["descripcion"];
                        String status = (String)reader["estatus"];
                        listIDCriteria.Add(id);
                        evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                    }
                    reader.Close();
                }
            }
            else if (degreeWorks.Modality == "E")
            {

                using (var command = new NpgsqlCommand("SELECT * FROM criteriosevpr_e WHERE estatus = 'A'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String id = (String)reader["codigo"];
                        int topNote = Int32.Parse((String)reader["puntajemax"]);
                        String description = (String)reader["descripcion"];
                        String status = (String)reader["estatus"];
                        listIDCriteria.Add(id);
                        evaluationCriteriaComboBox.Items.Add(id + ", " + description +", " + status);

                    }
                    reader.Close();
                }
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (evaluationCriteriaComboBox.SelectedIndex != -1)
            {
                if (degreeWorks.Modality == "I")
                {
                    var conn = new Connection();
                    conn.openConnection();
                    using (var command = new NpgsqlCommand("INSERT INTO evaluacriterioi (ncorrelativo, codigo) VALUES (@n1, @n2)", conn.conn))
                    {
                        command.Parameters.AddWithValue("n1", degreeWorks.CorrelativeNumber);
                        command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    var conn = new Connection();
                    conn.openConnection();
                    using (var command = new NpgsqlCommand("INSERT INTO evaluacriterioe (ncorrelativo, codigo) VALUES (@n1, @n2)", conn.conn))
                    {
                        command.Parameters.AddWithValue("n1", degreeWorks.CorrelativeNumber);
                        command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }
                }
                this.Close();
            }else 
            {
                //Mensaje de error
            }
        }
    }
}

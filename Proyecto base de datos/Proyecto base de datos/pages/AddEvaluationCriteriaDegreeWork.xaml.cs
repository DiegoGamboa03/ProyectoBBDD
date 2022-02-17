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
    /// Interaction logic for AddEvaluationCriteriaDegreeWork.xaml
    /// </summary>
    public partial class AddEvaluationCriteriaDegreeWork : Window
    {
        DegreeWorks degreeWorks;
        bool isTutor;
        private List<String> listIDCriteria;
        private List<String> listIDStudents;
        public AddEvaluationCriteriaDegreeWork(DegreeWorks degreeWorks,bool isTutor)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.degreeWorks = degreeWorks;
            this.isTutor = isTutor;
            listIDCriteria = new List<string>();
            listIDStudents = new List<string>();
            var conn = new Connection();
            conn.openConnection();
            if (isTutor)
            {
                if(degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM criteriosevta_i WHERE estatus = 'A'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String id = (String)reader["codigo"];
                            Trace.WriteLine(id);
                            int topNote = (int)reader["puntajemax"];
                            String description = (String)reader["descripcion"];
                            String status = (String)reader["estatus"];
                            listIDCriteria.Add(id);
                            evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                        }
                        reader.Close();
                    }
                }
                else if(degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM criteriosevta_e WHERE estatus = 'A'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String id = (String)reader["codigo"];
                            int topNote = (int)reader["puntajemax"];
                            String description = (String)reader["descripcion"];
                            String status = (String)reader["estatus"];
                            listIDCriteria.Add(id);
                            evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                        }
                        reader.Close();
                    }
                }
            }
            else
            {
                if (degreeWorks.Modality == "I")
                {
                    if (MainWindow.teachers.Type == "T")
                    {
                        using (var command = new NpgsqlCommand("SELECT * FROM criteriosevte_i WHERE estatus = 'A'", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String id = (String)reader["codigo"];
                                Trace.WriteLine(id);
                                int topNote = (int)reader["puntajemax"];
                                String description = (String)reader["descripcion"];
                                String status = (String)reader["estatus"];
                                listIDCriteria.Add(id);
                                evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                            }
                            reader.Close();
                        }
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand("SELECT * FROM criteriosevj_i WHERE estatus = 'A'", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String id = (String)reader["codigo"];
                                int topNote = (int)reader["puntajemax"];
                                String description = (String)reader["descripcion"];
                                String status = (String)reader["estatus"];
                                listIDCriteria.Add(id);
                                evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                            }
                            reader.Close();
                        }
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM criteriosevj_e WHERE estatus = 'A'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String id = (String)reader["codigo"];
                            int topNote = (int)reader["puntajemax"];
                            String description = (String)reader["descripcion"];
                            String status = (String)reader["estatus"];
                            listIDCriteria.Add(id);
                            evaluationCriteriaComboBox.Items.Add(id + ", " + description + ", " + status);

                        }
                        reader.Close();
                    }
                }
            }

            using (var command = new NpgsqlCommand("SELECT * FROM entrega WHERE ncorrelativo = '"+ degreeWorks.CorrelativeNumber +"'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String id = (String)reader["cedulae"];
                    listIDStudents.Add(id);
                }
                reader.Close();
            }
            Trace.WriteLine(listIDStudents.Count);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            if (isTutor)
            {
                for(int i = 0; i < listIDStudents.Count; i++)
                {
                    Trace.WriteLine(i);
                    Trace.WriteLine(listIDStudents[i]);
                    if (degreeWorks.Modality == "I")
                    {
                        using (var command = new NpgsqlCommand("INSERT INTO evaluacriteriota_i (cedulap, codigo,cedulae) VALUES (@n1, @n2, @n3)", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", MainWindow.teachers.Id);
                            command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                            command.Parameters.AddWithValue("n3", listIDStudents[i]);
                            int nRows = command.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }
                    }
                    else if (degreeWorks.Modality == "E")
                    {
                        using (var command = new NpgsqlCommand("INSERT INTO evaluacriteriota_e (cedulap, codigo,cedulae) VALUES (@n1, @n2, @n3)", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", MainWindow.teachers.Id);
                            command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                            command.Parameters.AddWithValue("n3", listIDStudents[i]);
                            int nRows = command.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < listIDStudents.Count; i++)
                {
                    Trace.WriteLine(i);
                    Trace.WriteLine(listIDStudents[i]);
                    if (degreeWorks.Modality == "I")
                    {
                        if (MainWindow.teachers.Type == "T")
                        {
                            using (var command = new NpgsqlCommand("INSERT INTO evaluacriteriote_i (cedulap, codigo,cedulae) VALUES (@n1, @n2, @n3)", conn.conn))
                            {
                                command.Parameters.AddWithValue("n1", MainWindow.teachers.Id);
                                command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                                command.Parameters.AddWithValue("n3", listIDStudents[i]);
                                int nRows = command.ExecuteNonQuery();
                                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                            }
                        }
                        else
                        {
                            using (var command = new NpgsqlCommand("INSERT INTO evaluacriterioj_i (cedulap, codigo,cedulae) VALUES (@n1, @n2, @n3)", conn.conn))
                            {
                                command.Parameters.AddWithValue("n1", MainWindow.teachers.Id);
                                command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                                command.Parameters.AddWithValue("n3", listIDStudents[i]);
                                int nRows = command.ExecuteNonQuery();
                                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                            }
                        }
                    }
                    else if (degreeWorks.Modality == "E")
                    {
                        using (var command = new NpgsqlCommand("INSERT INTO evaluacriterioj_e (cedulap, codigo,cedulae) VALUES (@n1, @n2, @n3)", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", MainWindow.teachers.Id);
                            command.Parameters.AddWithValue("n2", listIDCriteria[evaluationCriteriaComboBox.SelectedIndex]);
                            command.Parameters.AddWithValue("n3", listIDStudents[i]);
                            int nRows = command.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }
                    }
                }
            }
        }
    }
}

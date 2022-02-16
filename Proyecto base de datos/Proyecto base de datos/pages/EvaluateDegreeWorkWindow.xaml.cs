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
    /// Interaction logic for EvaluateDegreeWorkWindow.xaml
    /// </summary>
    public partial class EvaluateDegreeWorkWindow : Window
    {
        DegreeWorks degreeWorks;
        bool isTutor;
        String studentId;
        private List<EvaluationCriteria> evaluationCriteriaList;
        public EvaluateDegreeWorkWindow(DegreeWorks degreeWorks, bool isTutor, Students student)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            this.isTutor = isTutor;
            this.studentId = student.Id;
            this.TitleTDG.Text = degreeWorks.Title;
            this.StudentName.Text = student.Name;
            evaluationCriteriaList = new List<EvaluationCriteria>();
            var conn = new Connection();
            conn.openConnection();
            if (isTutor)
            {
                if(degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriteriota_i as ETI, criteriosevta_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '"+ MainWindow.teachers.Id +"' AND ETI.cedulae = '"+ studentId +"';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            int maxNote = (int)reader["puntajemax"];
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
                else if(degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriteriota_e as ETI, criteriosevta_e as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            int maxNote = (int)reader["puntajemax"];
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
            }
            else
            {
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriterioj_i as ETI, criteriosevj_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            int maxNote = (int)reader["puntajemax"];
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriterioj_e as ETI, criteriosevj_e as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            int maxNote = (int)reader["puntajemax"];
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
            }
        }

        void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;
            DegreeWorkEvaluationCriteriaCalification page = new DegreeWorkEvaluationCriteriaCalification(degreeWorks, evaluationCriteriaList[item],studentId,isTutor);
            page.ShowDialog();
        }

        private void criteriaEvaluationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            long finalNote = 0;
            if (isTutor)
            {
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) as notaTotal FROM evaluacriteriota_i WHERE cedulap = '"+ MainWindow.teachers.Id +"' AND cedulae = '"+ studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            finalNote = (long)reader["notaTotal"];
                        }
                        reader.Close();
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) as notaTotal FROM evaluacriteriota_i WHERE cedulap = '" + MainWindow.teachers.Id + "' AND cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            finalNote = (long)reader["notaTotal"];
                        }
                        reader.Close();
                    }
                }
            }
            else
            {
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) as notaTotal FROM evaluacriterioj_i WHERE cedulap = '" + MainWindow.teachers.Id + "' AND cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            finalNote = (long)reader["notaTotal"];
                        }
                        reader.Close();
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) as notaTotal FROM evaluacriterioj_e WHERE cedulap = '" + MainWindow.teachers.Id + "' AND cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            finalNote = (long)reader["notaTotal"];
                        }
                        reader.Close();
                    }
                }
            }

            using (var command = new NpgsqlCommand("INSERT INTO defensas (cedulae, codigod,notaf,fechap,horap) VALUES (@n1,nextval('secuenciaDefensaPK'), @n3,@n4,@n5)", conn.conn))
            {
                String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                DateTime dateTime = DateTime.Parse(dateTimeString);
                String dateHourString = DateTime.Now.ToString("HH:mm:ss");
                DateTime dateHour = DateTime.Parse(dateHourString);
                command.Parameters.AddWithValue("n1", studentId);
                command.Parameters.AddWithValue("n3", finalNote);
                command.Parameters.AddWithValue("n4", dateTime);
                command.Parameters.AddWithValue("n5", dateHour);
                command.ExecuteNonQuery();
            }
        }
    }
}

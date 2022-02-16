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

        private List<string> EvaluatedTeachersList;

        private List<string> EvaluatedTeachersListAux;
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
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM evaluacriteriota_i as ETI, criteriosevta_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            Trace.WriteLine(evaluationCriteriaID + "  " + description);
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM evaluacriteriota_e as ETI, criteriosevta_e as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            Trace.WriteLine(evaluationCriteriaID + "  " + description);
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description);
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
                    using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioj_i as ETI, criteriosevj_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];                           
                            String description = (String)reader["descripcion"];
                            Trace.WriteLine(evaluationCriteriaID + "  " +description);
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description);
                            evaluationCriteriaList.Add(evaluationCriteria);
                            criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                        }
                        reader.Close();
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioj_e as ETE, criteriosevj_e as CTE WHERE ETE.codigo = CTE.codigo AND ETE.cedulap = '" + MainWindow.teachers.Id + "' AND ETE.cedulae = '" + studentId + "'", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String evaluationCriteriaID = (String)reader["codigo"];
                            String description = (String)reader["descripcion"];
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description);
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
            DegreeWorkEvaluationCriteriaCalification page = new DegreeWorkEvaluationCriteriaCalification(degreeWorks, evaluationCriteriaList[item], studentId, isTutor);
            page.ShowDialog();
        }

        private void criteriaEvaluationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Variables de conexión.
            var conn = new Connection();
            conn.openConnection();

            //Variable de notaFinal.
            long finalNote = 0;

            //Inicialización de las listas.
            EvaluatedTeachersList = new List<string>();
            EvaluatedTeachersListAux = new List<string>();

            //Se obtiene todos los profesores que son jurados de ese trabajo de grado.
            using (var command = new NpgsqlCommand("SELECT * FROM asignaj WHERE ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Guarda las cedulas de los profesores que son jurados de ese trabajo de grado.
                    String idTeacher = (String)reader["cedulap"];
                    EvaluatedTeachersList.Add(idTeacher);
                }
                reader.Close();
            }
            //Por profesor, ver si ya corrigieron todos los criterios de evaluación del estudiante.
            for (int i = 0; i < EvaluatedTeachersList.Count; i++)
            {
                //Indica si algun criterio es nulo
                var EvaluatedCriterias = 0;

                //Revisa el tipo de propuesta
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT COUNT(DISTINCT codigo) AS criteriosevaluados FROM evaluacriterioj_i WHERE cedulap = '" + EvaluatedTeachersList[i] + "' AND  cedulae = '" + idStudent + "' AND nota IS NOT NULL GROUP BY cedulap HAVING COUNT(DISTINCT codigo) = COUNT(nota)" , conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            EvaluatedCriterias = (int)reader["criteriosevaluados"];
                        }
                        Trace.WriteLine(EvaluatedCriterias);
                        reader.Close ();
                    }
                }
                else
                {
                    using (var command = new NpgsqlCommand("SELECT COUNT(DISTINCT codigo) AS criteriosevaluados FROM evaluacriterioj_e WHERE cedulap = '" + EvaluatedTeachersList[i] + "' AND  cedulae = '" + idStudent + "' AND nota IS NOT NULL GROUP BY cedulap HAVING COUNT(DISTINCT codigo) = COUNT(nota)", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            EvaluatedCriterias = (int)reader["criteriosevaluados"];
                        }
                        Trace.WriteLine(EvaluatedCriterias);
                        reader.Close ();
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
}

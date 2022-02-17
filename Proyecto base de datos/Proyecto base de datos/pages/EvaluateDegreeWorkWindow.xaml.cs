using Npgsql;
using Proyecto_base_de_datos.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            var conn = new Connection();
            conn.openConnection();
            long tutorTotalEvaluationCriteria = 0;
            long tutorEvaluationCriteriaEvaluated = 0;
            bool tutorFinished = false;
            if (degreeWorks.Modality == "I")
            {
                //Encontrar cedula del tutor
                using (var command = new NpgsqlCommand("SELECT DISTINCT(cedulapi) FROM trabajos_de_grado as TG, evaluacriteriota_i as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String tutorID = (String)reader["cedulapi"];
                        Trace.WriteLine("TutorID: " + tutorID);
                    }
                    reader.Close();
                }
                //Encontrar el total de criterios asociados a ese profesor
                using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM trabajos_de_grado as TG, evaluacriteriota_i as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorTotalEvaluationCriteria = (long)reader["count"];
                        Trace.WriteLine("Total de criterios que tiene este profesor tutor" + tutorTotalEvaluationCriteria);

                    }
                    reader.Close();
                }

                using (var command = new NpgsqlCommand("SELECT COUNT(EC.codigo) FROM trabajos_de_grado as TG, evaluacriteriota_i as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "' AND EC.nota is NOT NULL;", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorEvaluationCriteriaEvaluated = (long)reader["count"];
                        Trace.WriteLine("Total de criterios evaluados por este profesor" + tutorEvaluationCriteriaEvaluated);

                    }
                    reader.Close();
                }


            }
            
            else if(degreeWorks.Modality == "E")
            {
                //Encontrar cedula del tutor
                using (var command = new NpgsqlCommand("SELECT DISTINCT(cedulapi) FROM trabajos_de_grado as TG, evaluacriteriota_e as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String tutorID = (String)reader["cedulapi"];
                        Trace.WriteLine("TutorID: " + tutorID);
                    }
                    reader.Close();
                }
                //Encontrar el total de criterios asociados a ese profesor
                using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM trabajos_de_grado as TG, evaluacriteriota_e as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorTotalEvaluationCriteria = (long)reader["count"];
                        Trace.WriteLine("Total de criterios que tiene este profesor tutor" + tutorTotalEvaluationCriteria);

                    }
                    reader.Close();
                }

                using (var command = new NpgsqlCommand("SELECT COUNT(EC.codigo) FROM trabajos_de_grado as TG, evaluacriteriota_e as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "' AND EC.nota is NOT NULL;", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorEvaluationCriteriaEvaluated = (long)reader["count"];
                        Trace.WriteLine("Total de criterios evaluados por este profesor" + tutorEvaluationCriteriaEvaluated);

                    }
                    reader.Close();
                }
            }

            if (tutorTotalEvaluationCriteria == tutorEvaluationCriteriaEvaluated && tutorEvaluationCriteriaEvaluated != 0 && tutorTotalEvaluationCriteria != 0)
                tutorFinished = true;

            List<String> listJury = new List<string>();
            using (var command = new NpgsqlCommand("SELECT AJ.cedulap FROM trabajos_de_grado as TG, asignaj as AJ WHERE TG.cedulapi != AJ.cedulap AND AJ.ncorrelativo = TG.ncorrelativo AND AJ.ncorrelativo = '"+ degreeWorks.CorrelativeNumber  +"'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String jury= (String)reader["cedulap"];
                    listJury.Add(jury);

                }
                reader.Close();
            }
            int completedJury = 0;
            List<String> listFinishedJury = new List<string>();
            for (int i = 0; i<listJury.Count; i++)
            {
                long juryTotalCriteria = 0;
                long juryEvaluatedCriteria = 0;
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM evaluacriterioj_i as EC WHERE EC.cedulap = '" + listJury[i] + "' AND EC.cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            juryTotalCriteria = (long)reader["count"];
                            Trace.WriteLine("Jurado " + listJury[i] + " criterios totales de este jurado " + juryTotalCriteria );
                        }
                        reader.Close();
                    }
                    using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM evaluacriterioj_i as EC WHERE EC.cedulap = '" + listJury[i] + "' AND EC.cedulae = '"+ studentId +"' AND EC.nota IS NOT NULL;", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            juryEvaluatedCriteria = (long)reader["count"];
                            Trace.WriteLine("Jurado " + listJury[i] + " criterios totales evaluados de este jurado " + juryEvaluatedCriteria);
                        }
                        reader.Close();
                    }
                }
                else if(degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM evaluacriterioj_e as EC WHERE EC.cedulap = '" + listJury[i] + "' AND EC.cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            juryTotalCriteria = (long)reader["count"];
                            Trace.WriteLine("Jurado " + listJury[i] + " criterios totales de este jurado " + juryTotalCriteria);
                        }
                        reader.Close();
                    }
                    using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM evaluacriterioj_e as EC WHERE EC.cedulap = '" + listJury[i] + "' AND EC.cedulae = '" + studentId + "' AND EC.nota IS NOT NULL;", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            juryEvaluatedCriteria = (long)reader["count"];
                            Trace.WriteLine("Jurado " + listJury[i] + " criterios totales evaluados de este jurado " + juryEvaluatedCriteria);
                        }
                        reader.Close();
                    }
                }

                if (juryTotalCriteria == juryEvaluatedCriteria && juryTotalCriteria == 0 && juryEvaluatedCriteria == 0)
                {
                    completedJury++;
                    listFinishedJury.Add(listJury[i]);
                }
                if(completedJury == 2)
                {
                    break;
                }
            }
            if(completedJury == 2 && tutorFinished)
            {

            }
        }
    }
}

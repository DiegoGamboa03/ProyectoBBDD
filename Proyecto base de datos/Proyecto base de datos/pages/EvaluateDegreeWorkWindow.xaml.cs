using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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

        public EvaluateDegreeWorkWindow(DegreeWorks degreeWorks, bool isTutor, Students student)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            this.isTutor = isTutor;
            this.studentId = student.Id;
            this.TitleTDG.Text = degreeWorks.Title;
            this.StudentName.Text = student.Name;
            this.idStudent.Text = student.Id;
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
                            int maxNote = (int)reader["puntajemax"];
                            Trace.WriteLine(evaluationCriteriaID + "  " + description);
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
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
                            int maxNote = (int)reader["puntajemax"];
                            Trace.WriteLine(evaluationCriteriaID + "  " + description);
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
                    if (MainWindow.teachers.Type == "T")
                    {
                        using (var command = new NpgsqlCommand("SELECT * FROM evaluacriteriote_i as ETI, criteriosevte_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "'", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String evaluationCriteriaID = (String)reader["codigo"];
                                String description = (String)reader["descripcion"];
                                int maxNote = (int)reader["puntajemax"];
                                Trace.WriteLine(evaluationCriteriaID + "  " + description);
                                EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                                evaluationCriteriaList.Add(evaluationCriteria);
                                criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                            }
                            reader.Close();
                        }
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioj_i as ETI, criteriosevj_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "'", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String evaluationCriteriaID = (String)reader["codigo"];
                                String description = (String)reader["descripcion"];
                                int maxNote = (int)reader["puntajemax"];
                                Trace.WriteLine(evaluationCriteriaID + "  " + description);
                                EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description,maxNote);
                                evaluationCriteriaList.Add(evaluationCriteria);
                                criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                            }
                            reader.Close();
                        }
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
            long empresarialTutorTotalEvaluationCriteria = 0;
            long empresarialTutorEvaluationCriteriaEvaluated = 0;
            bool tutorFinished = false;
            bool buissnesTutorFinished = false;
            String tutorID = null;
            String empresarialTutorID = null;
            if (degreeWorks.Modality == "I")
            {
                //Encontrar cedula del tutor
                using (var command = new NpgsqlCommand("SELECT DISTINCT(cedulapi) FROM trabajos_de_grado as TG, evaluacriteriota_i as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorID = (String)reader["cedulapi"];
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
                //Tutor empresarial
                using (var command = new NpgsqlCommand("SELECT PR.cedulap FROM instrumentales as I, profesores PR WHERE I.tutoremp = PR.nombre AND I.ncorrelativo = '"+ degreeWorks.CorrelativeNumber +"';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        empresarialTutorID = (String)reader["cedulap"];
                        Trace.WriteLine("Tutor empresarial: " + empresarialTutorID);
                    }
                    reader.Close();
                }
                using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM profesores as PR, evaluacriteriote_i as EC, instrumentales as I WHERE PR.cedulap = EC.cedulap AND EC.cedulae = '"+ studentId +"' AND I.tutoremp = PR.nombre;", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        empresarialTutorTotalEvaluationCriteria = (long)reader["count"];
                        Trace.WriteLine("Total de criterios que tiene este profesor tutor empresarial" + empresarialTutorTotalEvaluationCriteria);

                    }
                    reader.Close();
                }
                using (var command = new NpgsqlCommand("SELECT COUNT(codigo) FROM profesores as PR, evaluacriteriote_i as EC, instrumentales as I WHERE PR.cedulap = EC.cedulap AND EC.cedulae = '"+ studentId +"' AND I.tutoremp = PR.nombre AND EC.nota IS NOT NULL;", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        empresarialTutorEvaluationCriteriaEvaluated = (long)reader["count"];
                        Trace.WriteLine("Total de criterios evaluados por este profesor" + empresarialTutorEvaluationCriteriaEvaluated);

                    }
                    reader.Close();
                }
                if (empresarialTutorTotalEvaluationCriteria == empresarialTutorEvaluationCriteriaEvaluated && empresarialTutorTotalEvaluationCriteria != 0 && empresarialTutorEvaluationCriteriaEvaluated != 0)
                    buissnesTutorFinished = true;
            }
            
            else if(degreeWorks.Modality == "E")
            {
                //Encontrar cedula del tutor
                using (var command = new NpgsqlCommand("SELECT DISTINCT(cedulapi) FROM trabajos_de_grado as TG, evaluacriteriota_e as EC WHERE TG.cedulapi = EC.cedulap AND EC.cedulae = '" + studentId + "';", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tutorID = (String)reader["cedulapi"];
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

                if (juryTotalCriteria == juryEvaluatedCriteria && juryTotalCriteria != 0 && juryEvaluatedCriteria != 0)
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
                float accumulated = 0;
                for(int i = 0; i< listFinishedJury.Count; i++)
                {
                    if(degreeWorks.Modality == "I")
                    {
                        using (var command = new NpgsqlCommand("SELECT SUM(nota) FROM evaluacriterioj_i WHERE cedulap = '"+ listFinishedJury[i] +"' AND cedulae = '"+ studentId + "';", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Trace.WriteLine("Jurado: " + listFinishedJury[i]);
                                long totalNote = (long)reader["sum"];
                                accumulated = accumulated + totalNote;
                                Trace.WriteLine("Acumulado hasta ahora: " + accumulated);
                            }
                            reader.Close();
                        }
                    }
                    else if(degreeWorks.Modality == "E")
                    {
                        using (var command = new NpgsqlCommand("SELECT SUM(nota) FROM evaluacriterioj_e WHERE cedulap = '" + listFinishedJury[i] + "' AND cedulae = '"+ studentId +"';", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                long totalNote = (long)reader["sum"];
                                accumulated = accumulated + totalNote;
                                Trace.WriteLine("Acumulado hasta ahora: " + accumulated);
                            }
                            reader.Close();
                        }
                    }
                }
                if(degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) FROM evaluacriteriota_i WHERE cedulap = '"+ tutorID +"' AND cedulae = '"+ studentId +"';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            long totalNote = (long)reader["sum"];
                            accumulated = accumulated + totalNote;
                            Trace.WriteLine("Tutor Acumulado hasta ahora: " + accumulated);
                        }
                        reader.Close();
                    }
                    if (buissnesTutorFinished)
                    {
                        using (var command = new NpgsqlCommand("SELECT SUM(nota) FROM evaluacriteriote_i WHERE cedulap = '"+ empresarialTutorID + "' AND cedulae = '"+ studentId +"';", conn.conn))
                        {
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                long totalNote = (long)reader["sum"];
                                accumulated = accumulated + totalNote;
                                Trace.WriteLine("Tutor Acumulado hasta ahora: " + accumulated);
                            }
                            reader.Close();
                        }
                    }
                }
                else if(degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT SUM(nota) FROM evaluacriteriota_e WHERE cedulap = '" + tutorID + "' AND cedulae = '" + studentId + "';", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            long totalNote = (long)reader["sum"];
                            accumulated = accumulated + totalNote;
                            Trace.WriteLine("Tutor Acumulado hasta ahora: " + accumulated);
                        }
                        reader.Close();
                    }
                }
                float finalNote = accumulated;
                if (degreeWorks.Modality == "I" && buissnesTutorFinished)
                {
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
                    Trace.WriteLine("Inserto un dato");
                }else if(degreeWorks.Modality == "E")
                {
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
                else
                {
                    Trace.WriteLine("No Inserto un dato");
                }
                string ConfirmationMessage = "Se ingreso el dato";
                FailedSequenceWindow window = new FailedSequenceWindow(ConfirmationMessage);
                window.ShowDialog();
            }
            else
            {
                Trace.WriteLine("No la hizo");
            }
            this.Close();
        }
    }
}

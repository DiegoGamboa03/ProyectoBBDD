using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.Pages;
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

namespace Proyecto_base_de_datos.pages
{
    /// <summary>
    /// Interaction logic for ReviewerWindow.xaml
    /// </summary>
    public partial class ReviewerWindow : Window
    {
        public List<EvaluationCriteria> evaluationCriteriaList;
        private DegreeWorks degreeWorks;
        public ReviewerWindow(DegreeWorks DegreeWork)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.degreeWorks = DegreeWork;
            evaluationCriteriaList = new List<EvaluationCriteria>();
            var conn = new Connection();
            conn.openConnection();
            if (this.degreeWorks.Modality == "I")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioi as EI, criteriosevpr_i as CEI WHERE EI.ncorrelativo = '" + degreeWorks.CorrelativeNumber +"' AND EI.codigo = CEI.codigo", conn.conn))
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
            else if (this.degreeWorks.Modality == "E")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioe as EI, criteriosevpr_i as CEI WHERE EI.ncorrelativo = '46' AND EI.codigo = CEI.codigo", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String evaluationCriteriaID = (String)reader["codigo"];
                        String description = (String)reader["descripcion"];
                        criteriaEvaluationListBox.Items.Add(evaluationCriteriaID + ", " + description);
                    }
                    reader.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            bool flag = true;
            if (this.degreeWorks.Modality == "I")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioi as EI WHERE EI.ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bool approveCriteria = (bool)reader["aprueba"];
                        if(approveCriteria == false)
                        {
                            flag = false;
                        }
                    }
                    reader.Close();
                }
            }
            else if (this.degreeWorks.Modality == "E")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM evaluacriterioe as EI WHERE EI.ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bool approveCriteria = (bool)reader["aprueba"];
                        if (approveCriteria == false)
                        {
                            flag = false;
                        }
                    }
                    reader.Close();
                }
            }
            if (flag)
            {
                using (var command = new NpgsqlCommand("UPDATE esrevisor SET estatus = 'PAR', fecharev = @n2 WHERE ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
                {
                    String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    command.Parameters.AddWithValue("n2", dateTime);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }
            else //Si el alumno reprobo alguno de los criterios de evaluacion
            {
                using (var command = new NpgsqlCommand("UPDATE trabajos_de_grado SET espropuesta = null WHERE ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
                    command.ExecuteNonQuery();
                using (var command = new NpgsqlCommand("UPDATE esrevisor SET estatus = 'PRR', fecharev = @n2 WHERE ncorrelativo = '" + degreeWorks.CorrelativeNumber + "'", conn.conn))
                {
                    String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    command.Parameters.AddWithValue("n2", dateTime);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
            }

            //Aqui tengo que revisar en las tablas de evaluacriterioi y evaluacriterioe, que todos los criterios de este tg sean aprobados
        }
        void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;
            ReviewerAprobationWindow page = new ReviewerAprobationWindow(degreeWorks, evaluationCriteriaList[item]);
            page.ShowDialog();
        }
    }
}

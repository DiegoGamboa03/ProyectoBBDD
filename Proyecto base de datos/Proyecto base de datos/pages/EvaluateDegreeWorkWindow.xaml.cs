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
        public EvaluateDegreeWorkWindow(DegreeWorks degreeWorks, bool isTutor, String studentId)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            this.isTutor = isTutor;
            this.studentId = studentId;
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
                            Trace.WriteLine(evaluationCriteriaID);
                            EvaluationCriteria evaluationCriteria = new EvaluationCriteria(evaluationCriteriaID, description);
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
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriterioj_i as ETI, criteriosevj_i as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "';", conn.conn))
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
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("SELECT CTI.* FROM evaluacriterioj_e as ETI, criteriosevj_e as CTI WHERE ETI.codigo = CTI.codigo AND ETI.cedulap = '" + MainWindow.teachers.Id + "' AND ETI.cedulae = '" + studentId + "';", conn.conn))
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
            /*ReviewerAprobationWindow page = new ReviewerAprobationWindow(degreeWorks, evaluationCriteriaList[item]);
            page.ShowDialog();*/
        }

        private void criteriaEvaluationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

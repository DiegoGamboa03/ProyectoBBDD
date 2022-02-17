using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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

namespace Proyecto_base_de_datos.Pages
{
    /// <summary>
    /// Interaction logic for DegreeWorkEvaluationCriteriaCalification.xaml
    /// </summary>
    public partial class DegreeWorkEvaluationCriteriaCalification : Window
    {
        private int _numValue = 0;
        private DegreeWorks degreeWorks;
        private EvaluationCriteria evaluationCriteria;
        private String idStudent;
        private bool isTutor;
        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                numberupdownTextBox.Text = value.ToString();
            }
        }
        public DegreeWorkEvaluationCriteriaCalification(DegreeWorks degreeWorks, EvaluationCriteria evaluationCriteria, String idStudent, bool isTutor)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            numberupdownTextBox.Text = _numValue.ToString();
            this.degreeWorks = degreeWorks;
            this.evaluationCriteria = evaluationCriteria;
            this.idStudent = idStudent;
            this.isTutor = isTutor;
            this.maxNoteTextBlock.Text = evaluationCriteria.TopNote.ToString();
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
            if (NumValue < evaluationCriteria.TopNote)
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

        private void ApprobationButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            if (isTutor)
            {
                if (degreeWorks.Modality == "I")
                {
                    using (var command = new NpgsqlCommand("UPDATE evaluacriteriota_i SET nota = @n1 WHERE cedulae = '" + idStudent + "' AND codigo = @n2", conn.conn))
                    {
                        command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                        command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("UPDATE evaluacriteriota_e SET nota = @n1 WHERE cedulae = '" + idStudent + "' AND codigo = @n2", conn.conn))
                    {
                        command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                        command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                    }
                }
            }
            else
            {
                if (degreeWorks.Modality == "I")
                {
                    if (MainWindow.teachers.Type == "T")
                    {
                        using (var command = new NpgsqlCommand("UPDATE evaluacriteriote_i SET nota = @n1 WHERE cedulae = '" + idStudent + "' AND codigo = @n2", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                            command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                            int nRows = command.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                        }
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand("UPDATE evaluacriterioj_i SET nota = @n1 WHERE cedulae = '" + idStudent + "' AND codigo = @n2", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                            command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                            int nRows = command.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                        }
                    }
                }
                else if (degreeWorks.Modality == "E")
                {
                    using (var command = new NpgsqlCommand("UPDATE evaluacriterioj_e SET nota = @n1 WHERE cedulae = '" + idStudent + "' AND codigo = @n2", conn.conn))
                    {
                        command.Parameters.AddWithValue("n1", Int32.Parse(numberupdownTextBox.Text.Trim()));
                        command.Parameters.AddWithValue("n2", evaluationCriteria.Id);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                    }
                }

                string ConfirmationMessage = "Se ingreso el dato";
                FailedSequenceWindow window = new FailedSequenceWindow(ConfirmationMessage);
                window.ShowDialog();
            }

            this.Close(); 
        }
    }
}

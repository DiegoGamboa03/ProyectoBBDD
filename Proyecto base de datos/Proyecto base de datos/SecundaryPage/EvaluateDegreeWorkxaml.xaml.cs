using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for EvaluateDegreeWorkxaml.xaml
    /// </summary>
    public partial class EvaluateDegreeWorkxaml : Page
    {
        private List<DegreeWorks> listTutor;
        private List<DegreeWorks> listJury;
        public EvaluateDegreeWorkxaml()
        {
            InitializeComponent();
            listTutor = new List<DegreeWorks>();
            listJury = new List<DegreeWorks>();
            var conn = new Connection();
            conn.openConnection();
            //Saco una lista donde el profesor es tutor
            using (var command = new NpgsqlCommand("SELECT DISTINCT(TG.*) FROM asignaj as AJ, trabajos_de_grado as TG,entrega as E, defensas as DEF WHERE TG.cedulapi = '" + MainWindow.teachers.Id +"' AND TG.ncorrelativo = AJ.ncorrelativo AND TG.ncorrelativo = E.ncorrelativo AND E.cedulae != DEF.cedulae;", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                    String title = (String)reader["titulo"];
                    String modality = (String)reader["modalidad"];
                    DateTime dateTime = (DateTime)reader["fechacreacion"];

                    DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                    listTutor.Add(degreeWorks);
                    degreeWorkTutorListBox.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                }
                reader.Close();
            }
            //Saco una lista donde el profesor es jurado
            using (var command = new NpgsqlCommand("SELECT DISTINCT(TG.*) FROM asignaj as AJ, trabajos_de_grado as TG, defensas as DEF, entrega as E WHERE AJ.cedulap = '" + MainWindow.teachers.Id + "' AND TG.ncorrelativo = AJ.ncorrelativo AND TG.ncorrelativo = E.ncorrelativo AND E.cedulae != DEF.cedulae;", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                    String title = (String)reader["titulo"];
                    String modality = (String)reader["modalidad"];
                    DateTime dateTime = (DateTime)reader["fechacreacion"];

                    DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                    listJury.Add(degreeWorks);
                    degreeWorkJuryListBox.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                }
                reader.Close();
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            List<Students> listIDStudents = new List<Students>();
            var conn = new Connection();
            conn.openConnection();
            EvaluateDegreeWorkWindow page;
            Trace.WriteLine("Tutor list box" + degreeWorkTutorListBox.SelectedIndex);
            if (degreeWorkJuryListBox.SelectedIndex != -1)
            {
                using (var command = new NpgsqlCommand("SELECT * FROM entrega AS ET, estudiantes AS E WHERE ET.ncorrelativo = '" + listJury[degreeWorkJuryListBox.SelectedIndex].CorrelativeNumber + "' AND ET.cedulae = E.cedulae", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String id = (String)reader["cedulae"];
                        String name = (String)reader["nombre"];
                        Trace.WriteLine(id);
                        Trace.WriteLine(name);
                        Students students = new Students(id, name);
                        listIDStudents.Add(students);
                    }
                    reader.Close();
                }
                for(int i = 0; i < listIDStudents.Count; i++)
                {
                    page = new EvaluateDegreeWorkWindow(listJury[degreeWorkJuryListBox.SelectedIndex], false, listIDStudents[i]);
                    page.ShowDialog();
                }
                Trace.WriteLine("Se metio en jurado");
            }else if(degreeWorkTutorListBox.SelectedIndex != -1)
            {
                Trace.WriteLine("En lista tutor " + listTutor[degreeWorkTutorListBox.SelectedIndex].CorrelativeNumber.ToString());
                using (var command = new NpgsqlCommand("SELECT * FROM entrega AS ET, estudiantes AS E WHERE ET.ncorrelativo = '" + listTutor[degreeWorkTutorListBox.SelectedIndex].CorrelativeNumber + "' AND ET.cedulae = E.cedulae", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String id = (String)reader["cedulae"];
                        String name = (String)reader["nombre"];
                        Students students = new Students(id, name);
                        listIDStudents.Add(students);
                    }
                    reader.Close();
                }
                Trace.WriteLine("cantidad de items en listId" + listIDStudents.Count.ToString());
                for (int i = 0; i < listIDStudents.Count; i++)
                {
                    page = new EvaluateDegreeWorkWindow(listTutor[degreeWorkTutorListBox.SelectedIndex], true, listIDStudents[i]);
                    page.ShowDialog();
                }
                Trace.WriteLine("Se metio en tutor");
            }
        }

       
        void OnMouseDoubleClickTutor(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;
            AddEvaluationCriteriaDegreeWork page = new AddEvaluationCriteriaDegreeWork(this.listTutor[item],true);
            page.ShowDialog();
        }

        void OnMouseDoubleClickJury(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;
            AddEvaluationCriteriaDegreeWork page = new AddEvaluationCriteriaDegreeWork(this.listJury[item],false);
            page.ShowDialog();
        }
    }
}

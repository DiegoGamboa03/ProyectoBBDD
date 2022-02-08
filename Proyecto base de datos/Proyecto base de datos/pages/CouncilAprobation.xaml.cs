using Npgsql;
using Proyecto_base_de_datos.Class;
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
    /// Interaction logic for CouncilAprobation.xaml
    /// </summary>
    public partial class CouncilAprobation : Window
    {
        DegreeWorks degreeWorks;
        String councilId;
        public CouncilAprobation(DegreeWorks degreeWorks, String councilID)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            this.councilId = councilID;
            titleTextBlock.Text = degreeWorks.Title;
            modalityTextBlock.Text = degreeWorks.Title;
            correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();
            List<Teachers> Teacherlist = new List<Teachers>();
            List<Specialty> specialtyList = new List<Specialty>();

            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"especialidades\"", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String idSpecialty = (String)reader["codesp"];
                    String name = (String)reader["nombreesp"];
                    Specialty specialty = new Specialty(idSpecialty,name);
                    specialtyList.Add(specialty);
                }
                reader.Close();
            }

            using (var command = new NpgsqlCommand("SELECT * FROM \"profesores\" WHERE \"tipo\" = 'I'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String teacherId = (String)reader["cedulap"];
                    String name = (String)reader["nombre"];
                    Teachers teachers = new Teachers(teacherId,name);
                    Teacherlist.Add(teachers);
                }
                reader.Close();
            }
            for(int i = 0; i< Teacherlist.Count; i++)
            {
                String specialtiesTeacher = null;
                using (var comm = new NpgsqlCommand("SELECT * FROM \"tiene\" WHERE \"cedulap\" = '" + Teacherlist[i].Id + "'", conn.conn))
                {
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        String idSpecialty = (String)reader["codesp"];
                        Specialty specialty = specialtyList.Find(x => x.Id.Equals(idSpecialty));
                        specialtiesTeacher += "," + specialty.Name;
                    }
                    reader.Close();
                }
                tutorList.Items.Add(Teacherlist[i].Id + ',' + Teacherlist[i].Name + specialtiesTeacher);

            }
        }

        private void approveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisapproveButton__Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

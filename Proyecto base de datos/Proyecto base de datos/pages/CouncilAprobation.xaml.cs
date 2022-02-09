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
        List<Teachers> Teacherlist;
        public CouncilAprobation(DegreeWorks degreeWorks, String councilID)
        {
            InitializeComponent();
            this.degreeWorks = degreeWorks;
            this.councilId = councilID;
            titleTextBlock.Text = degreeWorks.Title;
            modalityTextBlock.Text = degreeWorks.Title;
            correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();
            Teacherlist = new List<Teachers>();
            List<Specialty> specialtyList = new List<Specialty>();

            var conn = new Connection();
            conn.openConnection();
            //Se recompilan todas las especialidades en una lista interna
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
            //Se sacan todos los profesores disponibles
            using (var command = new NpgsqlCommand("SELECT * FROM \"profesores\" WHERE \"tipo\" = 'I'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String teacherId = (String)reader["cedulap"];
                    String name = (String)reader["nombre"];
                    firstJuryComboBox.Items.Add(teacherId + ',' + name);
                    firstsubstituteComboBox.Items.Add(teacherId + ',' + name);
                    secondJuryComboBox.Items.Add(teacherId + ',' + name);
                    secondSubstituteComboBox.Items.Add(teacherId + ',' + name);
                    Teachers teachers = new Teachers(teacherId,name);
                    Teacherlist.Add(teachers);
                }
                reader.Close();
            }
            //Luego se rellana la lista de tutores con la informacion del profesor y sus especialidades
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
            if (tutorList.SelectedIndex != -1 && firstJuryComboBox.SelectedIndex != -1 && firstsubstituteComboBox.SelectedIndex != -1 && secondJuryComboBox.SelectedIndex != -1 && secondSubstituteComboBox.SelectedIndex != -1)
            {
                var conn = new Connection();
                conn.openConnection();
                //Se inserta tutor y se cambia el estado de espropuesta en la tabla trabajos de grado
                using (var command = new NpgsqlCommand("UPDATE trabajos_de_grado SET nconsejo = @n1, cedulapi = @n2, espropuesta = false WHERE ncorrelativo = @n3", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(councilId));
                    command.Parameters.AddWithValue("n2", Teacherlist[tutorList.SelectedIndex].Id);
                    command.Parameters.AddWithValue("n3",degreeWorks.CorrelativeNumber.ToString());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                //Inserta primer jurado
                using (var command = new NpgsqlCommand("INSERT INTO asignaj(nconsejo, cedulapji, cedulapje) VALUES(@n1, @n2,@n3)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(councilId));
                    command.Parameters.AddWithValue("n2", Teacherlist[tutorList.SelectedIndex].Id);
                    command.Parameters.AddWithValue("n3", Teacherlist[firstJuryComboBox.SelectedIndex].Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                //Inserta primer suplente
                using (var command = new NpgsqlCommand("INSERT INTO asignaj(nconsejo, cedulapji, cedulapje) VALUES(@n1, @n2,@n3)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(councilId));
                    command.Parameters.AddWithValue("n2", Teacherlist[tutorList.SelectedIndex].Id);
                    command.Parameters.AddWithValue("n3", Teacherlist[firstsubstituteComboBox.SelectedIndex].Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                //Inserta segundo jurado
                using (var command = new NpgsqlCommand("INSERT INTO asignaj(nconsejo, cedulapji, cedulapje) VALUES(@n1, @n2,@n3)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(councilId));
                    command.Parameters.AddWithValue("n2", Teacherlist[tutorList.SelectedIndex].Id);
                    command.Parameters.AddWithValue("n3", Teacherlist[secondJuryComboBox.SelectedIndex].Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                //Inserta segundo suplente
                using (var command = new NpgsqlCommand("INSERT INTO asignaj(nconsejo, cedulapji, cedulapje) VALUES(@n1, @n2,@n3)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", Int32.Parse(councilId));
                    command.Parameters.AddWithValue("n2", Teacherlist[tutorList.SelectedIndex].Id);
                    command.Parameters.AddWithValue("n3", Teacherlist[secondSubstituteComboBox.SelectedIndex].Id);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                //Rellenamos una lista con los estudiantes involucrados en esta tg
                List<String> studentIdList = new List<string>();
                using (var command = new NpgsqlCommand("SELECT * FROM \"entrega\" WHERE \"ncorrelativo\" = " + degreeWorks.CorrelativeNumber + "", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String studentId = (String)reader["cedulae"];
                        studentIdList.Add(studentId);
                    }
                    reader.Close();
                }
                for(int i = 0; i < studentIdList.Count; i++)
                {
                    //Buscamos el resto de sus propuestas menos la que se ha aprobado
                    List<String> correlativeNumberList = new List<string>();
                    using (var command = new NpgsqlCommand("SELECT * FROM \"entrega\" WHERE \"cedulae\" = " + studentIdList[i] + " AND ncorrelativo != " + degreeWorks.CorrelativeNumber + "", conn.conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            String correlativeNumber = (String)reader["ncorrelativo"];
                            correlativeNumberList.Add(correlativeNumber);
                        }
                        reader.Close();
                    }
                    for (int j = 0; j< correlativeNumberList.Count; j++)
                    {
                        using (var command = new NpgsqlCommand("UPDATE trabajos_de_grado SET espropuesta = null WHERE ncorrelativo = @n1", conn.conn))
                        {
                            command.Parameters.AddWithValue("n1", correlativeNumberList[j]);
                            int nRows = command.ExecuteNonQuery();  
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }
                    }
                }
                
                this.Close();
            }
        }

        private void DisapproveButton__Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("UPDATE trabajos_de_grado SET espropuesta = null WHERE ncorrelativo = @n2", conn.conn))
            {
                command.Parameters.AddWithValue("n2", degreeWorks.CorrelativeNumber.ToString());
                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
            }
            this.Close();
        }
    }
}

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
    /// Interaction logic for CommiteAprobation.xaml
    /// </summary>
    public partial class CommiteAprobation : Window
    {
        DegreeWorks degreeWorks;
        String commiteId;
        private List<String> TeacherIDlist;
        public CommiteAprobation(DegreeWorks degreeWorks, String commiteId)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            TeacherIDlist = new List<string>();
            this.degreeWorks = degreeWorks;
            this.commiteId = commiteId;
            titleTextBlock.Text = degreeWorks.Title;
            modalityTextBlock.Text = degreeWorks.Modality;
            correlativeNumberTextBlock.Text = degreeWorks.CorrelativeNumber.ToString();

            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"profesores\" WHERE \"tipo\" = 'I'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String teacherId = (String)reader["cedulap"];
                    String name = (String)reader["nombre"];
                    InternalTeacherList.Items.Add(teacherId + ',' + name);
                    TeacherIDlist.Add(teacherId);
                }
                reader.Close();
            }

        }

        private void approveButton_Click(object sender, RoutedEventArgs e)
        {
            if (InternalTeacherList.SelectedIndex != -1)
            {
                var conn = new Connection();
                conn.openConnection();
                //INSERT INTO esrevisor (ncorrelativo, codigoc, cedulapi, fechasig,estatus,fecharev) VALUES (@n1,@n2,@n3,@n4,@n5) query completa  // falta el estatus
                using (var command = new NpgsqlCommand("INSERT INTO esrevisor (ncorrelativo, codigoc, cedulapi, fechasig) VALUES (@n1,@n2,@n3,@n4)", conn.conn))
                {

                    String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    command.Parameters.AddWithValue("n1", degreeWorks.CorrelativeNumber);
                    command.Parameters.AddWithValue("n2", commiteId);
                    command.Parameters.AddWithValue("n3", TeacherIDlist[InternalTeacherList.SelectedIndex]);
                    command.Parameters.AddWithValue("n4", dateTime);
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
                using (var command = new NpgsqlCommand("UPDATE trabajos_de_grado SET codigoc = @n1 WHERE ncorrelativo = @n2", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", commiteId);
                    command.Parameters.AddWithValue("n2", degreeWorks.CorrelativeNumber.ToString());
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
                }
                this.Close();
            }
            else
            {
                //Mensaje aqui 
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
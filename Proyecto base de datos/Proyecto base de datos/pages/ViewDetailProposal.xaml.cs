using System;
using Proyecto_base_de_datos.Class;
using Npgsql;
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
    /// Interaction logic for ViewDetailProposal.xaml
    /// </summary>
    public partial class ViewDetailProposal : Window
    {
        public ViewDetailProposal(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            nrocorr.Text = degreeWorks.CorrelativeNumber.ToString();
            titlepro.Text = degreeWorks.Title;
            date.Text = degreeWorks.CreationDate;
            if (degreeWorks.Modality == "I")
                modality.Text = "Instrumental";
            else
                modality.Text = "Experimental";
            if (degreeWorks.Observations == "")
                observations.Text = "No tiene observaciones";
            else
                observations.Text = degreeWorks.Observations;

            if (degreeWorks.CouncilNumber == "")
                ncouncil.Text = "No tiene consejo asignado";
            else
                ncouncil.Text = degreeWorks.CouncilNumber;

            if (degreeWorks.IdCouncil == "")
                ncomitte.Text = "No tiene comité asignado";
            else
                ncomitte.Text = degreeWorks.IdCouncil;            

            if (degreeWorks.IdInternTeacher == "")
                teacher.Text = "No asignado";
            else
                SearchTeacher(degreeWorks.IdInternTeacher);
            
            student.Visibility = Visibility.Collapsed;
            students.Visibility = Visibility.Collapsed;

            SearchStudents(degreeWorks.CorrelativeNumber);
        }
        private void SearchTeacher(string idTeacher)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"profesores\" WHERE \"cedulap\" = '" + idTeacher  + "'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                   String name = (String)reader["nombre"];
                    teacher.Text = name;
                }
                reader.Close();
            }
        }

        private void SearchStudents(int nro)
        {
            List<String> studentsNames = new List<String>();
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM\"entrega\" \"e\",\"estudiantes\" \"es\" WHERE e.\"ncorrelativo\" = '" + nro.ToString()+"' AND e.cedulae = es.cedulae", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    studentsNames.Add(((String)reader["nombre"]));     
                }
                reader.Close();

                if (studentsNames.Count == 1)
                {
                    student.Visibility = Visibility.Visible;
                    studentName.Text = studentsNames[0];
                } else if (studentsNames.Count == 2)
                {
                    students.Visibility = Visibility.Visible;
                    studentName1.Text = studentsNames[0];
                    studentName2.Text = studentsNames[1];
                }

            }
        }
    }
}

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

namespace Proyecto_base_de_datos.pages
{
    /// <summary>
    /// Interaction logic for ReviewerWindow.xaml
    /// </summary>
    public partial class ReviewerWindow : Window
    {
        private DegreeWorks degreeWorks;
        private List<CriteriaClass> list;
        public ReviewerWindow(DegreeWorks DegreeWork)
        {
            InitializeComponent();
            list = new List<CriteriaClass>();
            this.degreeWorks = DegreeWork;
            TitleTDG.Text = degreeWorks.Title;

            var conn = new Connection();
            conn.openConnection();

            using (var command = new NpgsqlCommand("SELECT \"E\".* FROM \"estudiantes\" AS \"E\", \"entrega\" AS \"ET\" WHERE \"ET\".ncorrelativo = '" + DegreeWork.CorrelativeNumber + "' AND \"ET\".cedulae = \"E\".cedulae", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentName.Text = (String)reader["nombre"];
                    idStudent.Text = (String)reader["cedulae"];
                    StudentEmail.Text = (String)reader["correoucab"];
                }
                reader.Close();
            }
            if(this.degreeWorks.Modality == "E")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM \"criteriosevpr_e\" WHERE \"estatus\" = 'A'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String CriteriaCode = (String)reader["codigo"];
                        String CriteriaDesc = (String)reader["descripcion"];
                        String CriteriaStatus = (String)reader["estatus"];

                        CriteriaClass Criteria = new CriteriaClass(CriteriaCode, CriteriaDesc, CriteriaStatus);
                        list.Add(Criteria);
                        CriteriaList.Items.Add(Criteria.CriteriaCode + " || " + Criteria.CriteriaDesc);

                    }
                    reader.Close();
                }
            }
            else if(this.degreeWorks.Modality == "I")
            {
                using (var command = new NpgsqlCommand("SELECT * FROM \"criteriosevpr_i\" WHERE \"estatus\" = 'A'", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String CriteriaCode = (String)reader["codigo"];
                        String CriteriaDesc = (String)reader["descripcion"];
                        String CriteriaStatus = (String)reader["estatus"];

                        CriteriaClass Criteria = new CriteriaClass(CriteriaCode, CriteriaDesc, CriteriaStatus);
                        list.Add(Criteria);
                        CriteriaList.Items.Add(Criteria.CriteriaCode + " || " + Criteria.CriteriaDesc);

                    }
                    reader.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;

            // This is your selected item
            int item = list.SelectedIndex;

            //Trace.WriteLine("AAAAA");
        }
    }
}

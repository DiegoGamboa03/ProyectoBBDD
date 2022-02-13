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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for EvaluateDegreeWorkxaml.xaml
    /// </summary>
    public partial class EvaluateDegreeWorkxaml : Page
    {
        public EvaluateDegreeWorkxaml()
        {
            InitializeComponent();
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT TG.* FROM asignaj as AJ, trabajos_de_grado as TG WHERE AJ.cedulap = '" + MainWindow.teachers.Id + "' AND TG.ncorrelativo = AJ.ncorrelativo;", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                    String title = (String)reader["titulo"];
                    String modality = (String)reader["modalidad"];
                    DateTime dateTime = (DateTime)reader["fechacreacion"];

                    DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                    degreeWorkListBox.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                }
                reader.Close();
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

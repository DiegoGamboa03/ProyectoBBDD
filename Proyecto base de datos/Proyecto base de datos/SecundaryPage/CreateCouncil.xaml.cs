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
    /// Interaction logic for CreateCouncil.xaml
    /// </summary>
    public partial class CreateCouncil : Page
    {
        public CreateCouncil()
        {
            InitializeComponent();
            var conn = new Connection();
            conn.openConnection();
            List<String> listCorrelativeNumber = new List<string>();
            List<DegreeWorks> listDegreeWorks = new List<DegreeWorks>();

            using (var command = new NpgsqlCommand("SELECT ncorrelativo FROM \"esrevisor\" WHERE \"estatus\" = 'PAR'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                }
                reader.Close();
            }


            for (int i = 0; i < listCorrelativeNumber.Count; i++)
            {
                using (var command = new NpgsqlCommand("SELECT * FROM \"trabajos_de_grado\" WHERE \"ncorrelativo\" =" + listCorrelativeNumber[i] + "", conn.conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                        String title = (String)reader["titulo"];
                        String modality = (String)reader["modalidad"];
                        DateTime dateTime = (DateTime)reader["fechacreacion"];

                        DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                        listDegreeWorks.Add(degreeWorks);
                        proposalListBox.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                    }
                    reader.Close();
                }
            }
        }
    }
}

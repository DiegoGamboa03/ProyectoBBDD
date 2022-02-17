using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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
    /// Interaction logic for committeePage.xaml
    /// </summary>
    public partial class committeePage : Page
    {
        private static List<DegreeWorks> list;
        public committeePage()
        {
            InitializeComponent();
            list = new List<DegreeWorks>();
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM trabajos_de_grado WHERE espropuesta = true AND codigoc IS null", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int correlativeNumber = Int32.Parse((String)reader["ncorrelativo"]);
                    String title = (String)reader["titulo"];
                    String modality = (String)reader["modalidad"];
                    DateTime dateTime = (DateTime)reader["fechacreacion"];

                    DegreeWorks degreeWorks = new DegreeWorks(correlativeNumber, title, dateTime.ToString(), modality);
                    list.Add(degreeWorks);
                    ProposalListView.Items.Add(degreeWorks.CorrelativeNumber.ToString() + ", " + degreeWorks.Title);
                }
                reader.Close();
            }

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            List<DegreeWorks> listAux = new List<DegreeWorks>();
            if (ProposalListView.SelectedItems.Count > 0)
            {
                String lastID;
                var conn = new Connection();
                conn.openConnection();
                using (var command = new NpgsqlCommand("INSERT INTO comites (codigoc, fechap) VALUES (nextval('comiteSequenciaPK'), @n2) RETURNING codigoc", conn.conn))
                {
                    String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    command.Parameters.AddWithValue("n2", dateTime);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    lastID = (String)reader["codigoc"];
                    Trace.WriteLine(lastID.ToString());
                    reader.Close();
                }

                for (int i = 0; i < ProposalListView.SelectedItems.Count; i++)
                {
                    var selectedItem = ProposalListView.Items.IndexOf(ProposalListView.SelectedItems[i]);
                    listAux.Add(list[selectedItem]);
                }
                Trace.WriteLine(listAux.Count);
                int j = 0;
                while (j < listAux.Count) {
                    CommiteAprobation commite = new CommiteAprobation(listAux[j], lastID);
                    commite.ShowDialog();
                    j++;
                }
            }
            
        }
    }
}

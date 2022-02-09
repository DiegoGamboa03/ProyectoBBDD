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
    /// Interaction logic for CreateCouncil.xaml
    /// </summary>
    public partial class CreateCouncil : Page
    {
        private List<DegreeWorks> listDegreeWorks = new List<DegreeWorks>();

        public CreateCouncil()
        {
            InitializeComponent();
            var conn = new Connection();
            conn.openConnection();
            List<String> listCorrelativeNumber = new List<string>();
            listDegreeWorks = new List<DegreeWorks>();
            //Tengo que encontrar una query que no ponga los que ya son trabajo de grado
            using (var command = new NpgsqlCommand("SELECT ncorrelativo FROM \"esrevisor\" WHERE \"estatus\" = 'PAR'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String correlativeNumber = (String)reader["ncorrelativo"];
                    listCorrelativeNumber.Add(correlativeNumber);
                    Trace.WriteLine(correlativeNumber.ToString());
                }
                reader.Close();
            }


            for (int i = 0; i < listCorrelativeNumber.Count; i++)
            {
                using (var command = new NpgsqlCommand("SELECT * FROM \"trabajos_de_grado\" WHERE \"ncorrelativo\" = '" + listCorrelativeNumber[i] + "'", conn.conn))
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String lastID;
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO consejos_de_escuela (nconsejo, fechap) VALUES (nextval('consejosSequenciaPK'), @n2) RETURNING nconsejo", conn.conn))
            {
                String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                DateTime dateTime = DateTime.Parse(dateTimeString);
                command.Parameters.AddWithValue("n2", dateTime);
                var reader = command.ExecuteReader();
                reader.Read();
                int lastIDaux = (int)reader["nconsejo"];
                lastID = lastIDaux.ToString();
                Trace.WriteLine(lastID.ToString());
                reader.Close();
            }

            List<DegreeWorks> listAux = new List<DegreeWorks>();
            for (int i = 0; i < proposalListBox.SelectedItems.Count; i++)
            {
                var selectedItem = proposalListBox.Items.IndexOf(proposalListBox.SelectedItems[i]);
                listAux.Add(listDegreeWorks[selectedItem]);
            }
            Trace.WriteLine(listAux.Count);
            int j = 0;
            while (j < listAux.Count)
            {
                CouncilAprobation council = new CouncilAprobation(listAux[j], lastID);
                council.ShowDialog();
                j++;
            }
        }
    }
 }
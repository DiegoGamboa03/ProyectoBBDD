using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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
    /// Interaction logic for ViewAllProposalsSt.xaml
    /// </summary>
    public partial class ViewAllProposalsSt : Page
    {
        private List<DegreeWorks> proposals = new List<DegreeWorks>();
        public ViewAllProposalsSt()
        {
            InitializeComponent();
            SearchProposals();
        }
        private void SearchProposals() // Search proposals of a Student
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"trabajos_de_grado\" ORDER BY \"ncorrelativo\"", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String ncorrelativo = (String)reader["ncorrelativo"];
                    int ncorre = Int32.Parse(ncorrelativo);
                    String title = (String)reader["titulo"];
                    DateTime creationDate = (DateTime)reader["fechacreacion"];
                    String stCreationDate = creationDate.ToString();
                    String modality = (String)reader["modalidad"];

                    //Pueden ser Null
                    var observations = reader["observaciones"];
                    var councilNumber = reader["nconsejo"];
                    var idInternTeacher = reader["cedulapi"];
                    var idCouncil = reader["codigoc"];
                    proposals.Add(new DegreeWorks(ncorre, title, observations.ToString(), stCreationDate, modality, councilNumber.ToString(), idInternTeacher.ToString(), idCouncil.ToString()));
                }
                reader.Close();
                proposalsList.ItemsSource = proposals;
            }
        }
        private void OnClickItems(object sender, RoutedEventArgs e)
        {
            var selectedItem = proposalsList.Items.IndexOf(proposalsList.SelectedItem);
            ViewDetailProposal detailProposal = new ViewDetailProposal(proposals[selectedItem]);
            detailProposal.ShowDialog();
        }
    }
}

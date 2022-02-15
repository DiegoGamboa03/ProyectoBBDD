using Npgsql;
using System;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewProposals.xaml
    /// </summary>
    public partial class ViewProposals : Page
    {
        private List<DegreeWorks> proposals = new List<DegreeWorks>();
        public ViewProposals()
        {
            InitializeComponent();
            //AddExample();
            SearchProposals();
        }
        private void SearchProposals() // Search proposals of a Student
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"entrega\" \"e\",\"trabajos_de_grado\" \"tg\" WHERE \"cedulae\" = '" + MainWindow.student.Id.ToString() + "' AND e.\"ncorrelativo\" = tg.\"ncorrelativo\" ORDER BY tg.\"ncorrelativo\"", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String ncorrelativo = (String)reader["ncorrelativo"];
                    int ncorre = Int32.Parse(ncorrelativo);
                    String title = (String)reader["titulo"];
                    DateTime creationDate = (DateTime)reader["fechacreacion"];
                    String stCreationDate = creationDate.ToString("dd-MM-yyyy");
                    String modality = (String)reader["modalidad"];

                    //Pueden ser Null
                    var observations = reader["observaciones"];
                    var councilNumber = reader["nconsejo"];
                    var idInternTeacher = reader["cedulapi"];
                    var idCouncil = reader["codigoc"];
                    proposals.Add(new DegreeWorks(ncorre, title, observations.ToString(), stCreationDate, modality, councilNumber.ToString(), idInternTeacher.ToString(), idCouncil.ToString()));
                }
                reader.Close();
                if (proposals.Count > 0)
                    proposalsList.ItemsSource = proposals;
            }
        }
        private void AddExample()  // Add example proposals for test ui
        {
            for (int i = 1; i <= 10; i++)
            {
                proposals.Add(new DegreeWorks(i, "Propuesta de prueba ", "02-07-2022", "Instrumental"));
            }
            proposalsList.ItemsSource = proposals;
        }

        private void OnClickItem(object sender, RoutedEventArgs e)
        {
            if (proposals.Count > 0)
            {
                proposalsList.ItemsSource = proposals; var selectedItem = proposalsList.Items.IndexOf(proposalsList.SelectedItem);
                ViewDetailProposal detailProposal = new ViewDetailProposal(proposals[selectedItem]);
                detailProposal.ShowDialog();
            }
        }

        private void Button_Click_Delete_Proposal(object sender, RoutedEventArgs e)
        {
            var selectedItem = proposalsList.Items.IndexOf(proposalsList.SelectedItem);
            ConfirmDeleteProposal confirmPage = new ConfirmDeleteProposal(proposals[selectedItem]);
            confirmPage.ShowDialog();
            proposals.Clear();
            SearchProposals();
        }
    }
}

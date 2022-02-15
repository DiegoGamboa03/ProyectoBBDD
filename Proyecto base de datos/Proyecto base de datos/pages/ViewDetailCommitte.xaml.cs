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
    /// Interaction logic for ViewDetailCommitte.xaml
    /// </summary>
    public partial class ViewDetailCommitte : Window
    {
        private List<DegreeWorks> proposals = new List<DegreeWorks>();
        public ViewDetailCommitte(Commite comm)
        {
            String codec = comm.CommiteID;
            InitializeComponent();
            SearchProposals(codec);
            ccode.Text = codec;
        }

        private void SearchProposals(string codec)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"trabajos_de_grado\" WHERE \"codigoc\" = '"+ codec + "' ORDER BY \"ncorrelativo\"", conn.conn))
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
                if(proposals.Count>0)
                    proposalsList.ItemsSource = proposals;
            }
        }

        private void OnClickItem(object sender, RoutedEventArgs e)
        {
            if(proposals.Count > 0 && proposalsList!=null)
            {
                var selectedItem = proposalsList.Items.IndexOf(proposalsList.SelectedItem);
                ViewDetailProposal detailProposal = new ViewDetailProposal(proposals[selectedItem]);
                detailProposal.ShowDialog();
            }
        }
    }
}

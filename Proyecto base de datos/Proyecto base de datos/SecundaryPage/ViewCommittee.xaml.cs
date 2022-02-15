using System;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for ViewCommittee.xaml
    /// </summary>
    public partial class ViewCommittee : Page
    {
        private List<Commite> committes = new List<Commite>();
        public ViewCommittee()
        {
            InitializeComponent();
            SearchCommittee();
        }
        private void SearchCommittee()
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"comites\" ORDER BY \"codigoc\"", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String ccommitte = (String)reader["codigoc"];                    
                    DateTime datep = (DateTime)reader["fechap"];
                    committes.Add(new Commite(ccommitte,datep));
                }
                reader.Close();

                if(committes.Count > 0)
                    committeList.ItemsSource = committes;
            }
        }

        private void DetailCommitte(object sender, RoutedEventArgs e)
        {
            if( committeList != null && committeList.SelectedItem != null)
            {
                var selectedItem = committeList.Items.IndexOf(committeList.SelectedItem);
                ViewDetailCommitte detailccommitte = new ViewDetailCommitte(committes[selectedItem]);
                detailccommitte.ShowDialog();
            }            
        }
    }
}

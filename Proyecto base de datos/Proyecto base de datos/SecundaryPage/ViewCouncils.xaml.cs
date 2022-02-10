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
    /// Interaction logic for ViewCouncils.xaml
    /// </summary>
    public partial class ViewCouncils : Page
    {
        private List<Council> councils = new List<Council>();
        public ViewCouncils()
        {
            InitializeComponent();
            SearchCouncils();
        }

        private void SearchCouncils()
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"consejos_de_escuela\" ORDER BY \"nconsejo\"", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ncouncil = (int)reader["nconsejo"];
                    String ncoun = ncouncil.ToString();
                    DateTime datep = (DateTime)reader["fechap"];
                    councils.Add(new Council(ncoun,datep));
                }
                reader.Close();
                councilsList.ItemsSource = councils;
            }
        }
        private void DetailCouncils(object sender, RoutedEventArgs e)
        {
            var selectedItem = councilsList.Items.IndexOf(councilsList.SelectedItem);
             ViewDetailCouncil detailCouncil = new ViewDetailCouncil(councils[selectedItem]);
            detailCouncil.ShowDialog();
        }
    }
}

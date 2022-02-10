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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.SecundaryPage
{
    /// <summary>
    /// Interaction logic for ViewCommittee.xaml
    /// </summary>
    public partial class ViewCommittee : Page
    {
        public ViewCommittee()
        {
            InitializeComponent();
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
                    int codeCommitte = Int32.Parse(ccommitte);
                    DateTime datep = (DateTime)reader["fechap"];
                    String datepp = datep.ToString("dd-MM-yyyy");
                }
                reader.Close();
            }
        }
    }
}

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
    /// Interaction logic for CreateProposal.xaml
    /// </summary>
    public partial class CreateProposal : Page
    {
        public CreateProposal()
        {
            InitializeComponent();
            teammatesComboBox.Items.Add("Sin compañero");

            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"estudiantes\" WHERE \"tienetg\" = false AND \"cedulae\" != '"+ MainWindow.student.Id.ToString() + "'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String StudentId = (String)reader["cedulae"];
                    String name = (String)reader["nombre"];
                    teammatesComboBox.Items.Add(StudentId + "," + name);
                }
                reader.Close();
            }
        }
    }
}

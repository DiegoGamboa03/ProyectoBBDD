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
    /// Interaction logic for CreateSpecialty.xaml
    /// </summary>
    public partial class CreateSpecialty : Page
    {
        public CreateSpecialty()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO especialidades (codesp,nombreesp) VALUES (nextval('especialidadesPKsecuencia'), @n1)", conn.conn))
            {
                command.Parameters.AddWithValue("n1",specialtyNameTextBox.Text.Trim());
                int nRows = command.ExecuteNonQuery();
            }
        }
    }
}

using Npgsql;
using Proyecto_base_de_datos.Class;
using Proyecto_base_de_datos.pages;
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
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.Pages
{
    /// <summary>
    /// Interaction logic for AddSpeciality.xaml
    /// </summary>
    public partial class AddSpeciality : Window
    {
        List<String> listIdSpeciality = new List<string>();
        public AddSpeciality()
        {
            InitializeComponent();
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM especialidades as E, tiene as TI WHERE TI.codesp= E.codesp AND TI.cedulap != '"+ MainWindow.teachers.Id +"'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String specialityID = (String)reader["codesp"];
                    String specialityName = (String)reader["nombreesp"];
                    listIdSpeciality.Add(specialityID);
                    specialityComboBox.Items.Add(specialityID + ", " + specialityName);
                }
                reader.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO tiene (cedulap,codesp) VALUES (@n1, @n2)", conn.conn))
            {
                command.Parameters.AddWithValue("n1",MainWindow.teachers.Id);
                command.Parameters.AddWithValue("n2",listIdSpeciality[specialityComboBox.SelectedIndex]);
                command.ExecuteNonQuery();
            }
            string ConfirmationMessage = "Se ingreso el dato";
            FailedSequenceWindow window = new FailedSequenceWindow(ConfirmationMessage);
            window.ShowDialog();
            this.Close();
        }
    }
}

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
using System.Windows.Shapes;

namespace Proyecto_base_de_datos.pages
{
    /// <summary>
    /// Interaction logic for RegisterStudent.xaml
    /// </summary>
    public partial class RegisterStudent : Window
    {
        public RegisterStudent()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO estudiantes (cedulae, nombre, telefono, correoucab, correoparticular, contrasena, otro) VALUES (@n1, @q1, @n2, @q2, @n3, @q3)", conn.conn))
             {
                 command.Parameters.AddWithValue("n1", "banana");
                 command.Parameters.AddWithValue("q1", "150");
                 command.Parameters.AddWithValue("n2", "orange");
                 command.Parameters.AddWithValue("q2", "154");
                 command.Parameters.AddWithValue("n3", "apple");
                 command.Parameters.AddWithValue("q3", "100");

                 int nRows = command.ExecuteNonQuery();
                 Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
             }
        }
    }
}

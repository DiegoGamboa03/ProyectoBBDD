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
    /// Interaction logic for RegisterTeacher.xaml
    /// </summary>
    public partial class RegisterTeacher : Window
    {
        public static Teachers Teacher;
        public RegisterTeacher()
        {
            InitializeComponent();
            TeacherTypeListComboBox.Items.Add("Interno");
            TeacherTypeListComboBox.Items.Add("Externo");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO profesores (cedulap, nombre, direccion, telefono, institucion, contrasena, tipo) VALUES (@n1, @q1,@n2, @q2,@n3, @q3,@n4)", conn.conn))
            {
                command.Parameters.AddWithValue("n1", idTextBox.Text);
                command.Parameters.AddWithValue("q1", nameTextBox.Text);
                command.Parameters.AddWithValue("n2", directionTextBox.Text);
                command.Parameters.AddWithValue("q2", phoneNumberTextBox.Text);
                command.Parameters.AddWithValue("n3", institutionTextBox.Text);
                command.Parameters.AddWithValue("q3", passwordTextBox.Text);

                Teacher = new Teachers(idTextBox.Text, nameTextBox.Text, directionTextBox.Text, phoneNumberTextBox.Text, institutionTextBox.Text);

                if (TeacherTypeListComboBox.SelectedItem.Equals("Interno"))
                {
                    command.Parameters.AddWithValue("n4", "I");
                }
                else if (TeacherTypeListComboBox.SelectedItem.Equals("Externo"))
                {
                    command.Parameters.AddWithValue("n4", "E");
                }

                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
            }
            if (TeacherTypeListComboBox.SelectedItem.Equals("Interno"))
            {
                using (var command = new NpgsqlCommand("INSERT INTO internos (cedulap) VALUES (@n1)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", idTextBox.Text);
                    command.ExecuteNonQuery();
                }
            }
            else if (TeacherTypeListComboBox.SelectedItem.Equals("Externo"))
            {
                using (var command = new NpgsqlCommand("INSERT INTO externos (cedulap) VALUES (@n1)", conn.conn))
                {
                    command.Parameters.AddWithValue("n1", idTextBox.Text);
                    command.ExecuteNonQuery();
                }
            }

            string ConfirmationMessage = "Se ha registrado exitosamente el profesor.";
            FailedSequenceWindow window = new FailedSequenceWindow(ConfirmationMessage);
            window.ShowDialog();
            this.Close();
        }
    }
}

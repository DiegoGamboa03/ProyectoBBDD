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
        public static Students Student;
        public RegisterStudent()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("INSERT INTO estudiantes (cedulae, nombre, telefono, correoucab, correoparticular, contrasena, otro, tienetg) VALUES (@n1, @q1, @n2, @q2, @n3, @q3, @n4, @n5)", conn.conn))
            {
                command.Parameters.AddWithValue("n1", idTextBox.Text);
                command.Parameters.AddWithValue("q1", nameTextBox.Text);
                command.Parameters.AddWithValue("n2", phoneNumberTextBox.Text);
                command.Parameters.AddWithValue("q2", ucabMailTextBox.Text);
                command.Parameters.AddWithValue("n3", mailTextBox.Text);
                command.Parameters.AddWithValue("q3", passwordTextBox.Text);
                command.Parameters.AddWithValue("n4", bonusAtributteTextBox.Text);
                command.Parameters.AddWithValue("n5", false);
                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                Student = new Students(idTextBox.Text, nameTextBox.Text, mailTextBox.Text, ucabMailTextBox.Text, phoneNumberTextBox.Text, bonusAtributteTextBox.Text, false);
            }

            string ConfirmationMessage = "Se ha registrado exitosamente el alumno.";
            FailedSequenceWindow window = new FailedSequenceWindow(ConfirmationMessage);
            window.ShowDialog();
            this.Close();
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

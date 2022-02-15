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
    /// Interaction logic for ConfirmDeleteProposal.xaml
    /// </summary>
    public partial class ConfirmDeleteProposal : Window
    {
        public ConfirmDeleteProposal(DegreeWorks degreeWorks)
        {
            InitializeComponent();
            proposal.Text = degreeWorks.CorrelativeNumber.ToString();
        }
        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("DELETE FROM \"entrega\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"asignaj\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"experimentales\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"instrumentales\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"esrevisor\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"evaluacriterioe\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"evaluacriterioi\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand("DELETE FROM \"trabajos_de_grado\" WHERE ncorrelativo = @n", conn.conn))
            {
                command.Parameters.AddWithValue("n", proposal.Text);
                int nRows = command.ExecuteNonQuery();                
            }

            this.Close();
        }
    }
}

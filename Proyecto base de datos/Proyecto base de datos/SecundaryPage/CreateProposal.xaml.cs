using Npgsql;
using Proyecto_base_de_datos.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            teammatesComboBox.SelectedIndex = 0;
            auxTextBox.Visibility = Visibility.Collapsed;
            endorsedTeacherText.Visibility = Visibility.Collapsed;
            businessTutorText.Visibility = Visibility.Collapsed;
            companyName.Visibility = Visibility.Collapsed;
            companyNameTextBox.Visibility = Visibility.Collapsed;

            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand("SELECT * FROM \"estudiantes\" WHERE \"tienetg\" = false AND \"cedulae\" != '" + MainWindow.student.Id.ToString() + "'", conn.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String StudentId = (String)reader["cedulae"];
                    String name = (String)reader["nombre"];
                    teammatesComboBox.Items.Add(name + "," + StudentId);
                }
                reader.Close();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            businessTutorText.Visibility = Visibility.Visible;
            companyName.Visibility = Visibility.Visible;
            companyNameTextBox.Visibility = Visibility.Visible;
            auxTextBox.Visibility = Visibility.Visible;
            endorsedTeacherText.Visibility = Visibility.Collapsed;
        }

        private void experimentalRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            auxTextBox.Visibility = Visibility.Visible;
            endorsedTeacherText.Visibility = Visibility.Visible;
            businessTutorText.Visibility = Visibility.Collapsed;
            companyName.Visibility = Visibility.Collapsed;
            companyNameTextBox.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (instrumentalRadioButton.IsChecked == false && experimentalRadioButton.IsChecked == false)
            {
                //Aqui se manda un mensaje de que se tiene que rellenar los botones 
            }
            else
            {
                if(experimentalRadioButton.IsChecked == true && auxTextBox.Text.Length>0)
                {
                    String lastID;
                    var conn = new Connection();
                    conn.openConnection();
                    //
                    using (var command = new NpgsqlCommand("INSERT INTO trabajos_de_grado (ncorrelativo, titulo, modalidad, fechacreacion,espropuesta) VALUES (nextval('secuenciatrabajosgradopk'), @n2,'E',@n4,true) RETURNING ncorrelativo", conn.conn))
                    {
                        String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                        DateTime dateTime = DateTime.Parse(dateTimeString);
                        command.Parameters.AddWithValue("n2", titleTextBox.Text.Trim());
                        command.Parameters.AddWithValue("n4", dateTime);
                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        var reader = command.ExecuteReader();
                        reader.Read();
                        lastID = (String)reader["ncorrelativo"];
                        Trace.WriteLine(lastID.ToString());
                        reader.Close();
                    }

                    using (var comm = new NpgsqlCommand("INSERT INTO experimentales (ncorrelativo,profesorava) VALUES (@n1,@n2)", conn.conn))
                    {
                        comm.Parameters.AddWithValue("n1", lastID);
                        comm.Parameters.AddWithValue("n2", auxTextBox.Text.Trim());
                        int nRows = comm.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }

                    using (var comm = new NpgsqlCommand("INSERT INTO entrega (cedulae,ncorrelativo) VALUES (@n1,@n2)", conn.conn))
                    {
                        comm.Parameters.AddWithValue("n1", MainWindow.student.Id.ToString());
                        comm.Parameters.AddWithValue("n2", lastID);
                        int nRows = comm.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }
                   
                    if (teammatesComboBox.SelectedIndex != 0) 
                    {
                        String idTeammate = teammatesComboBox.SelectedItem.ToString();
                        string output = idTeammate.Substring(idTeammate.IndexOf(',') + 1);
                        //idTeammate.remov
                        Trace.WriteLine(output);
                        
                        using (var comm = new NpgsqlCommand("INSERT INTO entrega (cedulae,ncorrelativo) VALUES (@n1,@n2)", conn.conn))
                        {
                            comm.Parameters.AddWithValue("n1", output.Trim());
                            comm.Parameters.AddWithValue("n2", lastID);
                            int nRows = comm.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }

                    }
                   
                }
                else
                {
                    //Mostrar mensaje que rellene
                }
                if(instrumentalRadioButton.IsChecked == true && auxTextBox.Text.Length > 0 && companyNameTextBox.Text.Length > 0)
                {
                    String lastID;
                    var conn = new Connection();
                    conn.openConnection();
                    //
                    using (var command = new NpgsqlCommand("INSERT INTO trabajos_de_grado (ncorrelativo, titulo, modalidad, fechacreacion,espropuesta) VALUES (nextval('secuenciatrabajosgradopk'), @n2,'I',@n4,true) RETURNING ncorrelativo", conn.conn))
                    {
                        String dateTimeString = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                        DateTime dateTime = DateTime.Parse(dateTimeString);
                        command.Parameters.AddWithValue("n2", titleTextBox.Text.Trim());
                        command.Parameters.AddWithValue("n4", dateTime);
                        var reader = command.ExecuteReader();
                        reader.Read();
                        lastID = (String)reader["ncorrelativo"];
                        Trace.WriteLine(lastID.ToString());
                        reader.Close();
                    }

                    using (var comm = new NpgsqlCommand("INSERT INTO instrumentales (ncorrelativo,nempresa,tutoremp) VALUES (@n1,@n2,@n3)", conn.conn))
                    {
                        comm.Parameters.AddWithValue("n1", lastID);
                        comm.Parameters.AddWithValue("n2", companyNameTextBox.Text.Trim());
                        comm.Parameters.AddWithValue("n3", auxTextBox.Text.Trim());
                        int nRows = comm.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }

                    using (var comm = new NpgsqlCommand("INSERT INTO entrega (cedulae,ncorrelativo) VALUES (@n1,@n2)", conn.conn))
                    {
                        comm.Parameters.AddWithValue("n1", MainWindow.student.Id.ToString());
                        comm.Parameters.AddWithValue("n2", lastID);
                        int nRows = comm.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }

                    if (teammatesComboBox.SelectedIndex != 0)
                    {
                        String idTeammate = teammatesComboBox.SelectedItem.ToString();
                        string output = idTeammate.Substring(idTeammate.IndexOf(',') + 1);
                        //idTeammate.remov
                        Trace.WriteLine(output);

                        using (var comm = new NpgsqlCommand("INSERT INTO entrega (cedulae,ncorrelativo) VALUES (@n1,@n2)", conn.conn))
                        {
                            comm.Parameters.AddWithValue("n1", output.Trim());
                            comm.Parameters.AddWithValue("n2", lastID);
                            int nRows = comm.ExecuteNonQuery();
                            Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                        }

                    }
                }
                else
                {
                    //Mostrar mensaje que rellene
                }

            }
            
        }

    }
}

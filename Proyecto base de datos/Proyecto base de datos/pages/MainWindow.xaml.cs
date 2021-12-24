using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_base_de_datos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string Host = "proyectobasedatosfranklin.postgres.database.azure.com";
        private static string User = "Roberson@proyectobasedatosfranklin";
        private static string DBname = "postgres";
        private static string Password = "Franklin123";
        private static string Port = "5432";
        public NpgsqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
            string connString =
                String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            conn = new NpgsqlConnection(connString);
            conn.Open();

        }

        private void singInButton_Click(object sender, RoutedEventArgs e)
        {

            using (var command = new NpgsqlCommand("INSERT INTO estudiantes (\"nombre\", \"cedula\", \"telefono\", \"correoucab\", \"correoparticular\", \"otro\") VALUES (@a,@b,@c,@d,@e,@f)", conn))
            {
                command.Parameters.AddWithValue("a", "banana");
                command.Parameters.AddWithValue("b", "banana2");
                command.Parameters.AddWithValue("c", "orange");
                command.Parameters.AddWithValue("d", "Orange2");
                command.Parameters.AddWithValue("e", "apple");
                command.Parameters.AddWithValue("f", "apple2");

                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
            }
        }
    }
    }

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
        private bool isStudent = false;

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
            using (var command = new NpgsqlCommand(string.Format("SELECT * FROM estudiantes WHERE cedula = '{0}' ",idTextBox.Text), conn))
            {   
                var reader = command.ExecuteReader();
                if(reader.Read()){
                    var nombre = (string)reader["nombre"]; //esto tiene que ser contraseña (se me olvio crear el campo de contraseña xd)
                    Trace.WriteLine(nombre);
                    isStudent = true; //Aqui va todo el codigo de abrir la pagina como estudiante
                    Trace.WriteLine("Existe");
                }
                else{
                    Trace.WriteLine("No Existe");
                }
                reader.Close();      
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
    

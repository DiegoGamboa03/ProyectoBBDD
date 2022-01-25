using Npgsql;
using Proyecto_base_de_datos.pages;
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
        private bool isTeacher = false;

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
            using (var command = new NpgsqlCommand(string.Format("SELECT * FROM estudiantes WHERE cedulae = '{0}' ",idTextBox.Text), conn))
            {   
                var reader = command.ExecuteReader();
                if(reader.Read()){
                    var contrasena = (string)reader["contrasena"]; //esto tiene que ser contraseña (se me olvio crear el campo de contraseña xd)
                    Trace.WriteLine(contrasena);
                    if (contrasena == passwordTextBox.Text.Trim())
                        isStudent = true; //Aqui va todo el codigo de abrir la pagina como estudiante
                  
                    //Aqui va otra porcion que sea lo mismo pero con la tabla de profesores

                    if (isStudent)
                    {
                        StudentWindow window = new StudentWindow();
                        window.Show();
                        this.Close();
                        Trace.WriteLine("Existe");
                    }
                    if (isTeacher)
                    {
                        //Abre otra pagina
                    }

            }
                else{
                    //Aqui ponemos un pop up que diga que no es un usuario o contraseña valido
                    Trace.WriteLine("No Existe");
                }
                reader.Close();      
            }

            using (var command = new NpgsqlCommand(string.Format("SELECT * FROM profesores WHERE cedulap = '{0}' ", idTextBox.Text), conn))
            {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var contrasena = (string)reader["contrasena"];
                    Trace.WriteLine(contrasena);
                    if (contrasena == passwordTextBox.Text.Trim())
                        isTeacher = true; //Aqui va todo el codigo de abrir la pagina como estudiante

                    if (isTeacher){
                        TeacherWindow window = new TeacherWindow();
                        window.Show();
                        this.Close();
                        Trace.WriteLine("Existe");
                    }

                }
                else
                {
                    //Aqui ponemos un pop up que diga que no es un usuario o contraseña valido
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
    

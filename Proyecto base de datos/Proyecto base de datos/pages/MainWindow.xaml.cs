using Npgsql;
using Proyecto_base_de_datos.pages;
using Proyecto_base_de_datos.Class;
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

        /*private static string Host = "proyectobasedatosfranklin.postgres.database.azure.com";
        private static string User = "Roberson@proyectobasedatosfranklin";
        private static string DBname = "postgres";
        private static string Password = "Franklin123";
        private static string Port = "5432";
        public NpgsqlConnection conn;*/
        private bool isStudent = false;
        private bool isTeacher = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void singInButton_Click(object sender, RoutedEventArgs e)
        {
            var conn = new Connection();
            conn.openConnection();
            using (var command = new NpgsqlCommand(string.Format("SELECT * FROM estudiantes WHERE cedulae = '{0}' ",idTextBox.Text), conn.conn)) { //Se busca en la bbdd la cedula correspondiente   
                var reader = command.ExecuteReader();
                if(reader.Read()){
                    var contrasena = (string)reader["contrasena"];
                    Trace.WriteLine(contrasena);
                    if (contrasena == passwordTextBox.Text.Trim()) //Se verifica si la contraseña sacada de la bd es la misma que la insertada
                        isStudent = true; 

                    if (isStudent)
                    {
                        StudentWindow window = new StudentWindow();
                        window.Show();
                        this.Close();
                        Trace.WriteLine("Existe");
                    }
            }
                else{
                    //Aqui ponemos un pop up que diga que no es un usuario o contraseña valido
                    Trace.WriteLine("No Existe");
                }
                reader.Close();      
            }

            using (var command = new NpgsqlCommand(string.Format("SELECT * FROM profesores WHERE cedulap = '{0}' ", idTextBox.Text), conn.conn)){ //Se busca en la bbdd la cedula correspondiente
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var contrasena = (string)reader["contrasena"];
                    Trace.WriteLine(contrasena);
                    if (contrasena == passwordTextBox.Text.Trim()) //Se verifica si la contraseña sacada de la bd es la misma que la insertada
                        isTeacher = true; 

                    if (isTeacher){
                        TeacherWindow window = new TeacherWindow();
                        window.Show();
                        this.Close();
                        Trace.WriteLine("Existe");
                    }
                }
                else{
                    //Aqui ponemos un pop up que diga que no es un usuario o contraseña valido
                    Trace.WriteLine("No Existe");
                }
                reader.Close();
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterStudent window = new RegisterStudent();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
    

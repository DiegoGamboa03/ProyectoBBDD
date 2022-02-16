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

        private bool isStudent = false;
        private bool isTeacher = false;
        public static Students student;
        public static Teachers teachers;
        public static string ErrorMessage;
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void singInButton_Click(object sender, RoutedEventArgs e)
        {
            if((idTextBox.Text != "") && (passwordTextBox.Text != ""))
            {
                var conn = new Connection();
                conn.openConnection();
                using (var command = new NpgsqlCommand(string.Format("SELECT * FROM estudiantes WHERE cedulae = '{0}' ", idTextBox.Text.Trim()), conn.conn))
                { //Se busca en la bbdd la cedula correspondiente   
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        var passwordaux = (string)reader["contrasena"];
                        Trace.WriteLine(passwordaux);
                        if (passwordaux == passwordTextBox.Text.Trim()) //Se verifica si la contraseña sacada de la bd es la misma que la insertada
                            isStudent = true;

                        if (isStudent)
                        {
                            String StudentId = (String)reader["cedulae"];
                            String name = (String)reader["nombre"];
                            String phoneNumber = (String)reader["telefono"];
                            String ucabMail = (String)reader["correoucab"];
                            String mail = (String)reader["correoparticular"];
                            String password = passwordaux;
                            String bonusAtribute = (String)reader["otro"];
                            bool haveDegreeWork = (bool)reader["tienetg"];
                            student = new Students(StudentId, name, mail, ucabMail, phoneNumber, bonusAtribute, haveDegreeWork);
                            StudentWindow window = new StudentWindow();
                            window.Show();
                            this.Close();
                            Trace.WriteLine(StudentId + " " + name + " " + phoneNumber + " " + ucabMail + " " + mail + " " + password + " " + bonusAtribute + " " + haveDegreeWork.ToString());
                            Trace.WriteLine("Existe");
                        }
                    }
                    else
                    {
                        ErrorMessage = "Usuario o contraseña invalido.";
                        FailedSequenceWindow window = new FailedSequenceWindow(ErrorMessage);
                        window.ShowDialog();
                        Trace.WriteLine("No Existe");
                    }
                    reader.Close();
                }

                using (var command = new NpgsqlCommand(string.Format("SELECT * FROM profesores WHERE cedulap = '{0}' ", idTextBox.Text), conn.conn))
                { //Se busca en la bbdd la cedula correspondiente
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var contrasena = (string)reader["contrasena"];
                        Trace.WriteLine(contrasena);
                        if (contrasena == passwordTextBox.Text.Trim()) //Se verifica si la contraseña sacada de la bd es la misma que la insertada
                            isTeacher = true;

                        if (isTeacher)
                        {
                            String TeacherID = (String)reader["cedulap"];
                            String TeacherName = (String)reader["nombre"];
                            String TeacherAddress = (String)reader["direccion"];
                            String TeacherPhone = (String)reader["telefono"];
                            String TeacherInstitution = (String)reader["institucion"];
                            String teacherType = (String)reader["tipo"];
                            teachers = new Teachers(TeacherID, TeacherName, teacherType, TeacherAddress, TeacherPhone, TeacherInstitution);
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
            } else
            {
                //Se debe poner un pop up de que hay que llenar los campos con lo necesario
            }
            
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterStudent window = new RegisterStudent();
            window.Owner = this;
            window.ShowDialog();
            student = RegisterStudent.Student;
            StudentWindow window2 = new StudentWindow();
            window2.Show();
            this.Close();
        }

        private void RegisterTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterTeacher window = new RegisterTeacher();
            window.Owner = this;
            window.ShowDialog();
            teachers = RegisterTeacher.Teacher;
            TeacherWindow window2 = new TeacherWindow();
            window2.Show();
            this.Close();
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
    

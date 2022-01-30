using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class Connection
    {
        private static string Host = "proyectobasedatosfranklin.postgres.database.azure.com";
        private static string User = "Roberson@proyectobasedatosfranklin";
        private static string DBname = "postgres";
        private static string Password = "Franklin123";
        private static string Port = "5432";
        public NpgsqlConnection conn;

        public void openConnection()
        {
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
        public Students FillStudent(String id)
        {
            String StudentId;
            String name;
            String phoneNumber;
            String ucabMail;
            String mail;
            String password;
            String bonusAtribute;
            bool haveDegreeWork;
            Students students = new Students();

            using (var command = new NpgsqlCommand("SELECT * FROM \"estudiantes\" WHERE \"cedulae\" = '" + id + "'", this.conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentId = reader.GetString(0);
                    name = reader.GetString(1);
                    phoneNumber = reader.GetString(2);
                    ucabMail = reader.GetString(3);
                    mail = reader.GetString(4);
                    password = reader.GetString(5);
                    bonusAtribute = reader.GetString(6);
                    haveDegreeWork = reader.GetBoolean(7);
                    Trace.WriteLine(StudentId + " " + name + " " + phoneNumber + " " + ucabMail + " " + mail + " " + password + " " + bonusAtribute + " " + haveDegreeWork.ToString());
                    students = new Students(StudentId, name, mail, ucabMail, phoneNumber, bonusAtribute, haveDegreeWork);
                }
                reader.Close();
            }
            return students;
            //Students students = new Students(StudentId,name,mail,ucabMail,phoneNumber,bonursAttribute,haveDegreeWork);
        }
    }
}


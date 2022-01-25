using Npgsql;
using System;
using System.Collections.Generic;
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
    }
}

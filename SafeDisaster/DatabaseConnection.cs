using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SafeDisaster
{
    internal class DatabaseConnection
    {
        private static NpgsqlConnection connection;
        private static string connectionString = "Host=localhost;Username=postgres;Password=duta2711;Database=JunPro";
        static DatabaseConnection()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public static NpgsqlConnection GetConnection()
        {
            return connection;
        }

        public static void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static NpgsqlDataReader ExecuteQuery(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}

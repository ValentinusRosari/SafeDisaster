using System;
using Npgsql;

namespace SafeDisaster
{
    internal class DatabaseConnection
    {
        private static NpgsqlConnection connection;
        private static string connectionString = "Host=satao.db.elephantsql.com;Username=tkvnzpuk;Password=G_Zc4JDnbiG3J_ZdUFkk64O5BQv4dQBb;Database=tkvnzpuk";

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

        // You can add a method to execute a query if needed
        public static NpgsqlDataReader ExecuteQuery(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}

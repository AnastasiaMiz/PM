using Npgsql;
using System;

namespace Zayavki_abituriyentov
{
    internal class DB
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app");

        // Открытие соединения с БД
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Закрытие соединения с БД
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Получение соединения
        public NpgsqlConnection GetConnection()
        {
            return connection;
        }
    }
}


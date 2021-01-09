using System;
using System.Data.SQLite;
using System.IO;

namespace ToDoConsoleApp
{
    static class ToDodb
    {
        private const string DBName = "ToDo.sqlite";
        private static readonly string _connectionString = @"Data Source =" + Path.GetFullPath(DBName);

        static private void CreateDB()
        {
            SQLiteConnection.CreateFile(DBName);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE TodoList " +
                    "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "title TEXT(20) NOT NULL, description TEXT(20), completed INTEGER)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
        static public void DisplayList()
        {
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                CreateDB();
            }
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string queryString = "SELECT * FROM TodoList";

            using var command = new SQLiteCommand(queryString, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            Console.WriteLine($"{reader.GetName(0)} {reader.GetName(1),30} {reader.GetName(3),30}");
            while (reader.Read())
            {
                Console.Write($"{reader.GetInt32(0)} {reader.GetString(1),30} ");
                if (reader.GetInt32(3) == 1)
                    Console.WriteLine("\t\t\t[x]");
                else
                    Console.WriteLine("\t\t\t[ ]");
            }
            Console.WriteLine();
        }

        static public void AddItem(TodoItem newItem)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO TodoList(title, description, completed) " +
                "VALUES(@title, @description, @completed)";

            command.Parameters.AddWithValue("@title", newItem.Title);
            command.Parameters.AddWithValue("@description", newItem.Description);
            command.Parameters.AddWithValue("@completed", newItem.Completed);
            command.Prepare();

            command.ExecuteNonQuery();
        }

        static public void DeleteItem(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM TodoList WHERE id=" + id;
            command.ExecuteNonQuery();

        }

        static public void ViewOneItem(string id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string queryString = "SELECT * FROM TodoList WHERE id=" + id;

            using var command = new SQLiteCommand(queryString, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"id: {reader.GetInt32(0)}");
                Console.WriteLine($"Title: {reader.GetString(1)}");
                Console.WriteLine($"Description:  {reader.GetString(2)}");
                if (reader.GetInt32(3) == 1)
                    Console.WriteLine("Completed: [x]");
                else
                    Console.WriteLine("Completed: [ ]");
            }

        }

        static public void ChangeCompleted(string id)
        {
            int completed = 1;
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string queryString = "SELECT completed FROM TodoList WHERE id=" + id;

            using var command = new SQLiteCommand(queryString, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetInt32(0) == 1)
                    completed = 0;
                else
                    completed = 1;
            }
            reader.Close();

            command.CommandText = "UPDATE TodoList SET completed=" + completed + " WHERE id=" + id;
            command.ExecuteNonQuery();
        }

    }
}

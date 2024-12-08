using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=bleach;User ID=root;Password=;";

    static void InsertTourismData(string title, string description, string duration, DateTime createdDate)
    {
        string query = "INSERT INTO Tours (Title, Description, Duration, CreatedDate) " +
                       "VALUES (@Title, @Description, @Duration, @CreatedDate)";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@Duration", duration);
            command.Parameters.AddWithValue("@CreatedDate", createdDate);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted into the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void DisplayTourismData()
    {
        string query = "SELECT Id, Title, Description, Duration, CreatedDate FROM Tours";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Id\tTitle\tDescription\tDuration\tCreatedDate");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}\t{reader["Title"]}\t{reader["Description"]}\t{reader["Duration"]}\t{reader["CreatedDate"]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Inserting Tourism Data...");
        InsertTourismData("Paris City Tour", "A beautiful tour exploring the Eiffel Tower, museums, and more.", "5 days", DateTime.Now);
        InsertTourismData("Tokyo Adventure", "Explore the bustling streets of Tokyo and visit temples.", "7 days", DateTime.Now);

        Console.WriteLine("\nTourism Destinations in the Database:");
        DisplayTourismData();

        Console.ReadKey();
    }
}

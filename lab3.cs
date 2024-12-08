using System;
using MySql.Data.MySqlClient;

class Program
{
    // Corrected connection string for MySQL
    static string connectionString = "Server=localhost;Database=bleach;User ID=root;";

    // Method to insert data into the shinigamis table
    static void InsertData(string name, string address, decimal salary)
    {
        string query = "INSERT INTO shinigamis (name, address, salary) VALUES (@Name, @Address, @Salary)";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Salary", salary);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to select and display data from the shinigamis table
    static void SelectData()
    {
        string query = "SELECT Id, name, address, salary FROM shinigamis";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["name"]}, Address: {reader["address"]}, Salary: {reader["salary"]}");
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
        // Insert data
        Console.WriteLine("Inserting data...");
        InsertData("Hyorimaru", "Karakura Town", 30000.00m);
        InsertData("Byakuya", "Soul Society", 45000.00m);

        // Select data
        Console.WriteLine("\nSelecting data...");
        SelectData();

        Console.ReadKey(); // This line must be inside the Main method
    }
}

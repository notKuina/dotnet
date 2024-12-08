using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=bleach;User ID=root;Password=;";

    static void UpdateData(int id, string newName, string newAddress, decimal newSalary)
    {
        string query = "UPDATE shinigamis SET name = @NewName, address = @NewAddress, salary = @NewSalary WHERE Id = @Id";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@NewName", newName);
            command.Parameters.AddWithValue("@NewAddress", newAddress);
            command.Parameters.AddWithValue("@NewSalary", newSalary);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                else
                    Console.WriteLine("No records found with the specified ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to delete data from the shinigamis table
    static void DeleteData(int id)
    {
        // First, check if the record exists
        string checkQuery = "SELECT COUNT(*) FROM shinigamis WHERE Id = @Id";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                int recordCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (recordCount == 0)
                {
                    Console.WriteLine("No record found with the specified ID.");
                    return;
                }

                string deleteQuery = "DELETE FROM shinigamis WHERE Id = @Id";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Id", id);

                int rowsAffected = deleteCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine($"{rowsAffected} row(s) deleted.");
                else
                    Console.WriteLine("Failed to delete the record.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Updating data...");
        UpdateData(1, "Zangetsu", "Soul Society", 60000.00m);

        Console.WriteLine("\nDeleting data...");
        DeleteData(2);

        Console.ReadKey();
    }
}

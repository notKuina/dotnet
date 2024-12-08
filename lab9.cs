using System;
using MySql.Data.MySqlClient;

class Program
{
	static string connectionString = "Server=localhost;Database=bleach;User ID=root;Password=;";

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

	static void ReadData()
	{
		string query = "SELECT Id, name, address, salary FROM shinigamis";

		using (MySqlConnection connection = new MySqlConnection(connectionString))
		{
			MySqlCommand command = new MySqlCommand(query, connection);

			try
			{
				connection.Open();
				MySqlDataReader reader = command.ExecuteReader();

				Console.WriteLine("Id\tName\tAddress\tSalary");
				while (reader.Read())
				{
					Console.WriteLine($"{reader["Id"]}\t{reader["name"]}\t{reader["address"]}\t{reader["salary"]}");
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}

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
					Console.WriteLine("No record found with the specified ID.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}

	static void DeleteData(int id)
	{
		string query = "DELETE FROM shinigamis WHERE Id = @Id";

		using (MySqlConnection connection = new MySqlConnection(connectionString))
		{
			MySqlCommand command = new MySqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", id);

			try
			{
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0)
					Console.WriteLine($"{rowsAffected} row(s) deleted.");
				else
					Console.WriteLine("No record found with the specified ID.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}

	static void Main()
	{
		Console.WriteLine("Inserting data...");
		InsertData("Ichigo", "Karakura Town", 35000.00m);
		InsertData("Rukia", "Soul Society", 40000.00m);

		Console.WriteLine("\nDisplaying data...");
		ReadData();

		Console.WriteLine("\nUpdating data...");
		UpdateData(1, "Ichigo Kurosaki", "Karakura Town", 45000.00m);

		Console.WriteLine("\nDisplaying updated data...");
		ReadData();

		Console.WriteLine("\nDeleting data...");
		DeleteData(2);

		Console.WriteLine("\nDisplaying remaining data...");
		ReadData();

		Console.ReadKey();
	}
}

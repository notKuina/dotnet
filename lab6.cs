using System;

namespace CustomException
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException() : base("Invalid age entered.") { }

        public InvalidAgeException(string message) : base(message) { }

        public InvalidAgeException(string message, Exception innerException) : base(message, innerException) { }
    }

    class Program
    {
        static void Main(string[] args)

        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your age:");
                    string input = Console.ReadLine();

                    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    }

                    if (!int.TryParse(input, out int age))
                    {
                        throw new InvalidAgeException("Age must be a valid number.");
                    }

                    if (age < 0 || age > 150)
                    {
                        throw new InvalidAgeException($"The age {age} is not valid. Please enter a value between 0 and 150.");
                    }

                    Console.WriteLine($"Your age ({age}) is valid.");
                    break; // Exit loop on valid input
                }
                catch (InvalidAgeException ex)
                {
                    Console.WriteLine($"Custom Exception Caught: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception Caught: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Thank you for using the age validation program.");
                }
            }

            Console.ReadLine();
        }
    }

}


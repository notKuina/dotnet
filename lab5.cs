using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the numerator:");
                int numerator = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the denominator:");
                int denominator = int.Parse(Console.ReadLine());

                int result = numerator / denominator;
                Console.WriteLine($"Result: {numerator} / {denominator} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter valid integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using the exception handling demo.");
            }

            Console.ReadLine();
        }
    }
}

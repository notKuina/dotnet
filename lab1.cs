using System;

namespace MulticastDelegate
{
    public delegate void Notify(string message);

    class Program
    {
        public static void DisplayMessage1(string message)
        {
            Console.WriteLine("Message from DisplayMessage1: " + message);
        }

        public static void DisplayMessage2(string message)
        {
            Console.WriteLine("Message from DisplayMessage2: " + message);
        }

        public static void DisplayMessage3(string message)
        {
            Console.WriteLine("Message from DisplayMessage3: " + message);
        }

        static void Main(string[] args)
        {
            Notify notifyDelegate;

            notifyDelegate = DisplayMessage1;
            notifyDelegate += DisplayMessage2;
            notifyDelegate += DisplayMessage3;

            Console.WriteLine("Invoking multicast delegate:");
            notifyDelegate("This is multicast delegate!");

            notifyDelegate -= DisplayMessage2;

            Console.WriteLine("\nAfter removing DisplayMessage2:");
            notifyDelegate("This is also multicast delegate!");
        }
    }
}

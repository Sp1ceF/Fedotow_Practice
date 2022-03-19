using System;

namespace FEY_Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "pass123";
            string input = "";
            int totalAttempts = 0;
            while (true)
            {
                Console.WriteLine("Enter password:");
                input = Console.ReadLine();
                if (input == password)
                {
                    Console.WriteLine("Secret message");
                    Console.ReadKey();
                    break;
                }
                totalAttempts++;
                if (totalAttempts == 3) break;
                Console.WriteLine("Wrong password, try again");
                Console.WriteLine($"{3-totalAttempts} attempts left");
                Console.WriteLine("=================================");
            }
        }
    }
}

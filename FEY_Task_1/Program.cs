using System;

namespace FEY_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 50;
            int playerBalance;
            int desiredCrystals;
            int crystalCount = 0;
            Console.WriteLine("How many gold do you have?");
            if (!int.TryParse(Console.ReadLine(), out playerBalance))
            {
                Console.WriteLine("Balance input is not correct");
                Console.ReadKey();
                return;
            };
            Console.WriteLine("How many crystals would you like to buy");
            if (!int.TryParse(Console.ReadLine(), out desiredCrystals))
            {
                Console.WriteLine("Crystal count input is not correct");
                Console.ReadKey();
                return;
            };
            while(crystalCount < desiredCrystals && playerBalance - crystalPrice>=0 )
            {
                playerBalance -= crystalPrice;
                crystalCount++;
            }
            Console.WriteLine($"You had bought {crystalCount} crystals");
            Console.WriteLine($"Gold left: {playerBalance}");
            Console.ReadKey();

        }
    }
}

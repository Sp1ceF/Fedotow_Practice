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
            while(!int.TryParse(Console.ReadLine(), out playerBalance) || playerBalance < 0)
            {
                Console.WriteLine("Balance input is not correct, try again");
            }
        
            Console.WriteLine("How many crystals would you like to buy");
            while (!int.TryParse(Console.ReadLine(), out desiredCrystals) || desiredCrystals <0)
            {
                Console.WriteLine("Crystal count input is not correct, try again");
            };
           

            while (crystalCount < desiredCrystals && playerBalance - crystalPrice>=0 )
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

using System;
using System.Collections.Generic;

namespace FEY_Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.WriteLine("Введите кол-во элементов в массиве:");
            if(!int.TryParse(Console.ReadLine(), out int totalElems))
            {
                Console.WriteLine("Вы ввели неправильное значение");
                return;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < totalElems; i++)
            {
                list.Add(rng.Next(0,256));
            }
            Console.WriteLine("Не перемешанный массив:");
            foreach(int b in list)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            Console.WriteLine("Перемешанный массив: ");
            foreach (int b in list)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

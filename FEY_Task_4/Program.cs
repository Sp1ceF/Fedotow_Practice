using System;

namespace FEY_Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool isEnemyFirst = random.Next(0, 100) < 50;
            Controller controller = new Controller(random.Next(500, 999), random.Next(200, 1999), random.Next(30, 70), isEnemyFirst);
            controller.GameLoop();
        }
    }
}

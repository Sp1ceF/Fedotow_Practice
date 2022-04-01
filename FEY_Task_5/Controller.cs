using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    internal class Controller
    {
        private bool _isPlaying = true;
        GameClass _game;
        public Controller()
        {
            _game = new GameClass();
            _game.OnEnd += OnGameEnd;
        }

        private void OnGameEnd(GameResult result)
        {
            Console.SetCursorPosition(0, 0);
            switch (result)
            {
                case GameResult.Win:
                    PrintWinScreen();
                    break;
                case GameResult.Defeat:
                    PrintDefeatScreen();
                    break;
                default:
                    throw new Exception("Game result error");
                   
            }
            _isPlaying = false;
        }

        private void PrintDefeatScreen()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("===============ПРОИГРЫШ===============");
            Console.WriteLine("======================================");
            Console.WriteLine("Ужасные чудовища поглотили твою душу и больше вас никто не видел");
            Console.WriteLine("Нажмите любую кнопку для окончания");
            Console.ReadKey();
          
        }

        private void PrintWinScreen()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("================ПОБЕДА================");
            Console.WriteLine("======================================");
            Console.WriteLine("Вы смогли собрать все кристалы и выжить");
            Console.WriteLine("Нажмите любую кнопку для окончания");
            Console.ReadKey();
        }

        public void GameLoop()
        {
            while (_isPlaying)
            {
                GetInput();
            }
        }

        private void GetInput()
        {
            var ch = Console.ReadKey(false).Key;
            Vector deltaMove= new Vector(0,0);
            switch (ch)
            {
                case ConsoleKey.LeftArrow:
                    deltaMove.X = -1;
                    break;
                case ConsoleKey.RightArrow:
                    deltaMove.X = 1;
                    break;
                case ConsoleKey.UpArrow:
                    deltaMove.Y = -1;
                    break;
                case ConsoleKey.DownArrow:
                    deltaMove.Y = 1;
                    break;
                default:
                    GetInput();
                    break;
            }
            _game.MovePlayer(deltaMove);
        }
    }
}

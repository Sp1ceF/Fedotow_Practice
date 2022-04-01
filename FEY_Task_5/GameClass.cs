using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    public enum GameResult
    {
        Win,
        Defeat
    }
    internal class GameClass
    {
        const int MAX_ENEMY_COUNT = 10;
        const int MAX_PLAYER_HEALTH = 200;
        const int DEFAULT_DAMAGE = 40;
        const string MAP_NAME = "level";

        public event Action<GameResult> OnEnd; 
        public Cell[,] Map { get; set; }
        public Player PlayerClass { get; private set; }
        public List<Enemy> EnemyList { get; private set; }

        public int CoinsCounter;

        private Random rand;
        public GameClass()
        {
            InitializeVariables();
            ReadMap();
            PrintLabyrinth();
            Tick();
            DrawPlayer();
        
        }

        private void InitializeVariables()
        {
            CoinsCounter = 0;
            rand = new Random();
            EnemyList = new List<Enemy>();
        }

        private void ReadMap()
        {
            string[] newFile = File.ReadAllLines($"maps/{MAP_NAME}.txt");
            Cell[,] map = new Cell[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                { 
                    Cell NewCell = new Cell();
                    switch (newFile[i][j])
                    {
                        case ' ':
                            NewCell = new Cell(CellType.EMPTY, newFile[i][j], new Vector(j, i));
                            if (rand.Next(0, 100) < 20)
                            {
                                NewCell.AddObject(new Object(ObjectType.COIN));
                                NewCell.Symbol = '·';
                                CoinsCounter++;
                            }
                            if(EnemyList.Count() < MAX_ENEMY_COUNT)
                            { 
                            if (rand.Next(0, 100) < 5)
                                {
                                    var newEnemy = new Enemy(new Vector(j, i), DEFAULT_DAMAGE);
                                    EnemyList.Add(newEnemy);
                                    NewCell.Contains.Add(newEnemy);
                                }
                            }
                        break;
                        case '·':
                            NewCell = new Cell(CellType.EMPTY, newFile[i][j], new Vector(j, i));
                            NewCell.AddObject(new Object(ObjectType.COIN));
                            NewCell.Symbol = '·';
                            CoinsCounter++;
                            break;
                        case '■':
                            NewCell = new Cell(CellType.EMPTY, newFile[i][j], new Vector(j, i));
                            PlayerClass = new Player(new Vector(j, i), MAX_PLAYER_HEALTH);
                            break;
                        default:
                            NewCell = new Cell(CellType.WALL, newFile[i][j],new Vector(j,i));
                            break;

                    }
                    map[i, j] = NewCell;

                }
            }
            if(PlayerClass==null)
            {
                throw new Exception("There is no player symbol in map text file");
            }
            Map = map;
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(PlayerClass.Position.X, PlayerClass.Position.Y);
            Console.Write(PlayerClass.SYMBOL);
            Console.SetCursorPosition(Map.GetLength(1),0);
        }
        public void PrintLabyrinth()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.Write(Map[i, j].Symbol);
                }
            }
        }
        private void Tick()
        {
            MoveEnemies();
            PrintInterface();
            CheckConditions();
        }

        private void CheckConditions()
        {
            if (CoinsCounter <= 0)
            {
                OnEnd?.Invoke(GameResult.Win);
            }
            else if (PlayerClass.Health <= 0)
            {
                OnEnd?.Invoke(GameResult.Defeat);
            }
        }

       

        private void PrintInterface()
        {
            float oneDivision = MAX_PLAYER_HEALTH / 20;
            int totalDivisions = (int)(PlayerClass.Health / oneDivision);
            Console.SetCursorPosition(Map.GetLength(1) + 5, 0);
            Console.WriteLine("Здоровье");
            Console.SetCursorPosition(Map.GetLength(1)+5, 1);
            Console.Write     ("######################");
            
            char[] healthbar = "#                    #".ToCharArray();
            for(int i = 1; i<= totalDivisions; i++)
            {
                if (i > healthbar.Length) break;
                healthbar[i] = '%';
            }
            Console.SetCursorPosition(Map.GetLength(1) + 5, 2);
            Console.Write(healthbar);
            Console.SetCursorPosition(Map.GetLength(1) + 5, 3);
            Console.Write("######################");
            Console.SetCursorPosition(Map.GetLength(1) + 5, 5);
            Console.Write($"Осталось найти {CoinsCounter} кристаллов");
            Console.SetCursorPosition(Map.GetLength(1) + 5, 7);
            Console.Write("Задание");
            Console.SetCursorPosition(Map.GetLength(1) + 5, 8);
            Console.Write("Вас похитил тёмный колдун Макумба, найдите все кристаллы и выберитесь из его логова,");
            Console.SetCursorPosition(Map.GetLength(1) + 5, 9);
            Console.Write("попутно избегая врагов");
        }

        private void MoveEnemies()
        {
            foreach (Enemy enemy in EnemyList)
            {
                bool canMove = false;
                Vector deltaMove = new Vector(0, 0);
                while (!canMove)
                {
                    if (rand.Next(0, 100) > 50) deltaMove.X = rand.Next(-1, 2);
                    else deltaMove.Y = rand.Next(-1, 2);
                    if(Map[enemy.Position.Y+deltaMove.Y,enemy.Position.X+deltaMove.X].Type!=CellType.WALL) canMove = true;
                }
                Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
                Console.Write(Map[enemy.Position.Y, enemy.Position.X].Symbol);
                Map[enemy.Position.Y, enemy.Position.X].Contains.Remove(enemy);
                enemy.Position.Y += deltaMove.Y;
                enemy.Position.X += deltaMove.X;
                Map[enemy.Position.Y, enemy.Position.X].Contains.Add(enemy);
                Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
                Console.Write(enemy.SYMBOL);
            }
        }

        public void MovePlayer(Vector deltaMove)
        {
            Cell destCell = Map[PlayerClass.Position.Y + deltaMove.Y, PlayerClass.Position.X + deltaMove.X];
            if (destCell.Type == CellType.WALL)
            {
                return;
            }
            foreach(var obj in destCell.Contains)
            {
                if (!obj.IsActive) continue;
                switch (obj.ObjectType)
                {
                    case ObjectType.ENEMY:
                        var enemy = (Enemy)obj;
                        PlayerClass.GetDamage(enemy.Damage);
                        
                        EnemyList.Remove(enemy);
                        
                        break;
                    case ObjectType.COIN:
                        CoinsCounter--;
                        break;
                }
                obj.IsActive = false;
            }
            Console.SetCursorPosition(PlayerClass.Position.X, PlayerClass.Position.Y);
            Console.Write(' ');
            
            PlayerClass.Position.X += deltaMove.X;
            PlayerClass.Position.Y += deltaMove.Y;
            DrawPlayer();
            Tick();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    public delegate void Turn();
    internal class Controller
    {
        static public Controller Instance;
        private bool _isPlayersTurn;
        private bool _isPlaying = true;
        public PlayerClass Player { get; }
        public EnemyClass Enemy { get; }

        public event Turn OnPlayersTurn;
        public Controller(int maxPlayerHealth, int maxEnemyHealth, int enemyDamage, bool isEnemyFirst)
        {
            if (Instance == null) Instance = this;
            else throw new ArgumentException("There is 2 controller instances, but should be one");
            Player = new PlayerClass(maxPlayerHealth);
            Enemy = new EnemyClass(maxEnemyHealth,enemyDamage);
            _isPlayersTurn = !isEnemyFirst;
        }
        public void GameLoop()
        {
            while (_isPlaying)
            {
                PrintInterface();
                if (_isPlayersTurn) { 
                HandleInput();
                }
                ProceedTurn();
            }
            Console.ReadKey();
        }

        private void PrintInterface()
        {
            string enemyOrPlayers = _isPlayersTurn ? "Player's" : "Enemy's";
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine($"Player's remaining health : {Player.HealthComponent.CurrentHealth}");
            Console.WriteLine($"Enemy's remaining health : {Enemy.HealthComponent.CurrentHealth}");
            Console.WriteLine("================================================");
            Console.WriteLine($"Right now is {enemyOrPlayers} turn");
            Console.WriteLine("================================================");
            if (_isPlayersTurn)
            {
                Console.WriteLine("Available spells:");
                Console.WriteLine("1)Fireball\nDeal 50 base damage, simplest damaging skill");
                Console.WriteLine("================================================");
                Console.WriteLine("2)Blood Ritual\nUse your blood for ritual, deal 30% more damage, gain \"Blood offering\" buff");
                Console.WriteLine("================================================");
                Console.WriteLine("3)Exodia\nGain Exodia stack, 6 stacks = instant win, each exodia stack decreases outcoming damage by 10%");
                Console.WriteLine("================================================");
                Console.WriteLine("4)Magical Healing\nHeal for 35% of max hp, deal 34% less damage for 4 turns");
                Console.WriteLine("================================================");
                Console.WriteLine("5)Blood shield\nExchange \"Blood offering\" buff for magical shield that blocks all incoming damage for 1 turn,\nif cast fails - get 10% max hp damage");
                Console.WriteLine("================================================");
                Console.WriteLine("6)Blood orb\nExchange \"Blood offering\" buff for a magical sphere that deals 150 base damage,\nif cast fails - get 10% max hp damage");
                Console.WriteLine("================================================");
                Console.WriteLine("Which spell will you cast: ");
            }
        }

        private void HandleInput()
        {
            string input = Console.ReadLine();
            int.TryParse(input, out int intInp);
       
            switch (intInp)
            {
                case 1:
                    Player.FireBall();
                    break;
                case 2:
                    Player.BloodRitual();
                    break;
                case 3:
                    Player.Exodia();
                    break;
                case 4:
                    Player.MagicalHealing();
                    break;
                case 5:
                    Player.BloodShield();
                    break;
                case 6:
                    Player.BloodOrb();
                    break;
                default:
                    Console.WriteLine("Wrong command, try again");
                    HandleInput();
                    break;
            }
        }

        private void ProceedTurn()
        {
            if (_isPlayersTurn) OnPlayersTurn?.Invoke();
            else
            {
            Player.HealthComponent.GetDamage(Enemy.GetTotalDamage());
            Console.WriteLine($"Player got hit by boss for {Enemy.GetTotalDamage()} damage");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            _isPlayersTurn = !_isPlayersTurn;
            if(Player.HealthComponent.CurrentHealth <= 0 && Enemy.HealthComponent.CurrentHealth <= 0)
            {
                Console.WriteLine("Both died, nobody won");
                _isPlaying = false;
            }
            else if(Player.HealthComponent.CurrentHealth <= 0)
            {
                Console.WriteLine("Enemy won");
                _isPlaying = false;
            }
            else if (Enemy.HealthComponent.CurrentHealth <= 0)
            {
                Console.WriteLine("Player won");
                _isPlaying = false;
            }
            

        }
    }
}

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

        private bool _isPlaying = true;

        private Player _player;

        private Enemy _enemy;

        public event Turn OnTurn;
        public Controller(int maxPlayerHealth, int maxEnemyHealth, int enemyDamage)
        {
            if (Instance == null) Instance = this;
            else throw new ArgumentException("There is 2 controller instances, but should be one");
            _player = new Player(maxPlayerHealth);
            _enemy = new Enemy(maxEnemyHealth,enemyDamage);
            
        }
        public void GameLoop()
        {
            while (_isPlaying)
            {
                PrintInterface();
                HandleInput(); 
                ProceedTurn();
            }
        }

        private void PrintInterface()
        {

        }

        private void HandleInput()
        {

        }

        private void ProceedTurn()
        {
            _player.HealthComponent.GetDamage(_enemy.GetTotalDamage());
            _enemy.HealthComponent.GetDamage(_player.GetTotalDamage());
            OnTurn?.Invoke();
        }
    }
}

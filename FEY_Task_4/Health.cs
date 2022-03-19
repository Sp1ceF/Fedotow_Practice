using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    internal class Health
    {
        public int CurrentHealth { get=>_currentHealth; }

        private int _currentHealth;

        public int MaxHealth { get; }



        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            _currentHealth = MaxHealth;
        }

        public void GetDamage(int damage)
        {
            _currentHealth-=damage;
        }

        public void Heal(int healPoints)
        {
            _currentHealth += healPoints;
            _currentHealth = Math.Clamp(_currentHealth, 0, MaxHealth);
        }
    }
}

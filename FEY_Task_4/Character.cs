using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    internal class Character
    {
        public Health HealthComponent { get;  }

        protected int _baseDamage;

        protected List<Buff> _buffs;

        protected float _damageAmplification;
        protected float _baseDamageAmplification = 1;

        public Character(int maxHealth)
        { 
            HealthComponent = new Health(maxHealth);
            _buffs = new List<Buff>();
        }

        public int GetTotalDamage()
        {
            int resultDamage = 0;
            return resultDamage;
        }
    }
}

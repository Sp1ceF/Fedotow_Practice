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

        public Character(int maxHealth)
        { 
            HealthComponent = new Health(maxHealth);
            _buffs = new List<Buff>();
            Controller.Instance.OnPlayersTurn += OnTurn;
        }

        private void OnTurn()
        {
            _buffs.RemoveAll(x => x.RemainingTurns <= 1);
        }

        public void AddBuff(Buff buff)
        {
            _buffs.Add(buff);
        }

        public int GetTotalDamage()
        {
            float damageAmplification = 1f;
            foreach(Buff buff in _buffs)
            {
                damageAmplification += buff.DamageAmplification;
                damageAmplification = Math.Clamp(damageAmplification, 0f, 100f);
            }
            int resultDamage = (int)(_baseDamage * damageAmplification);
            return resultDamage;
        }
    }
}

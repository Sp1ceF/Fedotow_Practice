using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    internal class Player : Character
    {
        public readonly char SYMBOL = '■';
        public int Health { get; private set; }
        public int CoinsCollected;
        public Player(Vector startPos, int maxHealth): base(startPos, ObjectType.PLAYER)
        {
            CoinsCollected = 0;
            Health = maxHealth;
        }

        public void GetDamage(int damage)
        {
            Health-=damage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    internal class Enemy: Character
    {
       
        public readonly char SYMBOL = '@';
        public int Damage { get; private set; }

        public Enemy(Vector startPos, int damage): base(startPos,ObjectType.ENEMY)
        {
            Damage = damage;
         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    internal class EnemyClass : Character
    {
        public EnemyClass(int maxHealth, int damage): base(maxHealth)
        {
            _baseDamage = damage;
        }
    }
}

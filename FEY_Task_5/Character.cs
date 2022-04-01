using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    internal class Character: Object
    {
        
        public Vector Position { get; set; }

        public Character(Vector spawnPos, ObjectType type) : base(type)
        {
            Position = spawnPos;
        }
    }
}

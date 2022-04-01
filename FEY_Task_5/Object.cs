using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    enum ObjectType
    {
        PLAYER,
        ENEMY,
        COIN
    }
    internal class Object
    {
        public bool IsActive;
        public ObjectType ObjectType { get; private set; }
        public Object(ObjectType type)
        {
            IsActive = true;
            ObjectType = type;
        }
    }
}

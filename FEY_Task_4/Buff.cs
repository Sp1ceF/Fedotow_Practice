using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    internal class Buff
    {
        public string Name { get; }
        public float DamageAmplification { get;}
        public byte RemainingTurns { get; private set; }
        public Buff(string name, float damageAmp, byte totalTurns)
        {
                Name = name;
            DamageAmplification = damageAmp;
            RemainingTurns = totalTurns;
            Controller.Instance.OnTurn += Turn;
        }

        public void Turn()
        { 
            RemainingTurns--;
        }
    }
}

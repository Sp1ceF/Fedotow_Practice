using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_4
{
    internal class PlayerClass: Character
    {
        

        public PlayerClass(int maxHealth) : base(maxHealth)
        {
           
        }

        public void FireBall()
        {
            _baseDamage = 50;
            Console.WriteLine($"Casted fireball, dealt {GetTotalDamage()} damage");
            Controller.Instance.Enemy.HealthComponent.GetDamage(GetTotalDamage());
        }
        //Get 10% of current health damage, but deal 30% more damage;
        public void BloodRitual()
        {
            int incomingDamage = HealthComponent.CurrentHealth / 100 * 10;
            Console.WriteLine($"Used blood ritual spell, got {incomingDamage} damage but will deal 30% more damage for 3 turns");
            HealthComponent.GetDamage(incomingDamage);
            AddBuff(new Buff("Blood offering", 0.3f, 3));
        }
        //Decrease damage by 15%, but if you could get 6 stacks, deal a lot of damage 
        public void Exodia()
        {
            int totalExodias = _buffs.Where(s => s.Name == "Exodia").Count();
            if (totalExodias < 5) {
                Console.WriteLine($"Applied {totalExodias+1} Exodia stacks in total, dealing {(totalExodias+1)*0.1f*100}% less damage");
                AddBuff(new Buff("Exodia", -0.1f, 99));
            }
            else
            {
                Console.WriteLine($"Applied {totalExodias + 1} Exodia stacks, annihilating the enemy");
                _buffs.RemoveAll(s => s.Name == "Exodia");
                _baseDamage = 9999999;
            }
        }
        //Decrease outcoming damage by 34% for 4 turns, but heal for 35%
        public void MagicalHealing()
        {
            int incomingHealing = HealthComponent.MaxHealth / 100 * 35;
            Console.WriteLine($"Healed for {incomingHealing} HP, will deal for 34% less damage");
            HealthComponent.Heal(incomingHealing);
            AddBuff(new Buff("Healed syndrome", -0.34f, 4));

        }
        //Remove blood offering buff, but gain shield that blocks all incoming damage for 1 turn, if cast failed - get 10% of max health damage
        public void BloodShield()
        {
            int totalOfferings = _buffs.Where(s => s.Name == "Blood offering").Count();
            if(totalOfferings >= 1)
            {
                Console.WriteLine("Used shield");
                Controller.Instance.Enemy.AddBuff(new Buff("Magical Shield", -2f, 1));
                _buffs.Remove(_buffs.FirstOrDefault(s => s.Name == "Blood offering"));
            }
            else
            {
                Console.WriteLine($"Failed to apply shield, got {HealthComponent.MaxHealth/10} damage");
                HealthComponent.GetDamage(HealthComponent.MaxHealth / 10);
            }
        }
        public void BloodOrb()
        {
            int totalOfferings = _buffs.Where(s => s.Name == "Blood offering").Count();
            if (totalOfferings >= 1)
            {
                _baseDamage = 150;
                Console.WriteLine($"Casted blood orb, dealt {GetTotalDamage()} damage");
                Controller.Instance.Enemy.HealthComponent.GetDamage(GetTotalDamage());
                _buffs.Remove(_buffs.FirstOrDefault(s => s.Name == "Blood offering"));
            }
            else
            {
                Console.WriteLine($"Failed to cast blood orb, got {HealthComponent.MaxHealth / 10} damage");
                HealthComponent.GetDamage(HealthComponent.MaxHealth / 10);
            }
        }
    }
}

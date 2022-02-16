using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //FIELDS
        public Weapon EquippedWeapon { get; set; }

        //PROPERTIES


        //CONSTRUCTORS 

        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
        }

        //METHODS
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon:\n{4}\n" +
                "Block: {5}\n",
                Name, Life, MaxLife, CalcHitChance(), EquippedWeapon, Block);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;

        }

        public override int CalcHitChance()
        {

            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
        
    }
}

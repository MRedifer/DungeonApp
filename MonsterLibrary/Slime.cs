using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Slime : Monster
    {
        //FIELDS

        //PROPERTIES

        //CONSTRUCTORS
        public Slime(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            MaxLife = 10;
            MaxDamage = 2;
            Name = "Slime";
            Life = 10;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "What appears to be an animated gelatinous blob moving around the floor, gray in color, and seemingly without form.";
        }



        //METHODS
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            return calculatedBlock;
        }
    }
}

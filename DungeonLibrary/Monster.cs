using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDamage;
        private int _maxDamage;

        //PROPERTIES
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        //CONSTRUCTORS
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }
        public Monster() { }

        //METHODS

        public override string ToString()
        {
            return string.Format("(O)===)><><><><><><><><><><><><><>MONSTER<><><><><><><><><><><><><><)==(O)\n" +
                "{0}\nLife: {1} of {2}\n" +
                "Damage: {3} to {4}\n" +
                "Block: {5}\n" +
                "Description\n{6}\n", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }
        public override int CalcDamage()
        {
            Random randDamage = new Random();

            return randDamage.Next(MinDamage, MaxDamage + 1);


        }
    }
}

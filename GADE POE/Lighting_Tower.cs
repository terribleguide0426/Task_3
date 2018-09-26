using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class Lighting_Tower : Building
    {
        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }









        public int Xpos
        {
            get { return X_position; }
            set { X_position = value; }
        }
        public int Ypos
        {
            get { return Y_position; }
            set { Y_position = value; }
        }
        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        public int Fact
        {
            get { return Faction; }
            set { Faction = value; }
        }
        public string Pic
        {
            get { return Image; }
            set { Image = value; }
        }

        public Lighting_Tower(int X_position, int Y_position, int Health, int Faction, string image, int ore, int attack)
        {
            //constructor to obtain values and entries for this class
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = image;
            Power = ore;
            Attack = attack;
           
           
        }
        public override bool isDestoryed()
        {
            if (Health < 1)
            {
                return true;
            }
            else

                return false;
        }
        public override string ToString()
        {
            return "Lighting Building:  " + Xpos + " ," + Ypos + " ," + Health + " ," + Power ; 
        }
        public void Combat(Unit u, Building j)
        {
            int i = ((ResourceBuilding)j).Rate;
            Power = Power + i;
            
            if (Power == 50)
            {
                if (u.GetType() == typeof(MeleeUnits))
                {
                    Health -= ((MeleeUnits)u).attack;
                }
                else if (u.GetType() == typeof(RangedUnits))
                {
                    Health -= ((RangedUnits)u).attack;
                }
            }
            


        }
        public override void Save()
        {

        }
    }
}

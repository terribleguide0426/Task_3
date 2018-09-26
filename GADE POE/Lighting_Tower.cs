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
    //variables
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
            
            Attack = attack;
           
           
        }
       
        public override string ToString()
        {
            return "Lighting Building:  " + Xpos + " ," + Ypos + " ," + Health ; 
        }
        public void Combat(Unit u, Building j)
        {
            //this is is where combat is done when ore reaches certian amount
            int i = ((ResourceBuilding)j).Storage;
            
            
            if (i >= 50)
            {
                if (u.GetType() == typeof(MeleeUnits))
                {
                    ((MeleeUnits)u).health -= attack;
                }
                else if (u.GetType() == typeof(RangedUnits))
                {
                    ((RangedUnits)u).health -= attack;
                }
                
            }
            


        }
      
    }
}

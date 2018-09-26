using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GADE_POE
{
    [Serializable]
    class ResourceBuilding : Building
    {
        private int ore;

        public int Ore
        {
            get { return ore; }
            set { ore = value; }
        }
        private int rate;

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private int remaining;

        public int Remaining
        {
            get { return remaining; }
            set { remaining = value; }
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

        public ResourceBuilding(int X_position, int Y_position, int Health, int Faction, string image, int ore, int rate)
        {
            //constructor to obtain values and entries for this class
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = image;
            Ore = ore;
            Remaining = ore;
            Rate = rate;
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
            return "Resource Building:  " + Xpos + "," + Ypos + "," + Health + ",";
        }
        public void GenResources()
        {
          
            Remaining = Remaining - Rate;
            
        }
        public override void Save()
        {

        }
    }
}

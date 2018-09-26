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
        //variables 
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
        private int storage;

        public int Storage
        {
            get { return storage; }
            set { storage = value; }
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

        public ResourceBuilding(int X_position, int Y_position, int Health, int Faction, string image, int ore, int rate,int store)
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
            storage = store;
        }
       
        public override string ToString()
        {
            return "Resource Building:  " + Xpos + "," + Ypos + "," + Health + " ," + Ore;
        }
        public void GenResources()
        {
          //harvesting of ore to be used by lighting tower
            Remaining = Remaining - Rate;
            storage = storage + Rate;
            if(storage > 50)
            {
                storage = 0;
            }

        }
      
    }
}

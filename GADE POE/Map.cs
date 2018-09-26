using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace GADE_POE
{
    [Serializable]
    public class Map
        //calling the building class
    {
        private Building[] buildings;

        public Building[] Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        private Unit[] units;
        //random number for random x and y postitions and other uses
        Random r = new Random();
        //calling the unit class
        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }
  

        public Map(int maxX, int maxY, int numUnits,int numBuildings)
        {
            buildings = new Building[numBuildings];
            units = new Unit[numUnits];
     
            for(int i = 0; i < numUnits; i++)
            {
                //populating the map with units and assigning variables

                if (i <= 9)
                {
                    MeleeUnits M = new MeleeUnits("Tank",r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, i % 2, "DirtGround.jpg");
                    Units[i] = M;
                }
                    
                
                if (i > 9 && i < 18 )
                {
                    RangedUnits R = new RangedUnits("soldier",r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, i % 2, "DirtGround.jpg");
                    Units[i] = R;
                }

                if ( i >= 18 && i <= 19)
                {
                    HeroUnit R = new HeroUnit("Leader", r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 40), 1, 1, i % 2, "DirtGround.jpg");
                    Units[i] = R;
                }
                if (i > 19)
                {
                    Neutral_Enemies R = new Neutral_Enemies("Raider", r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 40), 1, 1, 3, "DirtGround.jpg");
                    Units[i] = R;
                }
            }
         
            for (int i = 0; i < numBuildings; i++)
            {

                //populating the map with building and assigning variables
                if (i <= 5)
                {
                    ResourceBuilding B1 = new ResourceBuilding(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "building.png",100,2,0);
                    Buildings[i] = B1;
                }


                if (i > 5 && i <= 10)
                {
                   FactoryBuilding B2 = new FactoryBuilding(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "building.png", i % 2, 1, Direction.East);
                    Buildings[i] = B2;
                }
                if (i > 10)
                {
                    Lighting_Tower B3 = new Lighting_Tower(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "building.png", 0, 5);
                    Buildings[i] = B3;
                }
            }
         
        }

    }
}


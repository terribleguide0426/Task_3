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
    {
        private Building[] buildings;

        public Building[] Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        private Unit[] units;
    
        Random r = new Random();
         
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
            
               
                if(i <= 9)
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


                if (i <= 5)
                {
                    ResourceBuilding B1 = new ResourceBuilding(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "building.png",100,2);
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
//        bool Comabt = false;

//        MeleeUnits melee = new MeleeUnits();
//        RangedUnits Range = new RangedUnits();
//        int[,][] MeleeArray = new int[20, 20][];
//        int[,][] RangedArray = new int[20, 20][];
//        TextBox txtBox = new TextBox();
//        //PictureBox[] pictureBoxArrayUnits = new PictureBox[20];
//        int counter = 0;
//        Random rnd = new Random();

//        PictureBox[,] pictureBoxArray = new PictureBox[20, 20];
//        //public Map(Form active)
//        //{
//        //    CreatingMap(active);
//        //    SpawnUnits(active);
//        //    //Move(active);
//        //}

//        public void CreatingMap(Form active)
//        {

//            int horizotal = 30;
//            int vertical = 30;


//            for (int i = 0; i < 20; i++)
//            {
//                for (int m = 0; m < 20; m++)
//                {
//                    pictureBoxArray[i, m] = new PictureBox();
//                    pictureBoxArray[i, m].Size = new Size(30, 30);
//                    pictureBoxArray[i, m].Location = new Point(horizotal, vertical);
//                    pictureBoxArray[i, m].SizeMode = PictureBoxSizeMode.Zoom;
//                    pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                    pictureBoxArray[i, m].Click += new EventHandler(Picture_Click);

//                    vertical = vertical + 30;
//                    active.Controls.Add(pictureBoxArray[i, m]);
//                    active.Click += new EventHandler(Picture_Click);
//                }
//                vertical = 30;
//                horizotal = horizotal + 30;

//            }

//            txtBox.Text = "";
//            txtBox.Size = new Size(100, 100);
//            txtBox.Location = new Point(650, 250);
//            txtBox.Multiline = true;
//            active.Controls.Add(txtBox);
//        }


//        public void SpawnUnits(Form active)
//        {

//            for (int i = 0; i < 20; i++)
//            {
//                for (int m = 0; m < 20; m++)
//                {
//                    MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                }
//            }
//            for (int i = 0; i < 20; i++)
//            {
//                for (int m = 0; m < 20; m++)
//                {
//                    RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                }
//            }

//            melee.health = 20;
//            melee.attack = 5;
//            melee.speed = 1;
//            melee.attackRange = 1;

//            Range.health = 10;
//            Range.attack = 7;
//            Range.speed = 2;
//            Range.attackRange = 1;

//            while (counter < 2)
//            {
//                int SpawnLocationY = rnd.Next(1, 20);
//                int SpawnLocationX = rnd.Next(1, 20);
//                if (pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation == "DirtGround.jpg")
//                {
//                    pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation = "Tank.png";
//                    active.Controls.Add(pictureBoxArray[SpawnLocationX, SpawnLocationY]);
//                    melee.Xpos = SpawnLocationX;
//                    melee.Ypos = SpawnLocationY;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][0] = melee.Xpos;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][1] = melee.Ypos;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][2] = melee.health;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][3] = melee.attack;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][4] = melee.speed;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][5] = melee.attackRange;

//                    counter = counter + 1;



//                }


//            }
//            while (counter >= 2 && counter < 4)
//            {
//                int SpawnLocationY = rnd.Next(1, 20);
//                int SpawnLocationX = rnd.Next(1, 20);
//                if (pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation == "DirtGround.jpg")
//                {
//                    pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation = "Ranged.png";
//                    active.Controls.Add(pictureBoxArray[SpawnLocationX, SpawnLocationY]);
//                    Range.Xpos = SpawnLocationX;
//                    Range.Ypos = SpawnLocationY;
//                    RangedArray[SpawnLocationX, SpawnLocationY][0] = Range.Xpos;
//                    RangedArray[SpawnLocationX, SpawnLocationY][1] = Range.Ypos;
//                    RangedArray[SpawnLocationX, SpawnLocationY][2] = Range.health;
//                    RangedArray[SpawnLocationX, SpawnLocationY][3] = Range.attack;
//                    RangedArray[SpawnLocationX, SpawnLocationY][4] = Range.speed;
//                    RangedArray[SpawnLocationX, SpawnLocationY][5] = Range.attackRange;

//                    counter = counter + 1;



//                }


//            }
//            while (counter >= 4 && counter < 6)
//            {

//                int SpawnLocationY = rnd.Next(1, 19);
//                int SpawnLocationX = rnd.Next(1, 20);
//                if (pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation == "DirtGround.jpg")
//                {
//                    pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation = "Tank1.png";
//                    active.Controls.Add(pictureBoxArray[SpawnLocationX, SpawnLocationY]);
//                    MeleeArray[SpawnLocationX, SpawnLocationY][0] = melee.Xpos;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][1] = melee.Ypos;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][2] = melee.health;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][3] = melee.attack;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][4] = melee.speed;
//                    MeleeArray[SpawnLocationX, SpawnLocationY][5] = melee.attackRange;

//                    counter = counter + 1;
//                }

//            }
//            while (counter >= 6 && counter < 8)
//            {
//                int SpawnLocationY = rnd.Next(1, 20);
//                int SpawnLocationX = rnd.Next(1, 20);
//                if (pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation == "DirtGround.jpg")
//                {
//                    pictureBoxArray[SpawnLocationX, SpawnLocationY].ImageLocation = "Ranged1.png";
//                    active.Controls.Add(pictureBoxArray[SpawnLocationX, SpawnLocationY]);
//                    Range.Xpos = SpawnLocationX;
//                    Range.Ypos = SpawnLocationY;
//                    RangedArray[SpawnLocationX, SpawnLocationY][0] = Range.Xpos;
//                    RangedArray[SpawnLocationX, SpawnLocationY][1] = Range.Ypos;
//                    RangedArray[SpawnLocationX, SpawnLocationY][2] = Range.health;
//                    RangedArray[SpawnLocationX, SpawnLocationY][3] = Range.attack;
//                    RangedArray[SpawnLocationX, SpawnLocationY][4] = Range.speed;
//                    RangedArray[SpawnLocationX, SpawnLocationY][5] = Range.attackRange;

//                    counter = counter + 1;



//                }


//            }
//        }
//        public void Move(Form Yo)
//        {
//            int DistX = 0;
//            int DistY = 0;
//            int Distance;
//            int DistanceClosest = 20;
//            for (int i = 0; i < 20; i++)
//            {
//                for (int m = 0; m < 20; m++)
//                {
//                    if (pictureBoxArray[i, m].ImageLocation == "Tank.png")
//                    {
//                        if (i < 19 && m < 19 && m > 0 && i > 0)
//                        {
//                            if (pictureBoxArray[i + 1, m].ImageLocation == "Tank1.png" || pictureBoxArray[i, m + 1].ImageLocation == "Tank1.png" || pictureBoxArray[i - 1, m].ImageLocation == "Tank1.png" || pictureBoxArray[i, m - 1].ImageLocation == "Tank1.png" || pictureBoxArray[i + 1, m].ImageLocation == "Ranged1.png" || pictureBoxArray[i, m + 1].ImageLocation == "Ranged1.png" || pictureBoxArray[i - 1, m].ImageLocation == "Ranged1.png" || pictureBoxArray[i, m - 1].ImageLocation == "Ranged1.png")

//                            {
//                                for (int k = 0; k < 20; k++)
//                                {
//                                    for (int l = 0; l < 20; l++)
//                                    {
//                                        if (pictureBoxArray[k, l].ImageLocation == "Tank1.png" || pictureBoxArray[k, l].ImageLocation == "Ranged1.png")
//                                        {

//                                            DistX = Math.Abs(k - i);
//                                            DistY = Math.Abs(l - m);
//                                            Distance = DistX + DistY;
//                                            if (Distance < DistanceClosest)
//                                            {
//                                                DistanceClosest = Distance;
//                                                DistX = k;
//                                                DistY = l;

//                                            }

//                                        }
//                                        if (pictureBoxArray[DistX, DistY].ImageLocation == "Tank1.png")
//                                        {
//                                            MeleeArray[DistX, DistY][2] = MeleeArray[DistX, DistY][2] - 5;
//                                            if (MeleeArray[DistX, DistY][2] == 0)
//                                            {
//                                                pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                            }
//                                        }
//                                        if (pictureBoxArray[DistX, DistY].ImageLocation == "Ranged1.png")
//                                        {
//                                            RangedArray[DistX, DistY][2] = RangedArray[DistX, DistY][2] - 5;
//                                            if (RangedArray[DistX, DistY][2] == 0)
//                                            {
//                                                pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                            }
//                                        }
//                                    }
//                                }

//                            }
//                            else if (Comabt == false)
//                            {
//                                for (int k = 0; k < 20; k++)
//                                {
//                                    for (int l = 0; l < 20; l++)
//                                    {
//                                        if (pictureBoxArray[k, l].ImageLocation == "Tank1.png" || pictureBoxArray[k, l].ImageLocation == "Ranged1.png")
//                                        {

//                                            DistX = Math.Abs(k - i);
//                                            DistY = Math.Abs(l - m);
//                                            Distance = DistX + DistY;
//                                            if (Distance < DistanceClosest)
//                                            {
//                                                DistanceClosest = Distance;
//                                                DistX = k;
//                                                DistY = l;
//                                            }
//                                        }
//                                    }
//                                }
//                                if (DistX < i)
//                                {
//                                    if (pictureBoxArray[i - 1, m].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i - 1, m].ImageLocation = "Tank.png";
//                                        MeleeArray[i - 1, m] = MeleeArray[i, m];

//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                    }

//                                }

//                                else if (DistX > i)
//                                {
//                                    if (pictureBoxArray[i + 1, m].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i + 1, m].ImageLocation = "Tank.png";
//                                        MeleeArray[i + 1, m] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                        i = i + 1;
//                                    }


//                                }
//                                else if (DistY < m)
//                                {
//                                    if (pictureBoxArray[i, m - 1].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i, m - 1].ImageLocation = "Tank.png";
//                                        MeleeArray[i, m - 1] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                    }

//                                }

//                                else if (DistY > m)
//                                {
//                                    if (pictureBoxArray[i, m + 1].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i, m + 1].ImageLocation = "Tank.png";
//                                        MeleeArray[i, m + 1] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                        m = m + 1;
//                                    }

//                                }

//                            }
//                        }



//                    }
//                    if (pictureBoxArray[i, m].ImageLocation == "Tank1.png")
//                    {
//                        if (i < 19 && m < 19 && m > 0 && i > 0)
//                        {
//                            if (pictureBoxArray[i + 1, m].ImageLocation == "Tank.png" || pictureBoxArray[i, m + 1].ImageLocation == "Tank.png" || pictureBoxArray[i - 1, m].ImageLocation == "Tank.png" || pictureBoxArray[i, m - 1].ImageLocation == "Tank.png" || pictureBoxArray[i + 1, m].ImageLocation == "Ranged.png" || pictureBoxArray[i, m + 1].ImageLocation == "Ranged.png" || pictureBoxArray[i - 1, m].ImageLocation == "Ranged.png" || pictureBoxArray[i, m - 1].ImageLocation == "Ranged.png")
//                            {
//                                for (int k = 0; k < 20; k++)
//                                {
//                                    for (int l = 0; l < 20; l++)
//                                    {
//                                        if (pictureBoxArray[k, l].ImageLocation == "Tank.png" || pictureBoxArray[k, l].ImageLocation == "Ranged.png")
//                                        {

//                                            DistX = Math.Abs(k - i);
//                                            DistY = Math.Abs(l - m);
//                                            Distance = DistX + DistY;
//                                            if (Distance < DistanceClosest)
//                                            {
//                                                DistanceClosest = Distance;
//                                                DistX = k;
//                                                DistY = l;

//                                            }

//                                        }
//                                        if (pictureBoxArray[DistX, DistY].ImageLocation == "Tank.png")
//                                        {
//                                            MeleeArray[DistX, DistY][2] = MeleeArray[DistX, DistY][2] - 5;
//                                            if (MeleeArray[DistX, DistY][2] == 0)
//                                            {
//                                                pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                            }
//                                        }
//                                        if (pictureBoxArray[DistX, DistY].ImageLocation == "Ranged.png")
//                                        {
//                                            RangedArray[DistX, DistY][2] = RangedArray[DistX, DistY][2] - 5;
//                                            if (RangedArray[DistX, DistY][2] == 0)
//                                            {
//                                                pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                            }
//                                        }
//                                    }
//                                }

//                            }
//                            if (Comabt == false)
//                            {
//                                for (int k = 0; k < 20; k++)
//                                {
//                                    for (int l = 0; l < 20; l++)
//                                    {
//                                        if (pictureBoxArray[k, l].ImageLocation == "Tank.png" || pictureBoxArray[k, l].ImageLocation == "Ranged.png")
//                                        {

//                                            DistX = Math.Abs(k - i);
//                                            DistY = Math.Abs(l - m);
//                                            Distance = DistX + DistY;
//                                            if (Distance < DistanceClosest)
//                                            {
//                                                DistanceClosest = Distance;
//                                                DistX = k;
//                                                DistY = l;
//                                            }
//                                        }
//                                    }
//                                }
//                                if (DistX < i)
//                                {
//                                    if (pictureBoxArray[i - 1, m].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i - 1, m].ImageLocation = "Tank1.png";
//                                        MeleeArray[i - 1, m] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                    }

//                                }

//                                else if (DistX > i)
//                                {
//                                    if (pictureBoxArray[i + 1, m].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i + 1, m].ImageLocation = "Tank1.png";
//                                        MeleeArray[i + 1, m] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                        i = i + 1;
//                                    }

//                                }
//                                else if (DistY < m)
//                                {
//                                    if (pictureBoxArray[i, m - 1].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i, m - 1].ImageLocation = "Tank1.png";
//                                        MeleeArray[i, m - 1] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                    }

//                                }

//                                else if (DistY > m)
//                                {
//                                    if (pictureBoxArray[i, m + 1].ImageLocation == "DirtGround.jpg")
//                                    {
//                                        pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                        pictureBoxArray[i, m + 1].ImageLocation = "Tank1.png";
//                                        MeleeArray[i, m + 1] = MeleeArray[i, m];
//                                        MeleeArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                        m = m + 1;
//                                    }

//                                }
//                            }
//                        }
//                        if (pictureBoxArray[i, m].ImageLocation == "Ranged1.png")
//                        {
//                            if (i < 19 && m < 19 && m > 0 && i > 0)
//                            {
//                                if (pictureBoxArray[i + 1, m].ImageLocation == "Tank.png" || pictureBoxArray[i, m + 1].ImageLocation == "Tank.png" || pictureBoxArray[i - 1, m].ImageLocation == "Tank.png" || pictureBoxArray[i, m - 1].ImageLocation == "Tank.png" || pictureBoxArray[i + 1, m].ImageLocation == "Ranged.png" || pictureBoxArray[i, m + 1].ImageLocation == "Ranged.png" || pictureBoxArray[i - 1, m].ImageLocation == "Ranged.png" || pictureBoxArray[i, m - 1].ImageLocation == "Ranged.png")
//                                {
//                                    for (int k = 0; k < 20; k++)
//                                    {
//                                        for (int l = 0; l < 20; l++)
//                                        {
//                                            if (pictureBoxArray[k, l].ImageLocation == "Tank.png" || pictureBoxArray[k, l].ImageLocation == "Ranged.png")
//                                            {

//                                                DistX = Math.Abs(k - i);
//                                                DistY = Math.Abs(l - m);
//                                                Distance = DistX + DistY;
//                                                if (Distance < DistanceClosest)
//                                                {
//                                                    DistanceClosest = Distance;
//                                                    DistX = k;
//                                                    DistY = l;

//                                                }

//                                            }
//                                            if (pictureBoxArray[DistX, DistY].ImageLocation == "Tank.png")
//                                            {
//                                                MeleeArray[DistX, DistY][2] = MeleeArray[DistX, DistY][2] - 5;
//                                                if (MeleeArray[DistX, DistY][2] == 0)
//                                                {
//                                                    pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                                }
//                                            }
//                                            if (pictureBoxArray[DistX, DistY].ImageLocation == "Ranged.png")
//                                            {
//                                                RangedArray[DistX, DistY][2] = RangedArray[DistX, DistY][2] - 5;
//                                                if (RangedArray[DistX, DistY][2] == 0)
//                                                {
//                                                    pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                                }
//                                            }
//                                        }
//                                    }

//                                }
//                                if (Comabt == false)
//                                {
//                                    for (int k = 0; k < 20; k++)
//                                    {
//                                        for (int l = 0; l < 20; l++)
//                                        {
//                                            if (pictureBoxArray[k, l].ImageLocation == "Tank1.png" || pictureBoxArray[k, l].ImageLocation == "Ranged1.png")
//                                            {

//                                                DistX = Math.Abs(k - i);
//                                                DistY = Math.Abs(l - m);
//                                                Distance = DistX + DistY;
//                                                if (Distance < DistanceClosest)
//                                                {
//                                                    DistanceClosest = Distance;
//                                                    DistX = k;
//                                                    DistY = l;
//                                                }
//                                            }
//                                        }
//                                    }
//                                    if (DistX < i)
//                                    {
//                                        if (pictureBoxArray[i - 1, m].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i - 1, m].ImageLocation = "Ranged1.png";

//                                            RangedArray[i + 1, m] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                        }

//                                    }

//                                    else if (DistX > i)
//                                    {
//                                        if (pictureBoxArray[i + 1, m].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i + 1, m].ImageLocation = "Ranged1.png";
//                                            RangedArray[i + 1, m] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                            i = i + 1;
//                                        }

//                                    }
//                                    else if (DistY < m)
//                                    {
//                                        if (pictureBoxArray[i, m - 1].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i, m - 1].ImageLocation = "Ranged1.png";
//                                            RangedArray[i, m - 1] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                        }

//                                    }

//                                    else if (DistY > m)
//                                    {
//                                        if (pictureBoxArray[i, m + 1].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i, m + 1].ImageLocation = "Ranged1.png";
//                                            RangedArray[i, m + 1] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                            m = m + 1;
//                                        }

//                                    }
//                                }
//                            }
//                        }
//                        if (pictureBoxArray[i, m].ImageLocation == "Ranged.png")
//                        {
//                            if (i < 19 && m < 19 && m > 0 && i > 0)
//                            {
//                                if (pictureBoxArray[i + 1, m].ImageLocation == "Tank1.png" || pictureBoxArray[i, m + 1].ImageLocation == "Tank1.png" || pictureBoxArray[i - 1, m].ImageLocation == "Tank1.png" || pictureBoxArray[i, m - 1].ImageLocation == "Tank1.png" || pictureBoxArray[i + 1, m].ImageLocation == "Ranged1.png" || pictureBoxArray[i, m + 1].ImageLocation == "Ranged1.png" || pictureBoxArray[i - 1, m].ImageLocation == "Ranged1.png" || pictureBoxArray[i, m - 1].ImageLocation == "Ranged1.png")
//                                {
//                                    for (int k = 0; k < 20; k++)
//                                    {
//                                        for (int l = 0; l < 20; l++)
//                                        {
//                                            if (pictureBoxArray[k, l].ImageLocation == "Tank1.png" || pictureBoxArray[k, l].ImageLocation == "Ranged1.png")
//                                            {

//                                                DistX = Math.Abs(k - i);
//                                                DistY = Math.Abs(l - m);
//                                                Distance = DistX + DistY;
//                                                if (Distance < DistanceClosest)
//                                                {
//                                                    DistanceClosest = Distance;
//                                                    DistX = k;
//                                                    DistY = l;

//                                                }

//                                            }
//                                            if (pictureBoxArray[DistX, DistY].ImageLocation == "Tank1.png")
//                                            {
//                                                MeleeArray[DistX, DistY][2] = MeleeArray[DistX, DistY][2] - 5;
//                                                if (MeleeArray[DistX, DistY][2] == 0)
//                                                {
//                                                    pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                                }
//                                            }
//                                            if (pictureBoxArray[DistX, DistY].ImageLocation == "Ranged1.png")
//                                            {
//                                                RangedArray[DistX, DistY][2] = RangedArray[DistX, DistY][2] - 5;
//                                                if (RangedArray[DistX, DistY][2] == 0)
//                                                {
//                                                    pictureBoxArray[DistX, DistY].ImageLocation = "DirtGround.jpg";
//                                                }
//                                            }
//                                        }
//                                    }

//                                }
//                                if (Comabt == false)
//                                {
//                                    for (int k = 0; k < 20; k++)
//                                    {
//                                        for (int l = 0; l < 20; l++)
//                                        {
//                                            if (pictureBoxArray[k, l].ImageLocation == "Tank.png" || pictureBoxArray[k, l].ImageLocation == "Ranged.png")
//                                            {

//                                                DistX = Math.Abs(k - i);
//                                                DistY = Math.Abs(l - m);
//                                                Distance = DistX + DistY;
//                                                if (Distance < DistanceClosest)
//                                                {
//                                                    DistanceClosest = Distance;
//                                                    DistX = k;
//                                                    DistY = l;
//                                                }
//                                            }
//                                        }
//                                    }
//                                    if (DistX < i)
//                                    {
//                                        if (pictureBoxArray[i - 1, m].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i - 1, m].ImageLocation = "Ranged.png";
//                                            RangedArray[i - 1, m] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                        }

//                                    }

//                                    else if (DistX > i)
//                                    {
//                                        if (pictureBoxArray[i + 1, m].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i + 1, m].ImageLocation = "Ranged.png";
//                                            RangedArray[i + 1, m] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                            i = i + 1;
//                                        }

//                                    }
//                                    else if (DistY < m)
//                                    {
//                                        if (pictureBoxArray[i, m - 1].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i, m - 1].ImageLocation = "Ranged.png";
//                                            RangedArray[i, m - 1] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };
//                                        }

//                                    }

//                                    else if (DistY > m)
//                                    {
//                                        if (pictureBoxArray[i, m + 1].ImageLocation == "DirtGround.jpg")
//                                        {
//                                            pictureBoxArray[i, m].ImageLocation = "DirtGround.jpg";
//                                            pictureBoxArray[i, m + 1].ImageLocation = "Ranged.png";
//                                            RangedArray[i, m + 1] = RangedArray[i, m];
//                                            RangedArray[i, m] = new int[] { 0, 0, 0, 0, 0, 0 };

//                                            m = m + 1;
//                                        }

//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//                public void Picture_Click(object sender, EventArgs args)
//                {
//                    int picX = 0;
//                    int picY = 0;
//                    for (int x = 0; x < 20; x++)// locate pic in array
//                    {
//                        for (int y = 0; y < 20; y++)
//                        {
//                            if (((PictureBox)sender) == pictureBoxArray[x, y])
//                            {
//                                picX = x;
//                                picY = y;
//                                if (((PictureBox)sender).ImageLocation == "Tank1.png")
//                                {
//                                    txtBox.Text = "X = " + x.ToString() + "\r\n" + "Y = " + y.ToString() + "\r\n" + "Health: " + MeleeArray[x, y][2] + "\r\n" + "Attack: " + MeleeArray[x, y][3] + "\r\n" + "Speed: " + MeleeArray[x, y][4] + "\r\n" + "AttackRange: " + MeleeArray[x, y][5];
//                                }
//                                if (((PictureBox)sender).ImageLocation == "Tank.png")
//                                {
//                                    txtBox.Text = "X = " + x.ToString() + "\r\n" + "Y = " + y.ToString() + "\r\n" + "Health: " + MeleeArray[x, y][2] + "\r\n" + "Attack: " + MeleeArray[x, y][3] + "\r\n" + "Speed: " + MeleeArray[x, y][4] + "\r\n" + "AttackRange: " + MeleeArray[x, y][5];
//                                }
//                                if (((PictureBox)sender).ImageLocation == "Ranged.png")
//                                {
//                                    txtBox.Text = "X = " + x.ToString() + "\r\n" + "Y = " + y.ToString() + "\r\n" + "Health: " + RangedArray[x, y][2] + "\r\n" + "Attack: " + RangedArray[x, y][3] + "\r\n" + "Speed: " + RangedArray[x, y][4] + "\r\n" + "AttackRange: " + RangedArray[x, y][5];
//                                }
//                                if (((PictureBox)sender).ImageLocation == "Ranged1.png")
//                                {
//                                    txtBox.Text = "X = " + x.ToString() + "\r\n" + "Y = " + y.ToString() + "\r\n" + "Health: " + RangedArray[x, y][2] + "\r\n" + "Attack: " + RangedArray[x, y][3] + "\r\n" + "Speed: " + RangedArray[x, y][4] + "\r\n" + "AttackRange: " + RangedArray[x, y][5];
//                                }
//                            }
//                        }
//                    }
//                }
//    }
//}




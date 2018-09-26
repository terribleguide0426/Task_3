using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace GADE_POE
{
    [Serializable]
    public partial class Form1 : Form
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
      
        int Turn = 0;
        Random r = new Random();

        Map map = new Map(20, 20, 25, 15);//this is where map info is stored
        ResourceBuilding br;
        const int spacing = 20;
        const int Size = 20;
        PictureBox[,] pictureBoxArray = new PictureBox[20, 20];
        public Form1()
        {
            InitializeComponent();
        }
       
     
        private void Form1_Load(object sender, EventArgs e)
            {
           


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            UpdateMap();
            DisplayMap();
            textBox1.Text = (++Turn).ToString();
        }

        

        public void Button_Click(object sender, EventArgs args)
        {
          
        }
        public void Button2_Click(object sender, EventArgs args)
        {
    
        }
       
        private void DisplayMap()
        {
            //this is where the pictureboxes are made and placed and map is displayed 
            //this includes spawning of all units and buildings
            groupBox1.Controls.Clear();
       
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(MeleeUnits))
                    {

                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        MeleeUnits m = (MeleeUnits)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "Tank.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "Tank1.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }
                  

            }
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(RangedUnits))
                    {
                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        RangedUnits m = (RangedUnits)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "Ranged.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "Ranged1.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }
                   

            }
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(HeroUnit))
                    {
                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        HeroUnit m = (HeroUnit)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "hero.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "hero.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }


            }
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(Neutral_Enemies))
                    {
                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        Neutral_Enemies m = (Neutral_Enemies)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "raiders.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "raiders.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }


            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    ResourceBuilding B1 = (ResourceBuilding)b;
                    PictureBox Pbox = new PictureBox();

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (B1.Xpos * Size), start_Y + (B1.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "DirtGround.jpg";

                    if (B1.Fact == 1)
                    {

                        Pbox.ImageLocation = "building.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "building1.png";
                    }
                 
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(Lighting_Tower))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    Lighting_Tower B1 = (Lighting_Tower)b;
                    PictureBox Pbox = new PictureBox();

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (B1.Xpos * Size), start_Y + (B1.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "DirtGround.jpg";

                    if (B1.Fact == 1)
                    {

                        Pbox.ImageLocation = "tower.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "tower.png";
                    }
                   
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {


                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    FactoryBuilding B1 = (FactoryBuilding)b;
                    PictureBox Pbox = new PictureBox();

               

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (B1.Xpos * Size), start_Y + (B1.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "DirtGround.jpg";

                    if (B1.Fact == 1)
                    {

                        Pbox.ImageLocation = "building.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "building1.png";
                    }
                  
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
        }
        private void UpdateMap()
        {
            //movement is applied here for all units
            //combat is also run in the update method
            //generation and transfering methods of ore is run here
            foreach (Unit u in map.Units)
            {
                if( u != null)
                {
                    if (u.GetType() == typeof(MeleeUnits))
                    {
                        MeleeUnits m = (MeleeUnits)u;

                        if (m.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((MeleeUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((MeleeUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((MeleeUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((MeleeUnits)u).NewMovePos(Direction.West); break;

                            }
                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                m.NewMovePos(m.Directionto(c));
                            }

                        }

                    }
                }
                if (u.GetType() == typeof(RangedUnits))
                {
                    RangedUnits m = (RangedUnits)u;

                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((RangedUnits)u).NewMovePos(Direction.Nort); break;
                            case 1: ((RangedUnits)u).NewMovePos(Direction.East); break;
                            case 2: ((RangedUnits)u).NewMovePos(Direction.South); break;
                            case 3: ((RangedUnits)u).NewMovePos(Direction.West); break;

                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (u.AttackRange(e))
                            {
                                u.Combat(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewMovePos(m.Directionto(c));
                        }

                    }

                }
                if (u.GetType() == typeof(HeroUnit))
                {
                    HeroUnit m = (HeroUnit)u;

                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((HeroUnit)u).NewMovePos(Direction.Nort); break;
                            case 1: ((HeroUnit)u).NewMovePos(Direction.East); break;
                            case 2: ((HeroUnit)u).NewMovePos(Direction.South); break;
                            case 3: ((HeroUnit)u).NewMovePos(Direction.West); break;

                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (u.AttackRange(e))
                            {
                                u.Combat(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewMovePos(m.Directionto(c));
                        }

                    }

                }
            }
           
          
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {
                   
                   
                    ((ResourceBuilding)b).GenResources();
                 
                        }
                if (b.GetType() == typeof(Lighting_Tower))
                {
                    foreach (Building b2 in map.Buildings)
                    {
                        if (b2.GetType() == typeof(ResourceBuilding) && ((ResourceBuilding)b2).Fact == ((Lighting_Tower)b).Fact)
                        {
                            
                            foreach (Unit e in map.Units)
                            {
                                
                                ((Lighting_Tower)b).Combat(e, b2);
                            }

                        }
                    }
                   

                }
            }
        }
        public void Picture_Click(object sender, EventArgs args)
        {
         //this is where the map info is displayed in the textbox
            int x = (((PictureBox)sender).Location.X - groupBox1.Location.X) / Size;
            int Y = (((PictureBox)sender).Location.Y - groupBox1.Location.Y) / Size;
          

            foreach (Unit u in map.Units)
            {
               
                if (u != null)
                {
                    if (u.GetType() == typeof(RangedUnits) && x == ((RangedUnits)u).Xpos && Y == ((RangedUnits)u).Ypos)
                    {
                       
                        textBox2.Text = ((RangedUnits)u).ToString();
                    }
                }
            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding) && x == ((FactoryBuilding)b).Xpos && Y == ((FactoryBuilding)b).Ypos)
                {
                    textBox2.Text =  ((FactoryBuilding)b).ToString();
                }

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(Lighting_Tower) && x == ((Lighting_Tower)b).Xpos && Y == ((Lighting_Tower)b).Ypos)
                {
                    textBox2.Text =  ((Lighting_Tower)b).ToString();
                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnits) && x == ((MeleeUnits)u).Xpos && Y == ((MeleeUnits)u).Ypos)
                {
                    textBox2.Text = ((MeleeUnits)u).ToString();
                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(HeroUnit) && x == ((HeroUnit)u).Xpos && Y == ((HeroUnit)u).Ypos)
                {
                    textBox2.Text = ((HeroUnit)u).ToString();
                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Neutral_Enemies) && x == ((Neutral_Enemies)u).Xpos && Y == ((Neutral_Enemies)u).Ypos)
                {
                    textBox2.Text = ((Neutral_Enemies)u).ToString();
                }

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding) && x == ((ResourceBuilding)b).Xpos && Y == ((ResourceBuilding)b).Ypos)
                {
                    textBox2.Text = ((ResourceBuilding)b).ToString();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            //save button
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("Map.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, map);
                    MessageBox.Show("map Info Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //load button
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("Map.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    map = (Map)bf.Deserialize(fsin);
                   
                    MessageBox.Show("map Info Loaded");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
            DisplayMap();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

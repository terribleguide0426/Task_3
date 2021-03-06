﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class HeroUnit : Unit
    {
        public string name
        {
            get { return Name; }
            set { Name = value; }
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
        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }
        public int attackRange
        {
            get { return Attack_range; }
            set { Attack_range = value; }
        }
        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
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

        public HeroUnit(string nam, int X_position, int Y_position, int Health, int Attack, int Speed, int Attack_range, int Faction, string image)
        {
            //constructor to obtain values and entries for this class
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            attack = Attack;
            speed = Speed;
            attackRange = Attack_range;
            Fact = Faction;
            Pic = image;
            name = nam;
        }


        public override void NewMovePos(Direction direction)
        {
            switch (direction)
            {
                case Direction.Nort:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos += Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
            }


        }
        public override void Combat(Unit u)
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
        public override bool AttackRange(Unit u)
        {
            if (u != null)
            {
                if (u.GetType() == typeof(HeroUnit))
                {
                    HeroUnit M = (HeroUnit)u;
                    if (DistanceTo(u) <= attackRange)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        public override Unit UnitDistance(Unit[] units)
        {
            Unit closest = this;
            int closestDist = 50;
            foreach (Unit u in units)
            {
                if (((MeleeUnits)u).Fact != Fact)
                {
                    if (DistanceTo((MeleeUnits)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo((MeleeUnits)u);
                    }
                }
                 if (u.GetType() == typeof(MeleeUnits))
                {
                    if (DistanceTo((MeleeUnits)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                 if (u.GetType() == typeof(RangedUnits))
                {
                    if (DistanceTo((RangedUnits)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                if (u.GetType() == typeof(HeroUnit))
                {
                    if (DistanceTo((HeroUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
            }

            return closest;

        }
        public override bool isDead()
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
            return "Hero UNIT:  " + name + " ," + Xpos + " ," + Ypos + " ," + Health + " ,";
        }
        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(HeroUnit))
            {
                HeroUnit m = (HeroUnit)u;
                int d = Math.Abs(Xpos - m.Xpos) + Math.Abs(Ypos - m.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        public Direction Directionto(Unit u)
        {
            if (u.GetType() == typeof(HeroUnit))
            {
                HeroUnit m = (HeroUnit)u;
                if (m.Xpos < Xpos)
                {
                    return Direction.Nort;
                }
                else if (m.Xpos > Xpos)
                {
                    return Direction.South;
                }
                else if (m.Ypos < Ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else
            {
                return Direction.Nort;
            }

        }
       
    }
}

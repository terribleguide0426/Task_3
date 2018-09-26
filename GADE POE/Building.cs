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
    public abstract class Building
    {
        //Base variables and methods
        protected int X_position;
        protected int Y_position;
        protected int Health;
        protected int Speed;
        protected int Faction;
        protected string Image;

        public Building() { }
      
        abstract public bool isDestoryed();
        abstract public string ToString();
        abstract public void Save();
    }
}

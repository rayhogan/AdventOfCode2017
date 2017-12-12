using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    public class Hexagon
    {
        /*
        * 
        *  Day 11 Hexagon Class
        * 
        * */
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        
        public Hexagon(int xCoord, int yCoord, int zCoord)
        {
            this.X = xCoord;
            this.Y = yCoord;
            this.Z = zCoord;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class Wires
    {
        public int Length { get; private set; }
        public Point CoordinateStart { get; set; }
        public int Direction { get; set; }

        public Wires(Point coordinateStart, int direction, int length) 
        {
            CoordinateStart = coordinateStart;
            Direction = direction;
            Length = length;
        }
    }
}

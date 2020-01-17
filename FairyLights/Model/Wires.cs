using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class Wires
    {
        public int Length { get; private set; }
        public PointF CoordinateStart { get; set; }
        public int Direction { get; set; }

        public Wires(PointF coordinateStart, int direction, int length) 
        {
            CoordinateStart = coordinateStart;
            Direction = direction;
            Length = length;
        }
    }
}

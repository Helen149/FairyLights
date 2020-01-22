using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class Lights
    {
        public Point Coordinate { get; set; }
        public int Radius { get; private set; }
        public bool StateOn { get; set; }

        public Lights(Point coordinate, bool stateOn, int radius)
        {
            Coordinate = coordinate;
            StateOn = stateOn;
            Radius = radius;
        }
    }
}

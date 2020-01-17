using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class Lights
    {
        public PointF Coordinate { get; set; }
        public int Radius { get; private set; }
        public bool StateOn { get; set; }

        public Lights(PointF coordinate, bool stateOn, int radius)
        {
            Coordinate = coordinate;
            StateOn = stateOn;
            Radius = radius;
        }
    }
}

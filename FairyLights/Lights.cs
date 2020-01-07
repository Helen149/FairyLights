using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class Lights
    {
        Tuple<int, int> coordinate;
        static int radius;
        bool stateOn;

        public Lights(Tuple<int, int> coordinate, bool stateOn)
        {
            this.coordinate = coordinate;
            this.stateOn = stateOn;
        }
        public Tuple<int, int> GetCoordinate()
        {
            return coordinate;
        }

        public bool GetState()
        {
            return stateOn;
        }

        public void SetState(bool stateOn)
        {
            this.stateOn = stateOn;
        }
        public static int GetRadius()
        {
            return radius;
        }
        public static void SetRadius(int wight, int height)
        {
            radius = Math.Min(wight, height) / 6;
        }
    }
}

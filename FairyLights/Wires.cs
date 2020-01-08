using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class Wires
    {
        static int length;
        Tuple<int, int> coordinateStart;
        Tuple<int, int> coordinateEnd;

        public Wires(Tuple<int, int> coordinateStart, int direction) 
        {
            this.coordinateStart = coordinateStart;
            FindEnd(direction);
        }

        public void FindEnd(int direction)
        {
            switch(direction)
            {
                case (0):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1+length/2, coordinateStart.Item2+length);
                    break;
                case (1):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1 - length / 2, coordinateStart.Item2 + length);
                    break;
                case (2):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1 + length, coordinateStart.Item2);
                    break;
                case (3):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1 - length/2, coordinateStart.Item2-length);
                    break;
                case (4):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1 + length/2, coordinateStart.Item2-length);
                    break;
                case (5):
                    coordinateEnd = Tuple.Create(coordinateStart.Item1 - length, coordinateStart.Item2);
                    break;
            }
        }

        public int GetXStart()
        {
            return coordinateStart.Item1;
        }

        public int GetYStart()
        {
            return coordinateStart.Item2;
        }

        public int GetXEnd()
        {
            return coordinateEnd.Item1;
        }

        public int GetYEnd()
        {
            return coordinateEnd.Item2;
        }
        public static void SetLenght(int wight, int height)
        {
            length = Math.Min(wight, height) / 6;
        }
    }
}

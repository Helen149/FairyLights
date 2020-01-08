using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class GameModel
    {
        public static Lights[] lights;
        public static Wires[][] wires;
        public static void CreateLights(int count)
        {
            lights = new Lights[count];
            for (int i = 0; i < count; i++)
            {
                lights[i] = new Lights(Tuple.Create(i*100+150, i*100+150), false);
            }

        }

        public static void CreateWires(int count)
        {
            wires = new Wires[count][];
            for(int i=0; i<count; i++)
            {
                wires[i] = new Wires[6];
                for(int j=0; j < 6; j++)
                {
                    wires[i][j] = new Wires(lights[i].GetCoordinate(), j);
                }
            }
        }

        public static int GetXLight(int number)
        {

            return lights[number].GetX();
        }

        public static int GetYLight(int number)
        {

            return lights[number].GetY();
        }

        public static bool GetStateLight(int number)
        {
            return lights[number].GetState();
        }
    }
}

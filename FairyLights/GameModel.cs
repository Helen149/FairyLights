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
        public static void CreateLights(int count)
        {
            lights = new Lights[count];
            for (int i = 0; i < count; i++)
            {
                lights[i] = new Lights(Tuple.Create(100 + i * 100, 100 + i * 100), i % 2 == 0);
            }

        }

        public static int GetXLight(int number)
        {

            return lights[number].GetCoordinate().Item1;
        }

        public static int GetYLight(int number)
        {

            return lights[number].GetCoordinate().Item2;
        }

        public static bool GetStateLight(int number)
        {
            return lights[number].GetState();
        }
    }
}

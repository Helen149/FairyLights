using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class Lights
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

    class LightsInModel
    {
        public Lights Light { get; private set; }
        public int[] Links { get; private set; }
        public List<Wires> Wires { get; private set; }
        public bool Involvement { get; set; }

        public LightsInModel(Point coordinate, bool stateOn, int radius)
        {
            Light = new Lights(coordinate, stateOn, radius);
            Links = new int[GameModel.FormFactor];
            Wires = new List<Wires>();
            Involvement = false;
        }

        public void DefinitionLinks(int numberLight, int countInRow, int row, int countRow)
        {
            Links[0] = row <= countRow / 2 ? numberLight - countInRow : numberLight - countInRow - 1;
            Links[1] = row <= countRow / 2 ? numberLight - countInRow + 1 : numberLight - countInRow;
            Links[2] = numberLight + 1;
            Links[3] = row < countRow / 2 ? numberLight + countInRow + 1 : numberLight + countInRow;
            Links[4] = row < countRow / 2 ? numberLight + countInRow : numberLight + countInRow - 1;
            Links[5] = numberLight - 1;
        }

        public void AddWires(int direction, ParamInModel param)
        {
            Wires.Add(new Wires(Light.Coordinate, direction, param.Length));
        }

    }
}

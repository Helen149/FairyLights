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

    class ParamInModel
    {
        public PointF[] Offset { get; private set; }
        public int Length { get; private set; }

        public int Radius { get; private set; }

        public ParamInModel(int wight, int height, int rank)
        {
            DefinitionLengthWire(wight, height, rank);
            Offset = new PointF[GameModel.FormFactor];
            DefinitionOffset();
            DefinitionRadiusLight(wight, height);
        }

        private void DefinitionLengthWire(int wight, int height, int rank)
        {
            Length = Math.Min(wight, height) / (2 * (1 + 2 * rank));
            if (Length % 2 != 0)
                Length--;
        }
        private void DefinitionRadiusLight(int wight, int height)
        {
            Radius = Math.Min(wight, height) / 60;
        }
        private void DefinitionOffset()
        {
            Offset[0] = new PointF(-Length / 2, -Length);
            Offset[1] = new PointF(Length / 2, -Length);
            Offset[2] = new PointF(Length, 0);
            Offset[3] = new PointF(Length / 2, Length);
            Offset[4] = new PointF(-Length / 2, Length);
            Offset[5] = new PointF(-Length, 0);
        }

        public int FindEndX(Wires wire)
        {
            return wire.CoordinateStart.X + Offset[wire.Direction].X;
        }

        public int FindEndY(Wires wire)
        {
            return wire.CoordinateStart.Y + Offset[wire.Direction].Y;
        }
    }
}

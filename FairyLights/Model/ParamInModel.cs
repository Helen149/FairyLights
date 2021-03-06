﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class ParamInModel
    {
        public Point[] Offset { get; private set; }
        public int Length { get; private set; }

        public int Radius { get; private set; }

        public ParamInModel(int wight, int height, int rank)
        {
            DefinitionLengthWire(wight, height, rank);
            Offset = new Point[GameModel.FormFactor];
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
            var partWire = 3;
            var maxSizeLight = Math.Min(wight, height) / 60;
            Radius = maxSizeLight < Length/partWire? maxSizeLight : Length/partWire;
        }
        private void DefinitionOffset()
        {
            Offset[0] = new Point(-Length / 2, -Length);
            Offset[1] = new Point(Length / 2, -Length);
            Offset[2] = new Point(Length, 0);
            Offset[3] = new Point(Length / 2, Length);
            Offset[4] = new Point(-Length / 2, Length);
            Offset[5] = new Point(-Length, 0);
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

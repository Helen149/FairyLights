using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyLights
{
    class DrawingGame
    {
        public static void DrawLight(PaintEventArgs e, Lights light)
        {
            var radius = light.Radius;
            Brush color = light.StateOn ? Brushes.Red : Brushes.Black;
            e.Graphics.FillEllipse(color, light.Coordinate.X - radius, light.Coordinate.Y - radius, 2*radius, 2*radius);
        }

        public static void DrawWire(PaintEventArgs e, Wires wire, ParamInModel param)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawLine(blackPen, wire.CoordinateStart.X, wire.CoordinateStart.Y, param.FindEndX(wire), param.FindEndY(wire));
        }
    }
}

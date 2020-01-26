using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FairyLights
{
    class DrawingGame
    {
        public static void DrawLight(PaintEventArgs e, Lights light)
        {
            var radius = light.Radius;
          
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(light.Coordinate.X - radius, light.Coordinate.Y - radius, 2 * radius, 2 * radius);

            PathGradientBrush pthGrBrush = new PathGradientBrush(path);

            if (light.StateOn)
                pthGrBrush.CenterColor = Color.FromArgb(255, 255, 0, 0);
            else
                pthGrBrush.CenterColor = Color.FromArgb(255, 183, 180, 170);

            Color[] colors = { Color.FromArgb(240, 0, 0, 0) };
            pthGrBrush.SurroundColors = colors;
            pthGrBrush.FocusScales = new PointF(0.2f, 0.2f);
            e.Graphics.FillEllipse(pthGrBrush, light.Coordinate.X - radius, light.Coordinate.Y - radius, 2 * radius, 2 * radius);
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawEllipse(blackPen, light.Coordinate.X - radius, light.Coordinate.Y - radius, 2 * radius, 2 * radius);
        }

        public static void DrawWire(PaintEventArgs e, Wires wire, ParamInModel param)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawLine(blackPen, wire.CoordinateStart.X, wire.CoordinateStart.Y, param.FindEndX(wire), param.FindEndY(wire));
        }

        public static void DrawBackground(PaintEventArgs e, Size size)
        {
            GraphicsPath path = new GraphicsPath();
            var rect = new Rectangle(0, 0, size.Width, size.Height);
            path.AddRectangle(rect);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = Color.FromArgb(255, 255, 255, 255);
            Color[] colors = { Color.FromArgb(240, 255, 255, 130) };
            pthGrBrush.SurroundColors = colors;
            pthGrBrush.FocusScales = new PointF(0.6f, 0.6f);
            e.Graphics.FillRectangle(pthGrBrush, rect);
        }
    }
}

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyLights
{
    class Controller
    {
        public GameModel Game { get; private set; }
        public MainForm GameForm { get; private set; }

        public void CreateGameAndForm(int wigth, int heigth)
        {
            GameForm = new MainForm();
            GameForm.ClientSize = new Size(wigth, heigth);
            Game = new GameModel(wigth, heigth, 2);
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < Game.Lights.Length; i++)
                {
                    if (DetectionHitCircle(Game.Lights[i].Light, e.X, e.Y))
                    {
                        RotationWires(Game.Lights[i]);
                        Game.Lights[i].Light.StateOn = !Game.Lights[i].Light.StateOn;
                        GameForm.Invalidate();
                    }

                }

            }
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 0; i < Game.Lights.Length; i++)
            {
                for (int j = 0; j < Game.Lights[i].Wires.Count; j++)
                {
                    DrawingGame.DrawWire(e, Game.Lights[i].Wires[j], Game.Param);
                }
            }

            for (int i=0; i<Game.Lights.Length; i++)
            {
                DrawingGame.DrawLight(e, Game.Lights[i].Light);
            }
        }

        private void RotationWires(LightsInModel light)
        {
            for (int i = 0; i < light.Wires.Count; i++)
                light.Wires[i].Direction = (light.Wires[i].Direction + 1) % GameModel.FormFactor;
        }
        private bool DetectionHitCircle(Lights light, int x, int y)
        {
            var dx = x - light.Coordinate.X;
            var dy = y - light.Coordinate.Y;
            var rad = light.Radius;
            return (dx * dx + dy * dy) <= (rad * rad);
        }
        public static void Main()
        {
            Controller controller = new Controller();
            controller.CreateGameAndForm(800, 800);
            controller.GameForm.SubscriptionEvent(controller);
            Application.Run(controller.GameForm);
        }
    }
}

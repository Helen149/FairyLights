using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyLights
{ 
    class MyForm : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            var graphics = e.Graphics;
            var diameter = 2 * Lights.GetRadius();
     
            for (int i=0; i<GameModel.lights.Length; i++)
            {
                Brush color = GameModel.GetStateLight(i) ? Brushes.Red : Brushes.Black;
                graphics.FillEllipse(color, GameModel.GetXLight(i)- Lights.GetRadius(), GameModel.GetYLight(i)- Lights.GetRadius(), diameter, diameter);
            }

            var wires = GameModel.wires;
            Pen blackPen = new Pen(Color.Black, 3);
            for(int i=0; i<GameModel.wires.Length; i++)
            {
                for (int j = 0; j < GameModel.wires[i].Length; j++)
                {
                    graphics.DrawLine(blackPen, wires[i][j].GetXStart(), wires[i][j].GetYStart(), wires[i][j].GetXEnd(), wires[i][j].GetYEnd());
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < GameModel.lights.Length; i++)
                {
                    if (DetectionHitCircle(GameModel.lights[i], e.X, e.Y))
                    {
                        GameModel.lights[i].SetState(!GameModel.GetStateLight(i));
                        Invalidate();
                    }
                        
                }
               
            }
        }

        public bool  DetectionHitCircle(Lights light, int x, int y)
        {
            var dx = x - light.GetX();
            var dy = y - light.GetY();
            var rad = Lights.GetRadius();
            return (dx * dx + dy * dy) <= (rad * rad);
        }

        public void GameForm(GameModel game)
        {
            Lights.SetRadius(ClientSize.Width, ClientSize.Height);
            Wires.SetLenght(ClientSize.Width, ClientSize.Height);
            GameModel.CreateLights(3);
            GameModel.CreateWires(3);
        }
        public static void Main()
        {
            var game = new GameModel();
            var gameForm = new MyForm();
            gameForm.Size = new Size(600, 600);
            gameForm.GameForm(game);
            Application.Run(gameForm);
        }
    }
}

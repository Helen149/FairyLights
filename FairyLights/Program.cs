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
            var graphics = e.Graphics;
            for(int i=0; i<GameModel.lights.Length; i++)
            {
                Brush color = GameModel.GetStateLight(i) ? Brushes.Red : Brushes.Black;
                graphics.FillEllipse(color, GameModel.GetXLight(i)- Lights.GetRadius(), GameModel.GetYLight(i)- Lights.GetRadius(), 2*Lights.GetRadius(), 2*Lights.GetRadius());
            }

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < GameModel.lights.Length; i++)
                {
                    var dx = e.X - GameModel.GetXLight(i);
                    var dy = e.Y - GameModel.GetYLight(i);
                    var rad = Lights.GetRadius();
                    if ((dx*dx+dy*dy) <= (rad*rad))
                    {
                        GameModel.lights[i].SetState(!GameModel.GetStateLight(i));
                        Invalidate();
                    }
                        
                }
               
            }
        }

        public MyForm(GameModel game)
        {
            Lights.SetRadius(ClientSize.Width, ClientSize.Height);
            GameModel.CreateLights(3);
        }

        public static void Main()
        {
            var game = new GameModel();
            Application.Run(new MyForm (game){ ClientSize = new Size(500, 500) });
        }
    }
}

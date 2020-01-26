using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyLights
{
    class GameController: IController
    {
        public event ChangeGameState ChangeGame;
        public GameModel Game { get; private set; }
        public List<Button> ButtonMenu { get; private set; }
        Panel panel;
        private bool StateGame;

        public GameController(Panel panel)
        {
            StateGame = true;
            this.panel = panel;
            panel.Paint += OnPaint;
            panel.MouseClick += OnMouseClick;
            panel.MouseDoubleClick += OnMouseClick;
            ButtonMenu = new List<Button>();
            CreateButton();
        }

        public void OnNewGame(int rank)
        {
            Game = new GameModel(panel.Width, panel.Height, rank);
        }

        private void CreateButton()
        {
            ButtonMenu.Add(new Button());
            ButtonMenu[0].Text = "В меню";
            ButtonMenu[0].Font = new Font("Arial", 12);
            ButtonMenu[0].Size = new Size(100, 50);
            ButtonMenu[0].Location = new System.Drawing.Point(10, panel.Height - 10- ButtonMenu[0].Height);
            panel.Controls.Add(ButtonMenu[0]);
            ButtonMenu[0].MouseClick += OnMouseClickButton;
            
        }

        public void OnMouseClickButton(object sender, MouseEventArgs e)
        {
            ChangeGame?.Invoke(MainController.State["MainMenu"]);
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (StateGame)
            {
                for (int i = 0; i < Game.Lights.Length; i++)
                {
                    if (DetectionHitCircle(Game.Lights[i].Light, e.X, e.Y))
                    {
                        RotationWires(Game.Lights[i], e);
                        Game.DefinitionStateLights();
                        panel.Invalidate();
                        DefinitionEndGame();
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

        private void RotationWires(LightsInModel light, MouseEventArgs e)
        {
            for (int i = 0; i < light.Wires.Count; i++)
            {
                var direction = light.Wires[i].Direction;
                if (e.Button == MouseButtons.Left)
                    light.Wires[i].Direction = (direction + 1) % GameModel.FormFactor;
                else
                    light.Wires[i].Direction = Math.Abs((direction +GameModel.FormFactor- 1)) % GameModel.FormFactor;
            }
                
        }
        private bool DetectionHitCircle(Lights light, int x, int y)
        {
            var dx = x - light.Coordinate.X;
            var dy = y - light.Coordinate.Y;
            var partWireToClick = 2.0 / 3;
            var rad = partWireToClick * Game.Param.Length;
            return (dx * dx + dy * dy) <= (rad * rad);
        }

        private void DefinitionEndGame()
        {
            if (CheckLightsOn())
            {
                StateGame = false;
                string message = "You WIN!";
                string caption = "Victory";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
                
        }

        private bool CheckLightsOn()
        {
            for (int i = 0; i < Game.Lights.Length; i++)
            {
                if (!Game.Lights[i].Light.StateOn)
                    return false;
            }
            return true;
        }
    }
}

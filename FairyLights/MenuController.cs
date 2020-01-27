using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class MenuController : IController
    {
        public event ChangeGameState ChangeGame;
        public Menu MainMenu { get; private set; }
        public List<Button> ButtonMenu { get; private set; }
        Panel panel;

        public MenuController(Panel panel)
        {
            MainMenu = new Menu();
            ButtonMenu = new List<Button>();
            this.panel = panel;
            panel.Paint += OnPaint;
            CreateButton();
        }

        private void CreateButton()
        {
            for (int i = 0; i < MainMenu.ItemsMenu.Count; i++)
            {
                ButtonMenu.Add(new Button());
                DefinitionButton(i);
                panel.Controls.Add(ButtonMenu[i]);
                ButtonMenu[i].MouseClick += OnMouseClick;
            }
        }

        private void DefinitionButton(int numberButton)
        {
            var sizePanel = panel.Size;
            ButtonMenu[numberButton].Text = MainMenu.ItemsMenu[numberButton];
            var countButton = MainMenu.ItemsMenu.Count;
            var indentTopBottom = 2;
            var heightBut = sizePanel.Height / (countButton + indentTopBottom);
            var gap = heightBut / 10;
            heightBut = heightBut - gap;
            var sizeFactorText = 5;
            ButtonMenu[numberButton].Font = new Font("Arial", heightBut/ sizeFactorText);
            ButtonMenu[numberButton].Size = new Size(sizePanel.Width / 2, heightBut);
            ButtonMenu[numberButton].Location = new System.Drawing.Point(sizePanel.Width / 4, (numberButton+1) * (heightBut+gap));
            ButtonMenu[numberButton].BackColor = Color.LemonChiffon;
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(ButtonMenu[0]))
                ChangeGame?.Invoke(MainController.State["Game"]);
            else if (sender.Equals(ButtonMenu[1]))
                ChangeGame?.Invoke(2);
            else
                ChangeGame?.Invoke(MainController.State["Exit"]);
        }
        public void OnPaint(object sender, PaintEventArgs e)
        {
            DrawingGame.DrawBackground(e, panel.Size);
        }

    }
}

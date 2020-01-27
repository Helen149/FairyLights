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
        int typeMenu;
        public int SizeGame { get; private set; }

        public MenuController(Panel panel, int typeMenu)
        {
            this.typeMenu = typeMenu;
            MainMenu = new Menu(typeMenu);
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
            if (typeMenu == 0)
                ClickMainMenu(sender);
            else
                ClickLvlMenu(sender);
        }

        private void ClickMainMenu(object sender)
        {
            if (sender.Equals(ButtonMenu[0]))
                ChangeGame?.Invoke(MainController.State["LvlMenu"]);
            else if (sender.Equals(ButtonMenu[1]))
                ChangeGame?.Invoke(MainController.State["Help"]);
            else
                ChangeGame?.Invoke(MainController.State["Exit"]);
        }

        private void ClickLvlMenu(object sender)
        {
            var minSizeGame = 2;
            for (int i = 0; i < ButtonMenu.Count; i++)
                if (sender.Equals(ButtonMenu[i]))
                    SizeGame = i + minSizeGame;
            ChangeGame?.Invoke(MainController.State["Game"]);
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            DrawingGame.DrawBackground(e, panel.Size);
        }

    }

}

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
        public event AddNewButton AddButton;
        public Menu MainMenu { get; private set; }
        public List<Button> ButtonMenu { get; private set; }

        Size sizeForm;
        public MenuController(Size sizeForm)
        {
            MainMenu = new Menu();
            ButtonMenu = new List<Button>();
            this.sizeForm = sizeForm;
        }

        public void CreateButton(int numberPanel)
        {
            for (int i = 0; i < MainMenu.ItemsMenu.Count; i++)
            {
                ButtonMenu.Add(new Button());
                DefinitionButton(i);
                AddButton?.Invoke(ButtonMenu[i], numberPanel);
                ButtonMenu[i].MouseClick += ButtonClick;
            }
        }

        private void DefinitionButton(int numberButton)
        {
            ButtonMenu[numberButton].Text = MainMenu.ItemsMenu[numberButton];
            var countButton = MainMenu.ItemsMenu.Count;
            var indentTopBottom = 2;
            var heightBut = sizeForm.Height / (countButton + indentTopBottom);
            var gap = heightBut / 10;
            heightBut = heightBut - gap;
            var sizeFactorText = 5;
            ButtonMenu[numberButton].Font = new Font("Arial", heightBut/ sizeFactorText);
            ButtonMenu[numberButton].Size = new Size(sizeForm.Width / 2, heightBut);
            ButtonMenu[numberButton].Location = new System.Drawing.Point(sizeForm.Width / 4, (numberButton+1) * (heightBut+gap));
            ButtonMenu[numberButton].BackColor = Color.LemonChiffon;
        }

        public void ButtonClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(ButtonMenu[0]))
                ChangeGame?.Invoke(MainController.State["MainMenu"]);
            else if (sender.Equals(ButtonMenu[1]))
                ChangeGame?.Invoke(2);
            else
                ChangeGame?.Invoke(3);
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {

        }
        public void OnPaint(object sender, PaintEventArgs e)
        {
            DrawingGame.DrawBackground(e, sizeForm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class MenuController : Controller
    {
        public event ChangeGameState ChangeGame;
        public event AddNewButton AddButton;
        Menu MainMenu { get; set; }
        public int ChooseGameStage { get; private set; }
        Size sizeForm;
        public List<Button> ButtonMenu { get; private set; }
        public MenuController(Size sizeForm)
        {
            MainMenu = new Menu();
            this.sizeForm = sizeForm;
            ButtonMenu = new List<Button>();
        }

        public void CreateButton()
        {
            for (int i = 0; i < MainMenu.ItemsMenu.Count; i++)
            {
                ButtonMenu.Add(new Button());
                DefinitionButton(i);
                AddButton?.Invoke(ButtonMenu[i]);
                ButtonMenu[i].MouseClick += OnMouseClick;
            }
        }

        private void DefinitionButton(int numberButton)
        {
            ButtonMenu[numberButton].Text = MainMenu.ItemsMenu[numberButton];
            ButtonMenu[numberButton].Location = new System.Drawing.Point(100 + numberButton * 100, 100 + numberButton * 100);
            ButtonMenu[numberButton].Size = new Size(100, 100);
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(ButtonMenu[0]))
                ChangeGame?.Invoke(1);
            else if (sender.Equals(ButtonMenu[1]))
                ChangeGame?.Invoke(2);
            else
                ChangeGame?.Invoke(3);
        }
        public void OnPaint(object sender, PaintEventArgs e)
        {

        }
    }
}

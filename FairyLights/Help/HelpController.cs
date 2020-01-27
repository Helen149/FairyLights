using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    class HelpController:IController
    {
        public event ChangeGameState ChangeGame;
        public Help Help { get; private set; }
        public List<Button> ButtonMenu { get; private set; }
        Panel panel;
        Label label;
        public HelpController(Panel panel)
        {
            Help = new Help();
            ButtonMenu = new List<Button>();
            this.panel = panel;
            panel.Paint += OnPaint;
            CreateButton();
            CreateLable();
        }

        private void CreateButton()
        {
            ButtonMenu.Add(new Button());
            ButtonMenu[0].Text = "В меню";
            ButtonMenu[0].Font = new Font("Arial", 12);
            ButtonMenu[0].Size = new Size(100, 50);
            var indent = 10;
            ButtonMenu[0].Location = new System.Drawing.Point(indent, panel.Height - indent - ButtonMenu[0].Height);
            ButtonMenu[0].BackColor = Color.LemonChiffon;
            panel.Controls.Add(ButtonMenu[0]);
            ButtonMenu[0].MouseClick += OnMouseClickButton;
        }

        private void CreateLable()
        {
            label = new Label();
            label.Text = Help.Rules;
            var indent = 300;
            label.Size = new Size(panel.Width-indent, panel.Height-indent);
            label.Location = new System.Drawing.Point(indent/2, indent/2);
            label.Font = new Font("Arial", 20);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.White;
            panel.Controls.Add(label);
        }

        public void OnMouseClickButton(object sender, MouseEventArgs e)
        {
            ChangeGame?.Invoke(MainController.State["MainMenu"]);
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            DrawingGame.DrawBackground(e, panel.Size);
        }
    }
}

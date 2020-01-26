using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public delegate void ChangeGameState(int GameState);
    public delegate void AddNewButton(Button button);
    public interface Controller
    {
        event ChangeGameState ChangeGame;
        event AddNewButton AddButton;
        void CreateButton();
        void OnMouseClick(object sender, MouseEventArgs e);
        void OnPaint(object sender, PaintEventArgs e);
    }
    class MainController
    {
        public MainForm MainForm { get; private set; }
        public Controller[] Controllers { get; private set; }

        public MainController(int wigth, int heigth)
        {
            MainForm = new MainForm();
            MainForm.ClientSize = new Size(wigth, heigth);
            Controllers = new Controller[1];
            Controllers[0] = new MenuController(MainForm.ClientSize);
            Controllers[0].AddButton += OnAddButton;
            Controllers[0].CreateButton();
            Controllers[0].ChangeGame += OnChangeGame;
        }

        public void OnAddButton(Button button)
        {
            MainForm.Controls.Add(button);
        }

        public void OnChangeGame(int GameState)
        {
            if(GameState==1)
                MainForm.BackColor = Color.Aqua;
            else if(GameState == 2)
                MainForm.BackColor = Color.Coral;
            else
                MainForm.BackColor = Color.LawnGreen;
        }
    }
}

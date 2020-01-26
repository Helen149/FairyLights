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
    public delegate void AddNewButton(Button button, int numberPanel);
    public interface IController
    {
        event ChangeGameState ChangeGame;
        event AddNewButton AddButton;
        void CreateButton(int numberPanel);
        void OnMouseClick(object sender, MouseEventArgs e);
        void OnPaint(object sender, PaintEventArgs e);
    }
    class MainController
    {
        public MainForm MainForm { get; private set; }
        public IController[] Controllers { get; private set; }
        public static Dictionary<string, int> State { get; private set; }


        public MainController(int wigth, int heigth)
        {
            DefinitionState();
            MainForm = new MainForm(State.Count - 1, new Size(wigth, heigth));
            Controllers = new IController[State.Count-1];
            CreateControllers();
        }

        private void DefinitionState()
        {
            State = new Dictionary<string, int>();
            State.Add("MainMenu", 0);
            State.Add("Game", 1);
            //State.Add("Help", 2);
            State.Add("Exit", 3);
        }

        private void CreateControllers()
        {
            Controllers[0] = new MenuController(MainForm.ClientSize);
            Controllers[1] = new GameController(MainForm.ClientSize);

            for (int i=0; i<Controllers.Length; i++)
            {
                SubscriptionEventController(Controllers[i]);
                Controllers[i].CreateButton(i);
                MainForm.SubscriptionEvent(MainForm.Panels[i], Controllers[i]);
            }      
        }

        private void SubscriptionEventController(IController controller)
        {
            controller.AddButton += OnAddButton;
            controller.ChangeGame += OnChangeGame;
        }
        public void OnAddButton(Button button, int numberPanel)
        {
            MainForm.Panels[numberPanel].Controls.Add(button);
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

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public delegate void ChangeGameState(int gameState);
    public delegate void StartNewGame(int rankGame);
    public interface IController
    {
        event ChangeGameState ChangeGame;
        void OnNewGame(int rank);
    }
    class MainController
    {
        event StartNewGame NewGame;
        public MainForm MainForm { get; private set; }
        public IController[] Controllers { get; private set; }
        public static Dictionary<string, int> State { get; private set; }


        public MainController(int wigth, int heigth)
        {
            DefinitionState();
            MainForm = new MainForm(State.Count - 1, new Size(wigth, heigth));
            Controllers = new IController[State.Count-1];
            CreateControllers();
            VisabilityPanels(0);
            NewGame += Controllers[1].OnNewGame;
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
            Controllers[0] = new MenuController(MainForm.Panels[0]);
            Controllers[1] = new GameController(MainForm.Panels[1]);

            for (int i = 0; i < Controllers.Length; i++)
                Controllers[i].ChangeGame += OnChangeGame;
        }

        private void VisabilityPanels(int visiblePanel)
        {
            for (int i = 0; i < MainForm.Panels.Count; i++)
                MainForm.Panels[i].Visible = false;
            MainForm.Panels[visiblePanel].Visible = true;
        }

        public void OnChangeGame(int gameState)
        {
            switch(gameState)
            {
                case (0):
                    VisabilityPanels(0);
                    break;
                case (1):
                    VisabilityPanels(1);
                    NewGame?.Invoke(2);
                    break;
            }
        }

        public static void Main()
        {
            /*GameController controller = new GameController();
            controller.CreateGameAndForm(800, 800);
            controller.GameForm.SubscriptionEvent(controller);
            Application.Run(controller.GameForm);*/
            var mainController = new MainController(800, 800);
            Application.EnableVisualStyles();
            Application.Run(mainController.MainForm);
        }
    }
}

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
    public interface IController
    {
        event ChangeGameState ChangeGame;
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
            VisabilityPanels(0);
        }

        private void DefinitionState()
        {
            State = new Dictionary<string, int>();
            State.Add("MainMenu", 0);
            State.Add("LvlMenu", 1);
            State.Add("Game", 2);
            State.Add("Help", 3);
            State.Add("Exit", 4);
        }

        private void CreateControllers()
        {
            Controllers[0] = new MenuController(MainForm.Panels[0], 0);
            Controllers[1] = new MenuController(MainForm.Panels[1], 1);
            Controllers[2] = new GameController(MainForm.Panels[2]);
            Controllers[3] = new HelpController(MainForm.Panels[3]);

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
                    VisabilityPanels(gameState);
                    break;
                case (1):
                    VisabilityPanels(gameState);
                    break;
                case (2):
                    VisabilityPanels(gameState);
                    var lvlControl = (MenuController)Controllers[1];
                    var game = (GameController)Controllers[2];
                    game.CreateNewGame(lvlControl.SizeGame);
                    break;
                case (3):
                    VisabilityPanels(gameState);
                    break;
                case (4):
                    Application.Exit();
                    break;
            }
        }

        public static void Main()
        {
            var mainController = new MainController(800, 800);
            Application.EnableVisualStyles();
            Application.Run(mainController.MainForm);
        }
    }
}

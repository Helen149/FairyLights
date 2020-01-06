using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyLights
{
    class GameModel
    {
        public static Lights[] lights;
        public static void CreateLights(int count)
        {
            lights = new Lights[count];
            for(int i=0; i<count; i++)
            {
               lights[i] = new Lights(Tuple.Create(i*100, i*100), i%2==0);
            }
            
        }

        public static int GetXLight(int number)
        {
            
            return lights[number].GetCoordinate().Item1;
        }

        public static int GetYLight(int number)
        {

            return lights[number].GetCoordinate().Item2;
        }

        public static bool GetStateLight(int number)
        {
            return lights[number].GetState();
        }
    }

    class Lights 
    {
        Tuple<int, int> coordinate;
        bool stateOn;

        public Lights(Tuple<int, int> coordinate, bool stateOn)
        {
            this.coordinate = coordinate;
            this.stateOn = stateOn;
        }
        public Tuple<int, int> GetCoordinate()
        {
            return coordinate;
        }

        public bool GetState()
        {
            return stateOn;
        }
    }

    class MyForm : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            for(int i=0; i<GameModel.lights.Length; i++)
            {
                Brush color = GameModel.GetStateLight(i) ? Brushes.Red : Brushes.Black;
                graphics.FillEllipse(color, GameModel.GetXLight(i), GameModel.GetYLight(i), 100, 100);
            }

        }


        public MyForm(GameModel game)
        {
            GameModel.CreateLights(3);
        }

        public static void Main()
        {
            var game = new GameModel();
            Application.Run(new MyForm (game){ ClientSize = new Size(500, 500) });
        }
    }
}

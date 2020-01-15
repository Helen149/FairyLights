using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public interface IGameModel
    {
        void CreateGame(int wight, int height, int rank);
    }

    class GameModel//: IGameModel
    {
        public LightsInModel[] Lights { get; private set; }
        public ParamInModel Param { get; private set; }
        public const int FormFactor = 6;

        public GameModel(int wight, int height, int rank)
        {
            Param = new ParamInModel(wight, height, rank);
            CreateLights(rank, wight / 2, height / 2);
            ValidationLinks();
            CreateWires();
        }
       
        private void CreateLights(int rank, int xCenter, int yCenter)
        {
            int count = 6*CalcCountLights(rank)+1;
            Lights = new LightsInModel[count];
            int countRow = 1 + 2 * rank;
            int countInRow = countRow - rank;
            int delta = 2 * Param.Length;
            int yStart = yCenter - rank* delta;
            for (int i = 0, k=0; i < countRow; i++)
            {
                int xStart = xCenter - (countInRow - 1) * Param.Length;
                for(int j = 0; j<countInRow; j++, k++)
                {
                    Lights[k] = new LightsInModel(new Point(j * delta + xStart, i * delta + yStart), false, Param.Radius);
                    Lights[k].DefinitionLinks(k, countInRow, i, countRow);
                }
                countInRow = i < countRow / 2 ? countInRow+1 : countInRow-1;
            }
            Lights[count/2].Light.StateOn = true;
        }

        static int CalcCountLights(int rank)
        {
            return rank > 0 ? rank + CalcCountLights(rank - 1) : 0;
        }
        
        private void ValidationLinks()
        {
            for(int i = 0; i<Lights.Length; i++)
            {
                for(int j= 0; j<FormFactor; j++)
                {
                    int lightConnect = Lights[i].Links[j];
                    if (lightConnect < 0 || lightConnect >= Lights.Length || Math.Abs(Lights[i].Light.Coordinate.X-Lights[lightConnect].Light.Coordinate.X)>2*Param.Length)
                        Lights[i].Links[j] = -1;
                }
            }
        }

        private void CreateWires()
        {
            Random rnd = new Random();
            for (int i = 0; i < Lights.Length; i++)
            {
                if (!Lights[i].Light.StateOn)
                    CreateWayToSource(i, rnd);
            }                 
        }

        private void CreateWayToSource(int numberLight, Random rnd)
        {
            int direction = DefinitionDirectionWay(numberLight, rnd);
            int numbLightConnect=Lights[numberLight].Links[direction];
                       
            if (!Lights[numbLightConnect].Light.StateOn)
            {
                Lights[numberLight].Involvement = true;
                CreateWayToSource(numbLightConnect, rnd);
                Lights[numberLight].Involvement = false;
            }

            Lights[numberLight].Light.StateOn = true;
        }

        private int DefinitionDirectionWay(int numberLight, Random rnd)
        {
            int direction;
            int numberLightConnect;
            if (DefinitionExistenceWays(numberLight))
            {
                do
                {
                    direction = rnd.Next(FormFactor);
                    numberLightConnect = Lights[numberLight].Links[direction];
                } while (numberLightConnect == -1 || Lights[numberLightConnect].Involvement);

                Lights[numberLight].AddWires(direction, Param);
                Lights[numberLightConnect].AddWires((direction + 3) % 6, Param);
            }
            else
            {
                direction = Lights[numberLight].Wires[0].Direction;
            }
            return direction;
        }
        private bool DefinitionExistenceWays(int numberLight)
        {
            for (int i = 0; i < FormFactor; i++)
            {
                int numberLightConnect = Lights[numberLight].Links[i];
                if (numberLightConnect !=-1 && !Lights[numberLightConnect].Involvement)
                    return true;
            }
            
            return false;
        }

    }
}

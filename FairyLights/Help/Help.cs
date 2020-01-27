using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class Help
    {
        public string Rules { get; private set; }

        public Help()
        {
            Rules = "Цель: собрать схему так, чтобы все лампочки загорелись.\n\n" +
                    "Управление осуществляется мышкой:\n" +
                    "Левый клик - поворот по часовой стрелке\n" +
                    "Правый клик - поворот против часовой стрелки\n\n" +
                    "Удачи!";
        }
    }
}

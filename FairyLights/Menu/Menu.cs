using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyLights
{
    public class Menu
    {
        public List<string> ItemsMenu { get; private set; }

        public Menu()
        {
            ItemsMenu = new List<string>();
            ItemsMenu.Add("Новая  игра");
            ItemsMenu.Add("Справка");
            ItemsMenu.Add("Выход");
        }
    }
}

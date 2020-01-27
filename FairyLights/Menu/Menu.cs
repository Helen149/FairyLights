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

        public Menu(int typeMenu)
        {
            ItemsMenu = new List<string>();
            if (typeMenu == 0)
                MainMenu();
            else
                LvlMenu();
        }

        private void MainMenu()
        {
            ItemsMenu.Add("Новая  игра");
            ItemsMenu.Add("Справка");
            ItemsMenu.Add("Выход");
        }

        private void LvlMenu()
        {
            ItemsMenu.Add("Легкая");
            ItemsMenu.Add("Нормальная");
            ItemsMenu.Add("Сложная");
            ItemsMenu.Add("Экспертная");
        }
    }
}

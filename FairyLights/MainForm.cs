using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace FairyLights
{ 
    class MainForm : Form
    {
        public List<Panel> Panels { get; private set; }
        
        public MainForm(int countPanel, Size size)
        {
            ClientSize = size;
            Panels = new List<Panel>();
            CreatePanel(countPanel);
        }

        private void CreatePanel(int countPanel)
        {
            for (int i = 0; i < countPanel; i++)
            {
                Panels.Add(new Panel());
                Panels[i].Size = ClientSize;
                Controls.Add(Panels[i]);
                typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Panels[i], new object[] { true });
            }      
        }

    }
}

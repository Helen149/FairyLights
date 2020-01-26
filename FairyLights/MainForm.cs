using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            }      
        }
        public void SubscriptionEvent(Panel panel,IController controller)
        {
            DoubleBuffered = true;
            
            panel.MouseClick += controller.OnMouseClick;
            panel.MouseDoubleClick += controller.OnMouseClick;
            panel.Paint += controller.OnPaint;
        }

    }
}

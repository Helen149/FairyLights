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
        public void SubscriptionEvent(Controller controller)
        {
            DoubleBuffered = true;
            
            MouseClick += controller.OnMouseClick;
            Paint += controller.OnPaint;
        }

    }
}

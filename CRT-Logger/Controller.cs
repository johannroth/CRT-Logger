using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger
{
    public class Controller
    {
        private Gui gui;
        private Services.Ticker ticker;

        public Controller(Gui gui)
        {
            this.gui = gui;
            gui.testButtonClick += OnTestButtonClick;

            ticker = new Services.Ticker(1000);
            ticker.tick += OnTick;
        }

        private void OnTestButtonClick(object o, EventArgs e)
        {
            ticker.toggleTicker();
        }

        private void OnTick(Services.Ticker source)
        {
            Console.Beep();
        }
    }
}

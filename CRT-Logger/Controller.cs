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
        private Services.Clock clock;
        private Services.Ticker secondTicker;

        public Controller(Gui gui)
        {
            this.gui = gui;

            // Eventhandler for ButtonClick event
            gui.tickerToggleButtonClick += OnTickerToggleButtonClick;

            // Start a new clock
            clock = new Services.Clock();

            // Start a new ticker
            secondTicker = new Services.Ticker(1000);
            secondTicker.tick += OnTick;
        }

        private void OnTickerToggleButtonClick(object o, EventArgs e)
        {
            secondTicker.toggleTicker();
        }
        private void OnTick(Services.Ticker source)
        {
            if (source == secondTicker)
            {
                Console.Beep();
                setGuiTime();
            }
            
        }

        // Gets Time from clock and pushes it to gui
        private void setGuiTime()
        {
            string time = clock.getDateTime().ToString("dd.MM. HH:mm:ss");
            gui.setClockTime(time);
        }
    }
}

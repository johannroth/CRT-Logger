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

            // Eventhandler für ButtonClick Event
            gui.tickerToggleButtonClick += OnTickerToggleButtonClick;

            // Clock instanzieren
            clock = new Services.Clock();

            // Ticker instanzieren
            secondTicker = new Services.Ticker(1000);
            secondTicker.tick += OnTick;
        }

        private void OnTickerToggleButtonClick(object o, EventArgs e)
        {
            secondTicker.toggleTicker();
            gui.setClockTime("test");
        }

        // 
        private void OnTick(Services.Ticker source)
        {
            if (source == secondTicker)
            {
                Console.Beep();
                setGuiTime();
            }
            
        }

        // Zeit aus Clock holen und an Gui weitergeben
        private void setGuiTime()
        {
            gui.setClockTime(clock.getDateTime().ToString("dd.MM. HH:mm:ss"));
        }
    }
}

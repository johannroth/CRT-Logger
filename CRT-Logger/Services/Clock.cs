using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger.Services
{
    class Clock
    {
        public DateTime getDateTime()
        {
            return System.DateTime.Now;
        }

        public string getDateTimeString()
        {
            return this.getDateTime().ToString("dd.MM. HH:mm:ss.fff");
        }
    }
}

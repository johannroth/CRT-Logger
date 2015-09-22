using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger.Services
{
    public class Clock
    {
        /// <summary>
        /// Returns current Time as DateTime object
        /// </summary>
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
        /// <summary>
        /// Returns time since timeInPast as TimeSpan object.
        /// </summary>
        /// <param name="timeInPast">DateTime in the past.</param>
        public TimeSpan GetTimeSince(DateTime timeInPast)
        {
            return DateTime.Now.Subtract(timeInPast);
        }
        public string GetTimeSinceStringLong(DateTime timeInPast)
        {
            return DateTime.Now.Subtract(timeInPast).ToString(@"hh\:mm\:ss\.fff");
        }
        public string GetTimeSinceStringShort(DateTime timeInPast)
        {
            return DateTime.Now.Subtract(timeInPast).ToString(@"hh\:mm\:ss");
        }
        public string GetDateTimeString()
        {
            return this.GetDateTime().ToString("dd.MM.yyyy HH:mm:ss.fff");
        }
    }
}

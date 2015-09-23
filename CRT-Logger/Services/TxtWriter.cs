using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger.Services
{
    public class TxtWriter
    {
        private string filePath;

        public TxtWriter(string filePath)
        {
            this.filePath = filePath;
            if (!System.IO.File.Exists(filePath))
            {
                var logFile = System.IO.File.Create(filePath);
                logFile.Close();
            }
        }

        public void AddLine(string line)
        {
            using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(filePath,true))
            {
                logFile.WriteLine(line);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common.Parameter
{
    public class TimeDelay
    {
        public int timeOut { get; set; }
        public int timeLoop { get; set; }
        public int delayHeatbeat { get; set; }
        public int delayTimeout { get; set; }


        public TimeDelay()
        {
            timeLoop = 50;
            timeOut = 1000;
            delayHeatbeat = 1000;

            delayTimeout = 5000;
        }
    }
}

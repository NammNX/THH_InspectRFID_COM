using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common.Parameter
{
    public class TimeDelay
    {
        
        public int timeLoopCOM { get; set; }
        public int timeAutoSaveExcel { get; set; }
        public int timeLoopChart { get; set; }
        public int delayHeatbeat { get; set; }
        


        public TimeDelay()
        {
            timeLoopCOM = 5;
            timeLoopChart = 1000;
            delayHeatbeat = 1000;
            timeAutoSaveExcel = 10000;
        }
    }
}

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
        public int timeLoopWriteExcel { get; set; }
        public int timeLoopShowListView { get; set; }
        public int timeAutoSaveExcel { get; set; }
        public int timeLoopChart { get; set; }
        public int delayHeatbeat { get; set; }
        


        public TimeDelay()
        {
            timeLoopWriteExcel = 10;
            timeLoopShowListView = 10;
            timeLoopCOM = 5;
            timeLoopChart = 1000;
            delayHeatbeat = 1000;
            timeAutoSaveExcel = 10000;
        }
    }
}

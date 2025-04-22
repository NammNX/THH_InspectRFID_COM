using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common.Parameter
{
    public enum eProcessing
    {
        None,
        ReceiveData,
        FlushDataBase,
        UpdateLog,
        UpdateChart


    }

    public class StepControl
    {
        public eProcessing Cur_Processing;
        public eProcessing Old_Processing;


        [JsonIgnore]
        public Stopwatch watchTimeprocess;

        public StepControl()
        {
            Cur_Processing = eProcessing.None;
            Old_Processing = eProcessing.None;
            watchTimeprocess = new Stopwatch();
        }

        public void SetStep(eProcessing step)
        {
            if (Cur_Processing == step)
            {
                Console.WriteLine("Dupplicate Step");
                return;
            }
            //Update step
            Old_Processing = Cur_Processing;
            Cur_Processing = step;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Old step = {Old_Processing}");
            Console.WriteLine($"Cur step = {Cur_Processing}");
        }
    }
}

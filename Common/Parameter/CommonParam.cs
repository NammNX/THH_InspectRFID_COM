using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common.Parameter
{
    public class CommonParam
    {
        private static CommonParam _instance;
        private static readonly object _lock = new object();
        public static CommonParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CommonParam();
                    }
                }
            }
            return _instance;
        }
        public MyComport myComport { get; set; }
        public MyComport myComportIQC { get; set; }
        public MyComport myComportOQC { get; set; }
        public DevParam devParam { get; set; }
        public TimeDelay timeDelay { get; set; }
        [JsonIgnore]
        public Queue<string> queueData;
        [JsonIgnore]
        public object queueLock;
        CommonParam()
        {
            timeDelay = new TimeDelay();
            myComport = new MyComport();
            myComportIQC = new MyComport();
            myComportOQC = new MyComport();
            devParam = DevParam.GetInstance();
            queueData = new Queue<string>(MyDefine.MAX_QUEUE_DATA);
            queueLock = new object();
        }
    }
}

using MaterialSkin.Controls;

namespace TanHungHa.Tabs
{
    public partial class FormInfo : MaterialForm
    {
        private static FormInfo _instance;
        private static readonly object _lock = new object();
        public static FormInfo GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormInfo();
                    }
                }
            }
            return _instance;
        }

        public FormInfo()
        {
            InitializeComponent();
        }
    }
}

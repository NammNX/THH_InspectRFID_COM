using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TanHungHa.Common.Parameter
{
    public class MyModel
    {
        private string name;
        private string solPath;
        private bool isActive;


        [Category("Model Param"), DescriptionAttribute("Name of model"), ReadOnly(true)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }

        [Category("Model Param"), DescriptionAttribute("Active = True, deactive = False"), ReadOnly(true)]
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                }
            }
        }

        [Category("Model Param"), DescriptionAttribute("File Job/Solution path"), ReadOnly(true)]
        public string SolPath
        {
            get
            {
                return solPath;

            }
            set
            {
                if (solPath != value)
                {
                    solPath = value;
                }
            }
        }
        public MyModel Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<MyModel>(serialized);
        }
        public MyModel()
        {
            Name = "Demo";
            IsActive = false;
            SolPath = MyDefine.path_solution;
        }
        public MyModel(string name)
        {
            this.Name = name;
            this.isActive = false;
            this.SolPath = MyDefine.path_solution;
        }
    }
}
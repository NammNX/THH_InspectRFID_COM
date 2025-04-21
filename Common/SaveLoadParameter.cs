using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class SaveLoadParameter
    {
        public static void Save_Parameter(object param)
        {
            //save
            if (MyLib.fileIsExists(MyDefine.file_config))
            {
                Save_Parameter(param, MyDefine.file_config);
            }
            else
            {
                //create folder
                FileInfo fileInfo = new FileInfo(MyDefine.file_config);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);

                //create file
                using (FileStream f = File.Create(MyDefine.file_config))
                {
                    f.Close();
                    Console.WriteLine($"Create file {MyDefine.file_config}");
                }

                //save param to file
                Save_Parameter(param, MyDefine.file_config);
            }
        }

        public static object Load_Parameter(object param)
        {
            if (MyLib.fileIsExists(MyDefine.file_config))
            {
                using (StreamReader file = File.OpenText(MyDefine.file_config))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    param = serializer.Deserialize(file, param.GetType());
                }
            }
            else
            {
                MyLib.log($"Not found {MyDefine.file_config}");
                return null;
            }

            return param;
        }

        public static void Save_Parameter(object param, string file_name)
        {
            //save
            if (MyLib.fileIsExists(file_name))
            {
                // serialize JSON directly to a file
                Console.WriteLine("Save parameter to file " + file_name);
                using (StreamWriter file = File.CreateText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, param);
                }
            }
            else
            {
                //create folder
                FileInfo fileInfo = new FileInfo(file_name);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);

                //create file
                using (FileStream f = File.Create(file_name))
                {
                    f.Close();
                    Console.WriteLine($"Create file {file_name}");
                }

                // serialize JSON directly to a file
                Console.WriteLine("Save parameter to file " + file_name);
                using (StreamWriter file = File.CreateText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, param);
                }
            }
        }



        public static object Load_Parameter(object param, string file_name)
        {
            if (MyLib.fileIsExists(file_name))
            {
                using (StreamReader file = File.OpenText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    param = serializer.Deserialize(file, param.GetType());
                }
            }
            else
            {
                //MyLib.showDlgError($"Not found {file_name}");
                MyLib.log($"Not found {file_name}");
                return null;
            }

            return param;
        }
    }
}

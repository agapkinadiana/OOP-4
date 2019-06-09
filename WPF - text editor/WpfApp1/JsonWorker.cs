using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WpfApp1
{
    class JsonWorker
    {
        public static string path = "exmpl.json";
        public static T deserializeProducts<T>()
        {
            T objs = default(T);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            if (File.Exists(path))
            {
                objs = ReadFile(objs, jsonFormatter);
            }
            return objs;
        }
        public static bool CheckFile()
        {
            using (FileStream file = File.OpenRead(path))
            {
                if (file.Length == 0)
                    return true;
            }
            return false;
        }
        public static void serializeProduct<T>(T obj)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            if (!File.Exists(path) || CheckFile())
            {
                CreateNewFile(obj, jsonSerializer);
            }
            else
            {
                WriteProduct(obj, jsonSerializer);
            }
        }

        #region InnerWork
        private static T ReadFile<T>(T objs, DataContractJsonSerializer jsonFormatter)
        {
            if (!CheckFile())
            {
                using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    objs = (T)jsonFormatter.ReadObject(file);
                }
            }
            return objs;
        }
        private static void AppendString(string app)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(app);
            }
        }
        private static void WriteProduct<T>(T obj, DataContractJsonSerializer jsonSerializer)
        {
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                jsonSerializer.WriteObject(file, obj);
            }
        }
        private static void CreateNewFile<T>(T obj, DataContractJsonSerializer jsonSerializer)
        {
            AppendString("[");
            WriteProduct(obj, jsonSerializer);
            AppendString("]");
        }
        private static void DeleteSymbol()
        {
            FileStream file = File.OpenWrite(path);
            file.SetLength(file.Length - 3);
            file.Close();
        }
        private static void AddToFile<T>(T obj, DataContractJsonSerializer jsonSerializer)
        {
            DeleteSymbol();
            AppendString(", ");
            WriteProduct(obj, jsonSerializer);
            AppendString("]");
        }
        #endregion
    }
}

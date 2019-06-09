using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class SaveUri
    {
        private static bool CheckCount(List<String> list)
        {
            if (list != null)
            {
                if (list.Count >= 10)
                    return false;
            }
            return true;
        }
        private static void AddUri(List<String> list, String path)
        {
            list.Add(path);
            JsonWorker.serializeProduct<List<String>>(list);
        }
        private static void DeleteUri(List<String> list)
        {
            list.RemoveAt(0);
        }
        public static void saveUri(List<String> list, String path)
        {
            if (!CheckCount(list))
            {
                DeleteUri(list);
            }
            AddUri(list, path);
        }
    }
}

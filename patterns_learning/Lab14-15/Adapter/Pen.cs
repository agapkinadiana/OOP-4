using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Adapter
{
    class Pen : IPen
    {
        public string Write()
        {
            return "Ручкой пишет";
        }
    }
}

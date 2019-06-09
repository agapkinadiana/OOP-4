using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Adapter
{
    class Student
    {
        public string Stuff(IPen stuff)
        {
            return stuff.Write();
        }
    }
}

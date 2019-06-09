using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.State
{
    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }
}

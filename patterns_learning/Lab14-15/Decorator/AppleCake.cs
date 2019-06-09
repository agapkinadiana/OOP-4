using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    class AppleCake : Cake
    {
        public AppleCake() : base("Яблочный пирог")
        { }
        public override int GetCost()
        {
            return 6;
        }
    }
}

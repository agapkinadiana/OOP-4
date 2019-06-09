using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Composite
{
    class Item : Component
    {
        public Item(string name)
                : base(name)
        { }

        public override string Print()
        {
            return name;
        }

        public override string GetName()
        {
            return name;
        }

    }
}

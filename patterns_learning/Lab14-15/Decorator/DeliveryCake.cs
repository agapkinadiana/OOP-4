using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    class DeliveryCake : CakeDecorator
    {
        public DeliveryCake(Cake p)
            : base(p.Name + ", с доставкой", p)
        { }

        public override int GetCost()
        {
            return Cake.GetCost() + 5;
        }
    }
}

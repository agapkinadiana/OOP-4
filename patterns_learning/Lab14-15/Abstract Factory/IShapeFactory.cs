using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Abstract_Factory
{
    public interface IShapeFactory
    {
        Rect createRect();
        Circle createCircle();
    }
}

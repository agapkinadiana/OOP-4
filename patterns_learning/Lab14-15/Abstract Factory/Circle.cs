using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab14_15.Abstract_Factory
{
    public class Circle
    {
       public int Radius { get; set; }
       public string Color { get; set; }
        public override string ToString()
        {
            return $"Создан круг\nцвет: {Color}, радиус: {Radius}";
        }
    }
}

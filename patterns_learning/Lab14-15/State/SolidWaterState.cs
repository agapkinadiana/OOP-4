using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.State
{
    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("Превращаем лед в жидкость");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            MessageBox.Show("Продолжаем заморозку льда");
        }
    }
}

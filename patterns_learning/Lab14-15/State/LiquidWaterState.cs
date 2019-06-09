using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.State
{
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("Превращаем жидкость в пар");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            MessageBox.Show("Превращаем жидкость в лед");
            water.State = new SolidWaterState();
        }
    }
}

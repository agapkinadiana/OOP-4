using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.State
{
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("Повышаем температуру водяного пара");
        }

        public void Frost(Water water)
        {
            MessageBox.Show("Превращаем водяной пар в жидкость");
            water.State = new LiquidWaterState();
        }
    }
}

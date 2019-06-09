using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.Command
{
    public class ClimbCommand : ICommand
    {
        public void Execute()
        {
            Climb();
        }

        private void Climb()
        {
            MessageBox.Show("Подниматься!");
        }

    }
}

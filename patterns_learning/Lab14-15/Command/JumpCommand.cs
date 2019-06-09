using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.Command
{
    public class JumpCommand : ICommand
    {
        public void Execute()
        {
            Jump();
        }

        private void Jump()
        {
            MessageBox.Show("Прыжок!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab14_15.Command
{
    public class FireCommand : ICommand
    {
        public void Execute()
        {
            Fire();
        }

        private void Fire()
        {
            MessageBox.Show("Огонь!");
        }
    }
}

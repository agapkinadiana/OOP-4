using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Adapter
{
    class ChalkToPenAdapter : IPen
    {
        Chalk chalk;
        public ChalkToPenAdapter(Chalk c)
        {
            chalk = c;
        }

        public string Write()
        {
            return chalk.Draw();
        }
    }
}

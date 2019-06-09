using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Memento
{
    public class PersonState
    {
        public string name { get; }
        public int age { get; }

        public PersonState(string Name, int Age)
        {
            name = Name;
            age = Age;
        }
    }
}

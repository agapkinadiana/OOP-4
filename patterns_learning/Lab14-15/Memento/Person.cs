using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Memento
{
    public class Person
    {
        public string _name = "Jokar";
        public int _age = 5;

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public PersonState GetState()
        {
            var person = new PersonState(_name, _age);
            return person;
        }

        public void SetState(PersonState state)
        {
            _name = state.name;
            _age = state.age;
        }
    }
}

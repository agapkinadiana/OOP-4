using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Lector
    {
        private int id;

        private string nameOfLector, lectrum;
        private int auditorium;

        public Lector() { }

        public Lector(int id, string nameOfLector, string lectrum, int auditorium)
        {
            this.id = id;

            this.nameOfLector = nameOfLector;
            this.lectrum = lectrum;

            this.auditorium = auditorium;
        }

        public int Id { get => id; }

        public string NameOfLector { get => nameOfLector; set => nameOfLector = value; }
        public string Lectrum { get => lectrum; set => lectrum = value; }

        public int Auditorium { get => auditorium; set => auditorium = value; }
    }
}

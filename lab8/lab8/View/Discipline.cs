using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.View
{
    class Discipline
    {
        private string name, speciality, testing;
        private int id, course, semester, amountOfStudents;

        public Discipline() { }

        public Discipline(int id, string name, string speciality, string testing,
            int course, int semester, int amountOfStudents)
        {
            this.id = id;

            this.name = name;
            this.speciality = speciality;
            this.testing = testing;

            this.course = course;
            this.semester = semester;
            this.amountOfStudents = amountOfStudents;
        }

        public string Name { get => name; set => name = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public string Testing { get => testing; set => testing = value; }

        public int Id { get => id; }
        public int Course { get => course; set => course = value; }
        public int Semester { get => semester; set => semester = value; }
        public int AmountOfStudents { get => amountOfStudents; set => amountOfStudents = value; }
    }
}

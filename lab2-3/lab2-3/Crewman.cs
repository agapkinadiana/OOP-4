using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab2_3
{
    [Serializable]
    public class Crewman
    {
        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-я]+\s?([A-Za-zА-Яа-я].)?", ErrorMessage = "Incorrect first name")]  //+ - хоть 1; ? - 0 или 1
        public string NameFirst;
        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-я]+\s?([A-Za-zА-Яа-я].)?", ErrorMessage = "Incorrect first name")]
        public string NameSecond;
        [Required(ErrorMessage ="Incorrect experience")]
        public int Experience;
        [Required(ErrorMessage = "Incorrect date of birth")]
        public string DateOfBirth;
        [Required(ErrorMessage = "Choose sex")]
        public string Sex;
        [Required(ErrorMessage = "Choose position")]
        public string Position;

        public static string[] listOfPositions = { "pilot","second pilot", "steward", "engineer" };

        public Crewman() { }

        public Crewman (string name_first, string name_second, int experience, string date_of_birth, string sex, string position)
        {
            NameFirst = name_first;
            NameSecond = name_second;
            Experience = experience;
            DateOfBirth = date_of_birth;
            Sex = sex;
            Position = position;
        }

        public override string ToString()
        {
            return NameFirst + " " + NameSecond + ", " + Sex + ", " + 
                DateOfBirth + ", " + Position + ", " + Experience + " years of experience.";
        }
    }
}

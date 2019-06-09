using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    public class Producer
    {
        public string CompanyName;
        public string Country;
        public int YearOfFoundation;
        public List<string> types;

        public Producer() { }

        public Producer(string company_name, string country, int year_of_foundation, List<string> list)
        {
            CompanyName = company_name;
            Country = country;
            YearOfFoundation = year_of_foundation;
            types = list;
        }

        public override string ToString()
        {
            return CompanyName;
        }

        public string ShowAllInf()
        {
            string type = "";
            foreach (string s in types)
            {
                if (type.Equals(""))
                    type += s;
                else type += "/" + s;
            }
            return CompanyName + ", " + Country + ", " + YearOfFoundation +
                " - year of foundation, types: " + type;
        }
    }
}

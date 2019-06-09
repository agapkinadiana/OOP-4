using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    [Serializable]
    public class Airplane
    {
        public string ID;
        public string Type;
        public int CountOfSpaces;
        public string DateOfConstruction;
        public int Capacity;
        public Producer Model;
        public List<Crewman> listOfCrewman;
        public string Captain = "";
        public string SecondPilot = "";

        public static string[] types = { "passenger", "military", "cargo" };

        public Airplane() { }

        public Airplane (string id, string type, int count_of_spaces, string date_of_construction, int capacity, List<Crewman> list, Producer model)
        {
            ID = id;
            Type = type;
            CountOfSpaces = count_of_spaces;
            DateOfConstruction = date_of_construction;
            Capacity = capacity;
            listOfCrewman = list;
            Model = model;

            foreach (Crewman crewman in listOfCrewman)
            {
                if (crewman.Position.Equals("pilot"))
                    Captain = crewman.NameSecond;

                if (crewman.Position.Equals("second pilot"))
                    SecondPilot = crewman.NameSecond;
            }

            if (Captain.Equals(""))
                throw new Exception("Airplane must have a pilot!");
        }

        public override string ToString()
        {
            return ID + ", " + Type + ", " + Model + ", " + Captain + ", " + CountOfSpaces + " spaces, " +
                DateOfConstruction + " - date of construction, capacity: " + Capacity + ", pilot: " + Captain;
        }
    }
}

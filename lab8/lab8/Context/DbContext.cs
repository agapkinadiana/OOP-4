using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab8.View;


namespace lab8
{
    class DbDataContext
    {
        private static ObservableCollection<Discipline> disciplines = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> Disciplines
        {
            get => disciplines;
            set => disciplines = value;
        }

        private static ObservableCollection<Lector> lectors = new ObservableCollection<Lector>();
        public ObservableCollection<Lector> Lectors
        {
            get => lectors;
            set => lectors = value;
        }

        public static void ClearCollections()
        {
            disciplines.Clear();
            lectors.Clear();
        }
    }
}

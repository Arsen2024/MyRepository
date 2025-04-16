using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3 {
    public class CityComparer: IComparer<City> {
        public int Compare(City x, City y) {
            // Спочатку за площею, потім за населенням
            int areaCompare = x.Area.CompareTo(y.Area);
            if (areaCompare == 0)
                return x.Population.CompareTo(y.Population);
            return areaCompare;
        }
    }
}

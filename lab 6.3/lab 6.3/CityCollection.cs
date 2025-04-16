using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3 {
    public class CityCollection: IEnumerable<City> {
        private List<City> cities = new List<City>();

        public void Add(City city) {
            cities.Add(city);
        }

        public IEnumerator<City> GetEnumerator() {
            return cities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void SortByPopulation() {
            cities.Sort((x, y) => x.Population.CompareTo(y.Population));
        }
    }
}

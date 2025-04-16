using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3 {
    public class City: IComparable<City> {
        public string Name { get; set; }
        public double Area { get; set; } // площа
        public int Population { get; set; } // населення

        public City(string name, double area, int population) {
            Name = name;
            Area = area;
            Population = population;
        }

        public int CompareTo(City other) {
            // Порівняння за площею
            return this.Area.CompareTo(other.Area);
        }

        public override string ToString() {
            return $"{Name} | Area: {Area} km² | Population: {Population}";
        }
    }
}

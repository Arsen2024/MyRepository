using lab_6._3;

class Program { 

    static void Main() {

        CityCollection cityCollection = new CityCollection();
        cityCollection.Add(new City("Kyiv", 839, 2884000));
        cityCollection.Add(new City("Lviv", 182, 721000));
        cityCollection.Add(new City("Odesa", 236.9, 1011000));
        cityCollection.Add(new City("Dnipro", 405, 981000));
        cityCollection.Add(new City("Kharkiv", 350, 1441000));

        Console.WriteLine(" Cities sorted by Area (IComparable):");
        List<City> citiesByArea = new List<City>(cityCollection);
        citiesByArea.Sort();
        foreach (var city in citiesByArea) {
            Console.WriteLine(city);
        }

        Console.WriteLine("\n Cities sorted by Area and then Population (IComparer):");
        List<City> citiesByAreaAndPopulation = new List<City>(cityCollection);
        citiesByAreaAndPopulation.Sort(new CityComparer());
        foreach (var city in citiesByAreaAndPopulation) {
            Console.WriteLine(city);
        }

        Console.WriteLine("\n Cities sorted by Population (IEnumerable):");
        cityCollection.SortByPopulation();
        foreach (var city in cityCollection) {
            Console.WriteLine(city);
        }

    }

}
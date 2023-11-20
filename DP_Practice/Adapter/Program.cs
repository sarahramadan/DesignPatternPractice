using Adapter.ClassAdapter;
//using Adapter.ObjectAdapter;


ICityAdapter cityAdapter = new CityAdapter();
City city = cityAdapter.GetCity();
Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey();

namespace Adapter.ObjectAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }
    public class City
    {
        public string FullName { get; set; }
        public long Inhabitants { get; set; }
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }
    /// <summary>
    /// Adaptee
    /// </summary>
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Alexandria", "alex", 6000000);
        }
    }
    /// <summary>
    /// Target 
    /// </summary>
    public interface ICityAdapter
    {
        public City GetCity();
    }
    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; private set; } = new();
        public City GetCity()
        {
            var cityInfo = ExternalSystem.GetCity();
            return new City($"{cityInfo.Name} - {cityInfo.NickName}", cityInfo.Inhabitants);
        }
    }
}

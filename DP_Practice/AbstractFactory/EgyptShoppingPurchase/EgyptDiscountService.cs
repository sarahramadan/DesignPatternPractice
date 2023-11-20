namespace AbstractFactory
{
    public class EgyptDiscountService : IDiscountService
    {
        public int DiscountPercentage
        {
            get
            {
                return 15;
            }
        }
    }
}

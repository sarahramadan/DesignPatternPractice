namespace AbstractFactory
{
    public class OtherDiscountService : IDiscountService
    {
        public int DiscountPercentage
        {
            get
            {
                return 10;
            }
        }
    }
}

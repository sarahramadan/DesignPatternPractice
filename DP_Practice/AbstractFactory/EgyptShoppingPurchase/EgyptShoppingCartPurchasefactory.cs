namespace AbstractFactory
{
    public class EgyptShoppingCartPurchasefactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountSerive()
        {
            return new EgyptDiscountService();
        }

        public IShippingService CreateShippingService()
        {
            return new EgyptShippingService();
        }
    }
}

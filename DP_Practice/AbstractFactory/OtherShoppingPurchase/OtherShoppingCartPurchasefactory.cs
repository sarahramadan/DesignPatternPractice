namespace AbstractFactory
{
    public class OtherShoppingCartPurchasefactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountSerive()
        {
            return new OtherDiscountService();
        }

        public IShippingService CreateShippingService()
        {
            return new OtherShippingService();
        }
    }
}

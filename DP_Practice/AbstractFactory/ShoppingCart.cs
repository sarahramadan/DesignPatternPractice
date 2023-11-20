namespace AbstractFactory
{
    public class ShoppingCart
    {
        private readonly IShippingService _shippingService;
        private readonly IDiscountService _discountService;

        private readonly int _orderCost = 100;
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _shippingService = factory.CreateShippingService();
            _discountService = factory.CreateDiscountSerive();
        }
        public void CalulateCartCost()
        {
            Console.WriteLine($"Total costs = {_orderCost - (_orderCost / 100 * _discountService.DiscountPercentage) + _shippingService.ShippingCost}");
        }
    }
}

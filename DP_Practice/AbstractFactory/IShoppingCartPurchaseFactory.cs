/// <summary>
/// Summary description for Class1
/// </summary>
namespace AbstractFactory
{
    public interface IShoppingCartPurchaseFactory
    {
        IShippingService CreateShippingService();
        IDiscountService CreateDiscountSerive();
    }
}

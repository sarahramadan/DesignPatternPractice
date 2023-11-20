using AbstractFactory;

Console.Title = "Abstract Factory";

var egyptShoppingFactory = new EgyptShoppingCartPurchasefactory();
var shoppingCart = new ShoppingCart(egyptShoppingFactory);
shoppingCart.CalulateCartCost();


var otherShoppingFactory = new OtherShoppingCartPurchasefactory();
var otherShoppingCart = new ShoppingCart(otherShoppingFactory);
otherShoppingCart.CalulateCartCost();

Console.ReadKey();
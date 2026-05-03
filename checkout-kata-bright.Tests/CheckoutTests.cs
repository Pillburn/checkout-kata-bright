using CheckoutKata;
using PricingRules;
using Xunit;
public class CheckoutTests
{
    [Fact]
    public void GetBasketTotal_ReturnZero_WhenEmpty()
    {
       var rules = new PricingRulesRepo();
        //Arrange
       ICheckout checkout = new Checkout(rules);
        //No Act Needed 
        //Assert Basket is 0
        Assert.Equal(0, checkout.GetTotalPrice());
    }
    [Fact]
    public static void ScanItem_ReturnCorrectPrice()
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku = "A", price = 50});

        ICheckout checkout = new Checkout(rules);

        checkout.Scan("A");
        double total = checkout.GetTotalPrice();

        Assert.Equal(50, total);
    }

    [Theory]
    [InlineData("A", 50)]
    [InlineData("B", 30)]
    [InlineData("C", 20)]
    [InlineData("D", 15)]
        public void ScanMultipleItems_ReturnCorrectPrice(string sku, double price)
    {
         var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku = sku, price = price});
        ICheckout checkout = new Checkout(rules);

        checkout.Scan(sku);
        double total = checkout.GetTotalPrice();
        Assert.Equal(price,total);
    }
}

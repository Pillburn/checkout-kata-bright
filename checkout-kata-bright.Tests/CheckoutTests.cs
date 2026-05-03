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

    [Fact]
    public void ScanMultipleItems_ReturnCorrectPrice()
    {
         var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku = "A", price = 50});
        rules.AddRule(new PricingRule{Sku = "B", price = 30});
        ICheckout checkout = new Checkout(rules);

        checkout.Scan("A");
        checkout.Scan("B");
        double total = checkout.GetTotalPrice();
        Assert.Equal(80,total);
    }
}

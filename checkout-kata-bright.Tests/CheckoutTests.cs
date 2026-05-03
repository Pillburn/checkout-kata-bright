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
    [Theory]
    [InlineData("A")]
    public void ScanItem_ReturnCorrectPrice(string SKU)
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku = "A", price = 50});

        ICheckout checkout = new Checkout(rules);

        checkout.Scan(SKU);
        double total = checkout.GetTotalPrice();

        Assert.Equal(50, total);
    }
}

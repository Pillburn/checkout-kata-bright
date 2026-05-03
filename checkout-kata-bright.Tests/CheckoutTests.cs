using System.Reflection.Metadata;
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

    [Fact]
     public static void ScanMultipleItems_ReturnCorrectTotalPrice()
    {

        IPricingRulesRepo rules = new PricingRulesRepo(); 
        rules.AddRule(new PricingRule{Sku = "A", price = 50});
        rules.AddRule(new PricingRule{Sku = "B", price = 30});
        rules.AddRule(new PricingRule{Sku = "C", price = 20});
        rules.AddRule(new PricingRule{Sku = "D", price = 15 });

        ICheckout checkout = new Checkout(rules);

        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        checkout.Scan("D");
        double total = checkout.GetTotalPrice();

        Assert.Equal(115, total);
    }
    [Fact]
    public void ThreeAs_CostCorrect_WithSpecialOffer()
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku="A" ,price=50, SpecialAmount = 3, SpecialPrice = 130});

        ICheckout checkout = new Checkout(rules);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        Assert.Equal(130, checkout.GetTotalPrice()); 
    }

    [Fact]
    public void TwoBs_CostCorrect_WithSpecialOffer()
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{ Sku="B", price = 30, SpecialAmount = 2, SpecialPrice = 45 });
        ICheckout checkout = new Checkout(rules);
        checkout.Scan("B");
        checkout.Scan("B");

        Assert.Equal(45,checkout.GetTotalPrice());
    }

    [Fact]
    public void MultipleAs_CostCorrect_WithSpecialOffer()
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku="A" ,price=50, SpecialAmount = 3, SpecialPrice = 130});

        ICheckout checkout = new Checkout(rules);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        Assert.Equal(390, checkout.GetTotalPrice()); 
    }

    [Fact]

    public void MixedDeal_CostCorrect_WithSpecialOffers()
    {
        var rules = new PricingRulesRepo();
        rules.AddRule(new PricingRule{Sku="A" ,price=50, SpecialAmount = 3, SpecialPrice = 130});
        rules.AddRule(new PricingRule{ Sku="B", price = 30, SpecialAmount = 2, SpecialPrice = 45 });
        ICheckout checkout = new Checkout(rules);
        checkout.Scan("B");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        Assert.Equal(175, checkout.GetTotalPrice());
    }
    [Fact]
    public void Scan_NullItem_ThrowsArgumentNullException()
    {
        var checkout = new Checkout(new PricingRulesRepo());
        Assert.Throws<ArgumentNullException>(() => checkout.Scan(null));
    }

    [Fact]
    public void Scan_EmptyString_ThrowsArgumentException()
    {
        var checkout = new Checkout(new PricingRulesRepo());
        Assert.Throws<ArgumentException>(() => checkout.Scan(""));
    }

    [Fact]
    public static void ScanItem_UnknownID()
    {
        var checkout = new Checkout(new PricingRulesRepo());
        Assert.Throws<ArgumentException>(() => checkout.Scan(""));
    }
}

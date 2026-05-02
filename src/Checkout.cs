using PricingRules;
namespace CheckoutKata;
public class Checkout: ICheckout
{
    public string SKU { get; set; } //A - Z if and when items get past this marker, we can start adding a num id as well e.g. a1, b1 etc 
    public double basketTotal {get; set;} 
    private readonly PricingRulesRepo _pricingRules;

    public Checkout(PricingRulesRepo pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void Scan(string itemID)
    {
        
    }
    public double GetTotalPrice()
    {
        return basketTotal;
    }
}

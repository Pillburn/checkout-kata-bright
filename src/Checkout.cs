using PricingRules;
namespace CheckoutKata;
public class Checkout: ICheckout
{
    private readonly PricingRulesRepo _pricingRules;
    private readonly List<string> _scannedItems = new();

    public Checkout(PricingRulesRepo pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void Scan(string itemID)
    {
        _scannedItems.Add(itemID);
    }
    public double GetTotalPrice()
    {
        int basketTotal = 0;
        foreach (var sku in _scannedItems)
        {
            var rule = _pricingRules.GetRule(sku);
        }
        return basketTotal;
    }
}

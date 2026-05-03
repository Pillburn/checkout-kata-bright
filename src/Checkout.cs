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

    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }
    public double GetTotalPrice()
    {
        double basketTotal = 0;
        foreach (var sku in _scannedItems)
        {
            var rule = _pricingRules.GetRule(sku);
            if (rule != null)
            {
                basketTotal += rule.price;
            }

        }
        return basketTotal;
    }
}

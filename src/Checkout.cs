using System.Threading.Tasks.Dataflow;
namespace CheckoutKata;
public class Checkout: ICheckout
{
    private readonly IPricingRulesRepo _pricingRules;
    private readonly List<string> _scannedItems = new();

    public Checkout(IPricingRulesRepo pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void Scan(string item)
    {
        if (item == null)
        throw new ArgumentNullException(nameof(item));
    
        if (string.IsNullOrWhiteSpace(item))
        throw new ArgumentException("Item cannot be empty or whitespace.", nameof(item));

        if (_pricingRules.GetRule(item) == null)
        throw new ArgumentException($"SKU '{item}' is not recognised.", nameof(item));

        _scannedItems.Add(item);
    }
    public double GetTotalPrice()
    {
        
        double basketTotal = 0;

        var groups = _scannedItems.GroupBy(sku => sku);

        foreach (var group in groups)
        {
            string sku = group.Key;
            int count = group.Count();
            var rule = _pricingRules.GetRule(sku);
            if (rule.SpecialAmount != null && rule.SpecialPrice != null)
            {
                int batches = (int)(count / rule.SpecialAmount.Value);
                int remainder = (int) (count % rule.SpecialAmount.Value);

                basketTotal += (double)(batches * rule.SpecialPrice.Value); 
                basketTotal += remainder * rule.price;
            }
            else
            {
                basketTotal += count * rule.price;
            }
        }
        return basketTotal;
    }
}

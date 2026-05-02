namespace PricingRules;

public class PricingRule
{
    public required string Sku { get ; set; }

    public double price { get ; set; }
}
public class PricingRulesRepo
{
    private readonly List<PricingRule> _rules = new();

    public void AddRule(PricingRule rule)
    {
        _rules.Add(rule);
    }

    public PricingRule? GetRule(string SKU)
    {
        return _rules.FirstOrDefault(r => r.Sku == SKU);
    }

}


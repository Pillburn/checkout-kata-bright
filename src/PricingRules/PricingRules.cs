namespace PricingRules;

public class PricingRule
{
    public required string Sku { get ; set; }
    public required double price { get ; set; }
    public string? SpecialDealSku { get ; set; }
    public double? SpecialPrice {get; set;} //both nullable as not every item has a Deal

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


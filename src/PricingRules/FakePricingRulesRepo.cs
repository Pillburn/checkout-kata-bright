using System;
using PricingRules;
using CheckoutKata;

public class FakePricingRulesRepo: IPricingRulesRepo
{
    private readonly Dictionary<string, PricingRule> _rules = new();

    public void AddRule(PricingRule rule)
    {
        _rules[rule.Sku] = rule;
    }

    public PricingRule? GetRule(string sku)
    {
        return _rules.TryGetValue(sku, out var rule) ? rule : null;
    }
}
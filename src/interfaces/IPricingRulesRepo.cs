using System;
using PricingRules;
using CheckoutKata;

public interface IPricingRulesRepo
{
    void AddRule(PricingRule rule);
    PricingRule? GetRule(string sku);
}
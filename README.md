# Checkout Kata
Implementation of a supermarket checkout with multi-buy pricing offers, 
built in C# / .NET 9 using test-driven development.

## Getting started
dotnet restore
dotnet test

## Design decisions
- **TDD** — tests written first, committed incrementally
- **Interface-driven** — `ICheckout` and `IPricingRulesRepo` allow 
  swapping pricing sources without changing the checkout logic
- **Fail-fast validation** — invalid or missing SKUs throw immediately 
  in `Scan`, not silently at checkout
- **GroupBy** used for offer calculation — scan order doesn't matter

## What I'd do next
- `decimal` instead of `double` for prices
- Pricing rules loaded from a configuration file or database
- Thread-safety if the checkout were shared across concurrent scans

using System;
using CheckoutKata;

public interface ICheckout
{
    void Scan(string item);
    double GetTotalPrice();
}
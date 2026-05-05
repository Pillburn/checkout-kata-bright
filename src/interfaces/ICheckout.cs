using System;
using CheckoutKata;

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}
namespace CheckoutKata;

public class Checkout: ICheckout
{
    public string SKU { get; set; } //A - Z if and when items get past this marker, we can start adding a num id as well e.g. a1, b1 etc 
    public double price { get; set; }
    public double basketTotal {get; set;} 

    public Checkout()
    {
        basketTotal = 0;
    }

    public void Scan(string itemID)
    {
        
    }
    public double GetTotalPrice()
    {
        return basketTotal;
    }
}

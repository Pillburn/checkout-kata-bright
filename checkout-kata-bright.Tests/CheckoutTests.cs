using CheckoutKata;
using Xunit;
public class CheckoutTests
{
    [Fact]
    public void GetBasketTotal_ReturnZero_WhenEmpty()
    {
        //Arrange
       ICheckout checkout = new Checkout();
        //No Act Needed 
        //Assert Basket is 0
        Assert.Equal(0, checkout.GetTotalPrice());
    }
}

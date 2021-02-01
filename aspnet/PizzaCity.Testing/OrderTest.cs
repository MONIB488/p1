using PizzaCity.Domain.Models;
using Xunit;


namespace PizzaCity.Testing
{
    public class OrderTests
    {
        [Fact]
        private void OrderExists()
        {
            //arrange
            var order = new Order();

            //act
            var actual = order;

            //assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }
    }

}

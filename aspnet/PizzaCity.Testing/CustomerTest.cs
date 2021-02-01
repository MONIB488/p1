using PizzaCity.Domain.Models;
using Xunit;

namespace PizzaCity.Testing
{
    public class UserTests
    {
        [Fact]
        private void CustomerExists()
        {
            //arrange
            var cust = new Customer();

            //act
            var actual = cust;
            cust.Name = "Test";

            //assert
            Assert.IsType<Customer>(actual);
            Assert.NotNull(actual);
            Assert.True(actual.Name == "Test");
        }
    }
}
  
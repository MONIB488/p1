using PizzaCity.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void PizzaExists()
        {
            //arrange
            var pizza = new Pizza();

            //act
            var actual = pizza;

            //assert
            Assert.IsType<Pizza>(actual);
            Assert.NotNull(actual);
        }
    }
}
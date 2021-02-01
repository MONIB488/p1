using PizzaCity.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class StoreTests
    {
        [Fact]
        private void StoreExists()
        {
            //arrange
            var store = new Store();

            //act
            var actual = store;

            //assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
    }

}
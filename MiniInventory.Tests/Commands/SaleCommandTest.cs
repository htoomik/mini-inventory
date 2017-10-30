using MiniInventory.App;
using MiniInventory.App.Commands;
using Moq;
using Xunit;

namespace MiniInventory.Tests.Commands
{
    public class SaleCommandTest
    {
        [Fact]
        public void Expect_Sale()
        {
            const int count = 22;
            var inventory = new Mock<IInventory>();

            var result = new SaleCommand(count).Execute(inventory.Object);

            inventory.Verify(i => i.Sale(count));
        }


        [Fact]
        public void Expect_ResultIsNull()
        {
            const int count = 22;
            var inventory = new Mock<IInventory>();

            var result = new SaleCommand(count).Execute(inventory.Object);

            Assert.Null(result);
        }
    }
}
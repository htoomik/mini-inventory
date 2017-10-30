using MiniInventory.App;
using MiniInventory.App.Commands;
using Moq;
using Xunit;

namespace MiniInventory.Tests.Commands
{
    public class DeliveryCommandTest
    {
        [Fact]
        public void Expect_Delivery()
        {
            const int count = 22;
            var inventory = new Mock<IInventory>();

            var result = new DeliveryCommand(count).Execute(inventory.Object);

            inventory.Verify(i => i.Delivery(count));
        }


        [Fact]
        public void Expect_ResultIsNull()
        {
            const int count = 22;
            var inventory = new Mock<IInventory>();

            var result = new DeliveryCommand(count).Execute(inventory.Object);

            Assert.Null(result);
        }
    }
}
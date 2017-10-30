using MiniInventory.App;
using MiniInventory.App.Commands;
using Moq;
using Xunit;

namespace MiniInventory.Tests.Commands
{
    public class CountCommandTest
    {
        [Fact]
        public void Expect_GetsAndReturnsCount()
        {
            const int count = 22;
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.Count()).Returns(count);

            var result = new CountCommand().Execute(inventory.Object);

            Assert.Equal(count.ToString(), result);
        }
    }
}
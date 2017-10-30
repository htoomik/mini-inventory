using MiniInventory.App;
using MiniInventory.App.Commands;
using Moq;
using Xunit;

namespace MiniInventory.Tests.Commands
{
    public class NoOpCommandTest
    {
        [Fact]
        public void Expect_DoesNothing()
        {
            // it's hard to test a negative - let's just be happy as long as it doesn't error
            var inventory = new Mock<IInventory>();

            new NoOpCommand().Execute(inventory.Object);
        }


        [Fact]
        public void Expect_ResultIsNull()
        {
            var inventory = new Mock<IInventory>();

            var result = new NoOpCommand().Execute(inventory.Object);

            Assert.Null(result);
        }
    }
}
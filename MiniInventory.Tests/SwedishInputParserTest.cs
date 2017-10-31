using MiniInventory.App;
using MiniInventory.App.Commands;
using Xunit;

namespace MiniInventory.Tests
{
    public class SwedishInputParserTest
    {
        [Fact]
        public void When_EmptyString_Expect_NoOpCommand()
        {
            var result = new SwedishInputParser().Parse("");

            Assert.IsType(typeof(NoOpCommand), result);
            Assert.Equal(0, result.Argument);
        }


        [Fact]
        public void When_I_WithInteger_Expect_DeliveryCommand()
        {
            var result = new SwedishInputParser().Parse("I1");

            Assert.IsType(typeof(DeliveryCommand), result);
            Assert.Equal(1, result.Argument);
        }


        [Fact]
        public void When_S_WithInteger_Expect_SaleCommand()
        {
            var result = new SwedishInputParser().Parse("S1");

            Assert.IsType(typeof(SaleCommand), result);
            Assert.Equal(1, result.Argument);
        }


        [Fact]
        public void When_L_Expect_CountCommand()
        {
            var result = new SwedishInputParser().Parse("L");

            Assert.IsType(typeof(CountCommand), result);
            Assert.Equal(0, result.Argument);
        }
    }
}
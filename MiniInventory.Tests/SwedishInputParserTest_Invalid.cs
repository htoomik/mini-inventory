using MiniInventory.App;
using Xunit;

namespace MiniInventory.Tests
{
    public class SwedishInputParserTest_Invalid
    {
        [Fact]
        public void UnrecognizedCommandLetter()
        {
            AssertThrows("X");
        }


        [Fact]
        public void TooManyLetters()
        {
            AssertThrows("SS2");
        }


        [Fact]
        public void CountCommand_WithUnexpectedNumber()
        {
            AssertThrows("L2");
        }


        [Fact]
        public void SaleCommand_WithNoNumber()
        {
            AssertThrows("S");
        }


        [Fact]
        public void DeliveryCommand_WithNoNumber()
        {
            AssertThrows("I");
        }


        [Fact]
        public void SaleCommand_WithNonIntegerNumber_Period()
        {
            AssertThrows("S1.2");
        }


        [Fact]
        public void SaleCommand_WithNonIntegerNumber_Comma()
        {
            AssertThrows("S1,2");
        }


        [Fact]
        public void DeliveryCommand_WithNonIntegerNumber_Period()
        {
            AssertThrows("I1.2");
        }


        [Fact]
        public void DeliveryCommand_WithNonIntegerNumber_Comma()
        {
            AssertThrows("I1,2");
        }

        
        [Fact]
        public void SaleCommand_WithOtherCharactersAfterNumber()
        {
            AssertThrows("S1S");
        }
        

        [Fact]
        public void DeliveryCommand_WithOtherCharactersAfterNumber()
        {
            AssertThrows("I1I");
        }        


        [Fact]
        public void TotallyRandomCombination()
        {
            AssertThrows("SIL123");
        }


        [Fact]
        public void TooLargeNumber()
        {
            AssertThrows("S9999999999");
        }


        private static void AssertThrows(string commandString)
        {
            Assert.Throws<InvalidCommandException>(() => new SwedishInputParser().Parse(commandString));
        }
    }
}
using MiniInventory.App;
using MiniInventory.App.Commands;
using Moq;
using Xunit;

namespace MiniInventory.Tests
{
    public class ProcessorTest
    {
        [Fact]
        public void Expect_Processes_UntilLineIsEmpty()
        {
            const string inputLine = "a line";

            var console = new Mock<IConsoleWrapper>();
            var parser = new Mock<IParser>();
            var inventory = new Mock<IInventory>();

            console.SetupSequence(c => c.ReadLine())
                .Returns(inputLine)
                .Returns("");

            parser.Setup(p => p.Parse(inputLine)).Returns(new NoOpCommand());

            var processor = new Processor(console.Object, parser.Object, inventory.Object);
            processor.Process();

            console.VerifyAll();
            parser.VerifyAll();
        }


        [Fact]
        public void When_CommandHasOutput_Expect_WritesOutputToConsole()
        {
            const string outputLine = "output line";
            
            var console = new Mock<IConsoleWrapper>();
            var parser = new Mock<IParser>();
            var inventory = new Mock<IInventory>();
            var commandWithOutput = new Mock<ICommand>();

            console.SetupSequence(c => c.ReadLine())
                .Returns("a line")
                .Returns("");
            console.Setup(c => c.WriteLine(outputLine));

            commandWithOutput.Setup(c => c.Execute(It.IsAny<IInventory>())).Returns(outputLine);

            parser.Setup(p => p.Parse(It.IsAny<string>())).Returns(commandWithOutput.Object);

            var processor = new Processor(console.Object, parser.Object, inventory.Object);
            processor.Process();

            console.VerifyAll();
        }


        [Fact]
        public void When_CommandThrowsException_Expect_WritesFeedback()
        {
            var console = new Mock<IConsoleWrapper>();
            var parser = new Mock<IParser>();
            var inventory = new Mock<IInventory>();
            var command = new Mock<ICommand>();

            console.SetupSequence(c => c.ReadLine())
                .Returns("a line")
                .Returns("");
            console.Setup(c => c.WriteLine(It.IsAny<string>()));

            command.Setup(c => c.Execute(It.IsAny<IInventory>())).Throws(new NotEnoughStockException());

            parser.Setup(p => p.Parse(It.IsAny<string>())).Returns(command.Object);

            var processor = new Processor(console.Object, parser.Object, inventory.Object);
            processor.Process();

            console.VerifyAll();
        }


        [Fact]
        public void When_ParserThrowsException_Expect_WritesFeedback()
        {
            var console = new Mock<IConsoleWrapper>();
            var parser = new Mock<IParser>();
            var inventory = new Mock<IInventory>();

            console.SetupSequence(c => c.ReadLine())
                .Returns("a line")
                .Returns("");
            console.Setup(c => c.WriteLine(It.IsAny<string>()));

            parser.Setup(p => p.Parse(It.IsAny<string>())).Throws(new InvalidCommandException());

            var processor = new Processor(console.Object, parser.Object, inventory.Object);
            processor.Process();

            console.VerifyAll();
        }
    }
}
namespace MiniInventory.App
{
    public class Processor
    {
        private readonly IConsoleWrapper consoleWrapper;
        private readonly IParser parser;
        private readonly IInventory inventory;


        public Processor(IConsoleWrapper consoleWrapper, IParser parser, IInventory inventory)
        {
            this.consoleWrapper = consoleWrapper;
            this.parser = parser;
            this.inventory = inventory;
        }


        public void Process()
        {
            var commandString = consoleWrapper.ReadLine();
            while (!string.IsNullOrEmpty(commandString))
            {
                var result = Process(commandString);
                if (!string.IsNullOrEmpty(result))
                    consoleWrapper.WriteLine(result);
                commandString = consoleWrapper.ReadLine();
            }
        }


        private string Process(string commandString)
        {
            var command = parser.Parse(commandString);
            return command.Execute(inventory);
        }
    }
}
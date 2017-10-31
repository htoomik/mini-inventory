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
            ICommand command;

            try
            {
                command = parser.Parse(commandString);
            }
            catch (InvalidCommandException ex)
            {
                return ex.GetUserMessage() + "\r\n" + Texts.Instructions;
            }
            
            string result;
            try
            {
                result = command.Execute(inventory);
            }
            catch (NotEnoughStockException ex)
            {
                return ex.GetUserMessage();
            }
            return result;
        }
    }
}
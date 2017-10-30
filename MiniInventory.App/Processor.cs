namespace MiniInventory.App
{
    public class Processor
    {
        private readonly IParser parser;
        private readonly IInventory inventory;


        public Processor(IParser parser, IInventory inventory)
        {
            this.parser = parser;
            this.inventory = inventory;
        }


        public string Process(string commandString)
        {
            var command = parser.Parse(commandString);
            return command.Execute(inventory);
        }
    }
}
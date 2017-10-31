namespace MiniInventory.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new SwedishInputParser();
            var inventory = new Inventory();
            var consoleWrapper = new ConsoleWrapper();

            WriteWelcomeMessage(consoleWrapper);

            var processor = new Processor(consoleWrapper, parser, inventory);
            processor.Process();
        }


        private static void WriteWelcomeMessage(ConsoleWrapper consoleWrapper)
        {
            consoleWrapper.WriteLine(Texts.Welcome);
            consoleWrapper.WriteLine(Texts.Instructions);
        }
    }
}

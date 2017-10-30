using System;

namespace MiniInventory.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new SwedishInputParser();
            var inventory = new Inventory();
            var consoleWrapper = new ConsoleWrapper();

            var processor = new Processor(consoleWrapper, parser, inventory);
            processor.Process();
        }
    }
}

using System;

namespace MiniInventory.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new SwedishInputParser();
            var inventory = new Inventory();
            var processor = new Processor(parser, inventory);

            var commandString = Console.ReadLine();
            while(!string.IsNullOrEmpty(commandString))
            {
                var result = processor.Process(commandString);
                if (!string.IsNullOrEmpty(result))
                    Console.WriteLine(result);
                commandString = Console.ReadLine();
            }
        }
    }
}

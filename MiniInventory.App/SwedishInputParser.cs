using MiniInventory.App.Commands;

namespace MiniInventory.App
{
    public class SwedishInputParser : IParser
    {
        public ICommand Parse(string command)
        {
            if (string.IsNullOrEmpty(command))
                return new NoOpCommand();

            var firstLetter = command.Substring(0, 1);
            var number = 0;
            if (command.Length > 1)
                int.TryParse(command.Substring(1), out number);

            switch (firstLetter)
            {
                case "I": return new DeliveryCommand(number);
                case "S": return new SaleCommand(number);
                case "L": return new CountCommand();
                default: return null;
            }
        }
    }
}
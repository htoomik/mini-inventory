using System.Text.RegularExpressions;
using MiniInventory.App.Commands;

namespace MiniInventory.App
{
    public class SwedishInputParser : IParser
    {
		private static readonly Regex validCommand = new Regex("^[A-Z]{1}[0-9]*$");

        public ICommand Parse(string commandString)
		{
			commandString = commandString.Trim().ToUpper();

            if (string.IsNullOrEmpty(commandString))
                return new NoOpCommand();

			if (!validCommand.IsMatch(commandString))
				throw new InvalidCommandException();

            var firstLetter = commandString.Substring(0, 1);
			var hasNumber = commandString.Length > 1;
            var number = hasNumber ? int.Parse(commandString.Substring(1)) : 0;

			var command = GetCommand(firstLetter, number);
			if (command.ExpectsArgument != hasNumber)
				throw new InvalidCommandException();

			return command;
        }


		private static ICommand GetCommand(string firstLetter, int number)
		{
			switch (firstLetter)
			{
				case "I": return new DeliveryCommand(number);
				case "S": return new SaleCommand(number);
				case "L": return new CountCommand();
				default: throw new InvalidCommandException();
			}
		}
	}
}
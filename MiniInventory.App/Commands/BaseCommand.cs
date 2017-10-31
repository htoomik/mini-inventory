namespace MiniInventory.App.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public int Argument { get; }

		
		protected BaseCommand(int argument)
        {
            Argument = argument;
        }


		public abstract bool ExpectsArgument { get; }
        public abstract string Execute(IInventory inventory);
    }
}
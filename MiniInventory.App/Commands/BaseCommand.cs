namespace MiniInventory.App.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public int Argument { get; }


        public BaseCommand(int argument)
        {
            this.Argument = argument;
        }


        public abstract string Execute(IInventory inventory);
    }
}
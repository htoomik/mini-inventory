namespace MiniInventory.App.Commands
{
    public class NoOpCommand : BaseCommand 
    {
        public NoOpCommand() : base(0) {}


        public override string Execute(IInventory inventory)
        {
            return null;
        }
    }
}
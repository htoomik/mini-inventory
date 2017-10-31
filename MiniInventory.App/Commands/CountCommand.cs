namespace MiniInventory.App.Commands
{
    public class CountCommand : BaseCommand 
    {
        public CountCommand() : base(0) {}


		public override bool ExpectsArgument => false;


		public override string Execute(IInventory inventory)
        {
            return inventory.Count().ToString();
        }
    }
}
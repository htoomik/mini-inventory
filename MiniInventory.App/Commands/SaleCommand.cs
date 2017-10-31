namespace MiniInventory.App.Commands
{
    public class SaleCommand : BaseCommand 
    {
        public SaleCommand(int argument) : base(argument) {}


		public override bool ExpectsArgument => true;


		public override string Execute(IInventory inventory)
        {
            inventory.Sale(Argument);
            return null;
        }
    }
}
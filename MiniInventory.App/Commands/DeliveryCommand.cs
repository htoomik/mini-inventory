namespace MiniInventory.App.Commands
{
    public class DeliveryCommand : BaseCommand 
    {
        public DeliveryCommand(int argument) : base(argument) {}


        public override string Execute(IInventory inventory)
        {
            inventory.Delivery(Argument);
            return null;
        }
    }
}
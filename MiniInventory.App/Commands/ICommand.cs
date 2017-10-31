namespace MiniInventory.App
{
    public interface ICommand
    {
        int Argument { get; }
		bool ExpectsArgument { get; }
		string Execute(IInventory inventory);
    }
}
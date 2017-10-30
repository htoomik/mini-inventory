namespace MiniInventory.App
{
    public interface ICommand
    {
        int Argument { get; }
        string Execute(IInventory inventory);
    }
}
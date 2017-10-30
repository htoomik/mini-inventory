namespace MiniInventory.App
{
    public interface IParser
    {
        ICommand Parse(string command);
    }
}
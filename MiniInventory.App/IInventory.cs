namespace MiniInventory.App
{
    public interface IInventory
    {
        void Delivery(int amount);
        void Sale(int amount);
        int Count();
    }
}
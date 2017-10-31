using System;

namespace MiniInventory.App
{
    public class NotEnoughStockException : Exception
    {
        public string GetUserMessage()
        {
            return "Det finns inte så mycket i lager.";
        }
    }
}
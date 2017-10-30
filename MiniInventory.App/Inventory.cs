using System;
using System.Collections.Generic;

namespace MiniInventory.App
{
    public class Inventory
    {
        private int count;


        public int Count()
        {
            return count;
        }


        public void Delivery(int amount)
        {
            if (amount < 0)
                throw new ArgumentException($"{nameof(amount)} should be a positive number", nameof(amount));

            count += amount;
        }


        public void Sale(int amount)
        {
            if (amount < 0)
                throw new ArgumentException($"{nameof(amount)} should be a positive number", nameof(amount));

            if (amount > count)
                throw new NotEnoughStockException();

            count -= amount;
        }
    }
}
using System;
using MiniInventory.App;
using Xunit;

namespace MiniInventory.Tests
{
    public class InventoryTest
    {
        [Fact]
        public void NewInventory_Should_BeEmpty()
        {
            var inventory = new Inventory();
            Assert.Equal(0, inventory.Count());
        }


        [Fact]
        public void Delivery_Should_IncreaseCount()
        {
            const int amount = 42;

            var inventory = new Inventory();
            inventory.Delivery(amount);

            Assert.Equal(amount, inventory.Count());
        }


        [Fact]
        public void AnotherDelivery_Should_IncreaseCount()
        {
            const int amount1 = 42;
            const int amount2 = 17;

            var inventory = new Inventory();
            inventory.Delivery(amount1);
            inventory.Delivery(amount2);

            Assert.Equal(amount1 + amount2, inventory.Count());
        }


        [Fact]
        public void NegativeDeliveryAmount_Should_Throw()
        {
            var inventory = new Inventory();
            Assert.Throws<ArgumentException>(() => inventory.Delivery(-1));
        }


        [Fact]
        public void Sale_Should_DecreaseCount()
        {
            const int deliveryAmount = 42;
            const int saleAmount = 17;

            var inventory = new Inventory();
            inventory.Delivery(deliveryAmount);
            inventory.Sale(saleAmount);

            Assert.Equal(deliveryAmount - saleAmount, inventory.Count());
        }


        [Fact]
        public void NegativeSaleAmount_Should_Throw()
        {
            var inventory = new Inventory();
            inventory.Delivery(42);

            Assert.Throws<ArgumentException>(() => inventory.Sale(-1));
        }


        [Fact]
        public void When_SalesAmountExceedsCount_Should_Throw()
        {
            const int deliveryAmount = 42;
            const int saleAmount = deliveryAmount + 1;

            var inventory = new Inventory();
            inventory.Delivery(deliveryAmount);

            Assert.Throws<NotEnoughStockException>(() => inventory.Sale(saleAmount));
        }
    }
}
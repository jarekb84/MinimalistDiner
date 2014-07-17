using MinimalistDiner.Services;
using NUnit.Framework;

namespace MinimalistDiner.Tests
{
    [TestFixture]
    public class Tests
    {
        private OrderingService order;

        private void MakeOrder(string input)
        {
            var args = input.Split(' ');

            order = new OrderingService(args);
        }

        [Test]
        public void MorningOrderOneOfEach()
        {
            MakeOrder("morning, 1, 2, 3");

            Assert.AreEqual("eggs, toast, coffee", order.Result);
        }

        [Test]
        public void MorningOrderOneOfEachOutOfOrder()
        {
            MakeOrder("morning, 2, 1, 3");

            Assert.AreEqual("eggs, toast, coffee", order.Result);
        }

        [Test]
        public void MorningOrderWithInvalidSelection()
        {
            MakeOrder("morning, 1, 2, 3, 4");
            
            Assert.AreEqual("eggs, toast, coffee, error", order.Result);
        }

        [Test]
        public void MorningOrderMultipleCoffee()
        {
            MakeOrder("morning, 1, 2, 3, 3, 3");

            Assert.AreEqual("eggs, toast, coffee(x3)", order.Result);
        }

        [Test]
        public void NightOrderOneOfEach()
        {
            MakeOrder("night, 1, 2, 3, 4");

            Assert.AreEqual("steak, potato, wine, cake", order.Result);
        }

        [Test]
        public void NightOrderMultiplePotatoes()
        {
            MakeOrder("night, 1, 2, 2, 4");

            Assert.AreEqual("steak, potato(x2), cake", order.Result);
        }

        [Test]
        public void NightOrderWithInvalidSelection()
        {
            MakeOrder("night, 1, 2, 3, 5");

            Assert.AreEqual("steak, potato, wine, error", order.Result);
        }

        [Test]
        public void NightOrderWithMultipleSteaks()
        {
            MakeOrder("night, 1, 1, 2, 3, 5");

            Assert.AreEqual("steak, error", order.Result);
        }
    }
}

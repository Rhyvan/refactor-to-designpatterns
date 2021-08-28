using System;
using System.Linq;
using System.Reflection;
using DesignPatterns.Strategy;
using NUnit.Framework;

namespace Tests.DesignPatterns.Strategy
{
    [TestFixture]
    class StrategyTest
    {
        VendingMachine machine;

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            machine = new VendingMachine();
        }

        [Test]
        public void DefaultBeverageThrowsError()
        {
            Assert.Throws<ArgumentException>(() => machine.MakeBeverage(Beverage.Yoghurt));
        }

        [Test]
        public void SelectingCoffeResultsCoffe()
        {
            var drink = machine.MakeBeverage(Beverage.Espresso);
            Assert.AreEqual("coffee", drink.Name);
        }

        [Test]
        public void MakingCoffeMakesMachineWarm()
        {
            var defaultMachineWarmth = machine.IsWarm;
            machine.MakeBeverage(Beverage.Macchiato);

            Assert.IsFalse(defaultMachineWarmth);
            Assert.IsTrue(machine.IsWarm);
        }

     
        // Do not clutter the VendingMachine with methods that are submethods of MakeBeverage()
        [Test]
        public void ObjectHasOnlyOneMethod()
        {
            var methodAmountOfType = machine.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => !m.IsSpecialName && m.DeclaringType != typeof(object))
               .Count();

            Assert.AreEqual(1, methodAmountOfType);
        }
    }
}

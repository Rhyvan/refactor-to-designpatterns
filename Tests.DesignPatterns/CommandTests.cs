using System;
using System.Globalization;
using System.IO;
using DesignPatterns.Command;
using NUnit.Framework;

namespace Tests.DesignPatterns.Command
{
    [TestFixture]
    public abstract class CommandTests
    {
        protected IWaiter iWaiter;
        protected StringWriter _sw;

        [SetUp]
        public void Init()
        {
            _sw = new StringWriter();
            Console.SetOut(_sw);
        }

        [TearDown]
        public void AfterAllTestHasRun()
        {
            _sw.Dispose();
        }
    }

    public abstract class AbstractJuniorTest : CommandTests
    {
        [Test]
        public void OrderStartsCooking()
        {
            iWaiter.MakeOrder();
            Assert.True
                (
                    String.Compare
                    (
                        _sw.ToString(),
                        "Cooking soup Cooking pasta",
                        new CultureInfo("en-US"),
                        CompareOptions.IgnoreSymbols
                    ) == 0
                );
        }
    }

    public abstract class AbstractMediorTest : CommandTests
    {
        [Test]
        public void OrderStartsCooking()
        {
            iWaiter.MakeOrder();
            Assert.True
                (
                    String.Compare
                    (
                        _sw.ToString(),
                        "Cooking soup Cooking steak Cooking some potatoes",
                        new CultureInfo("en-US"),
                        CompareOptions.IgnoreSymbols
                    ) == 0
                );
        }
    }

    public class PatternTest : CommandTests
    {
        private static readonly object[] _data =
        {
            new object[]{ new JuniorWaiter(new Chef()), "Cooking soup Cooking pasta" },
            new object[]{ new MediorSteakWaiter(new Chef(), new Cook()), "Cooking soup Cooking steak Cooking some potatoes" }
        };

        [Test]
        [TestCaseSource(nameof(_data))]
        public void OrderStartsCooking(IWaiter waiter, string expectedString)
        {
            var processer = new OrderProcesser();
            processer.SetCommand(waiter);
            processer.Execute();
            Assert.True
                (
                    String.Compare
                    (
                        _sw.ToString(),
                        expectedString,
                        new CultureInfo("en-US"),
                        CompareOptions.IgnoreSymbols
                    ) == 0
                );
        }
    }

    public class JuniorWaiterTest : AbstractJuniorTest
    {
        [SetUp]
        public void initWaiter()
        {
            iWaiter = new JuniorWaiter(new Chef());
        }
    }

    public class JuniorWaitressTest : AbstractJuniorTest
    {
        [SetUp]
        public void initWaiter()
        {
            iWaiter = new JuniorWaitress(new Chef());
        }
    }

    public class MediorWaitressTest : AbstractMediorTest
    {
        [SetUp]
        public void initWaiter()
        {
            iWaiter = new MediorSteakWaitress(new Chef(), new Cook());
        }
    }

    public class MediorWaiterTest : AbstractMediorTest
    {
        [SetUp]
        public void initWaiter()
        {
            iWaiter = new MediorSteakWaiter(new Chef(), new Cook());
        }
    }
}

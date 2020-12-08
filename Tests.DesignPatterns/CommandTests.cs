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


        [OneTimeSetUp]
        public void Init()
        {
            _sw = new StringWriter();
            Console.SetOut(_sw);
        }

        [OneTimeTearDown]
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

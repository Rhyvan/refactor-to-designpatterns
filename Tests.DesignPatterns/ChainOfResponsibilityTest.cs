using NUnit.Framework;
using DesignPatterns.ChainOfResponsibility;

namespace Tests.DesignPatterns.ChainOfResponsibility
{
    [TestFixture]
    class ChainOfResponsibilityTest
    {
        private IChainCLient _chainClient;

        [SetUp]
        public void SetupBeforeEach()
        {
            _chainClient = new NoPatternChainClient();
        }

        [Test]
        public void NameShouldNotBeEmpty()
        {
            var user = new User()
            {
                Name = "",
                Age = 50,
                Email = "hello@bello.com"
            };

            Assert.False(_chainClient.ValidateUser(user));
        }

        [Test]
        public void AgeShouldBeBiggerThan18()
        {
            var user = new User()
            {
                Name = "Peter",
                Age = 17,
                Email = "hello@bello.com"
            };

            Assert.False(_chainClient.ValidateUser(user));
        }

        [Test]
        public void EmailShouldBeValid()
        {
            var user = new User()
            {
                Name = "Peter",
                Age = 22,
                Email = "something"
            };

            Assert.False(_chainClient.ValidateUser(user));
        }

        [Test]
        public void ValidUserReturnsTrue()
        {
            var user = new User()
            {
                Name = "Peter",
                Age = 22,
                Email = "hello@bello.com"
            };

            Assert.True(_chainClient.ValidateUser(user));
        }
    }
}

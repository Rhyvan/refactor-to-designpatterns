using System;
using NUnit.Framework;
using DesignPatterns.Builder;

namespace Tests.DesignPatterns.Builder
{

    [TestFixture]
    class BuilderTest
    {
        private readonly string correctMail = "peter@gmail.com";


        [Test]
        public void UserShouldntExistWithoutEmail()
        {
            Assert.Throws<ArgumentNullException>(() => new User());
        }

        [Test]
        public void SimpleUserWithEmail()
        {
            User usr = new User(correctMail);
            Assert.That(usr, Has.Property("Email").EqualTo(correctMail));
        }

        [Test]
        public void SimpleUserWithAgeAndEmail()
        {
            User usr = new User(correctMail, 33);
            Assert.That(usr, Has.Property("Email").EqualTo(correctMail));
            Assert.AreEqual(usr.Age, 33);
        }

        [Test]
        public void SimpleUserWithNameAndEmail()
        {
            User user = new User(correctMail, "Peter");
            Assert.AreEqual(user.Email, correctMail);
            Assert.AreEqual(user.Name, "Peter");
        }

        [Test]
        public void SimpleUserWithHeightAndEmail()
        {
            User user = new User(correctMail, 1.93d);
            Assert.AreEqual(user.Email, correctMail);
            Assert.AreEqual(user.Height, 1.93d);
        }
        [Test]
        public void SimpleUserWithNameAndAgeAndHeightAndEmail()
        {
            User user = new User(correctMail, "Peter", 30, 1.85d);

            Assert.AreEqual(user.Email, correctMail);
            Assert.AreEqual(user.Name, "Peter");
            Assert.AreEqual(user.Age, 30);
            Assert.AreEqual(user.Height, 1.85d);
        }
    }
}

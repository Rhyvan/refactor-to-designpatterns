using DesignPatterns.State;
using NUnit.Framework;

namespace Tests.DesignPatterns.State
{
    [TestFixture]
    public class StateTest
    {
        private Goku goku;
        private Frieza frieza;

        [SetUp]
        public void SetupBeforeEach()
        {
            goku = new Goku();
            frieza = new Frieza();
        }

        [Test]
        public void SmokeTest()
        {
            Assert.IsNotNull(goku);
        }

        [Test]
        public void PowerUpIsCyclical()
        {
            Assert.AreEqual(goku.CurrentLevel, TransformationLevel.FIGHTER);
            goku.PowerUp();
            Assert.AreEqual(goku.CurrentLevel, TransformationLevel.SSJ1);
            goku.PowerUp();
            Assert.AreEqual(goku.CurrentLevel, TransformationLevel.SSJ2);
            goku.PowerUp();
            Assert.AreEqual(goku.CurrentLevel, TransformationLevel.SSJ3);
            goku.PowerUp();
            Assert.AreEqual(goku.CurrentLevel, TransformationLevel.FIGHTER);
        }

        [Test]
        public void SimpleGokuCantDefeatFrieza()
        {
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Black", Attack = 9000}
            );
            goku.TryToDestroyFrieza(frieza);
            Assert.IsTrue(frieza.IsAlive());
        }

        [Test]
        public void SSJ1HairIsYellowAndCanDefeatFrieza()
        {
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Black", Attack = 9000 }
            );
            goku.PowerUp();
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Yellow", Attack = 100_000 }
            );
            goku.TryToDestroyFrieza(frieza);
            Assert.IsFalse(frieza.IsAlive());
        }

        [Test]
        public void SSJ3HairIsTotalYellowAndLongAndCanDefeatFrieza()
        {
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Black", Attack = 9000 }
            );
            goku.PowerUp();
            goku.PowerUp();
            goku.PowerUp();
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Total Yellow and Long", Attack = 500_000_000 }
            );
            goku.TryToDestroyFrieza(frieza);
            Assert.IsFalse(frieza.IsAlive());
        }

        [Test]
        public void GokuResetsAfterSSJ3ToHisDefaultState()
        {

            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Black", Attack = 9000 }
            );
            goku.PowerUp();
            goku.PowerUp();
            goku.PowerUp();
            goku.PowerUp();
            Assert.AreEqual(
                new { Hair = goku.HairColor(), Attack = goku.AttackValue() },
                new { Hair = "Black", Attack = 9000 }
            );
        }
    }
}
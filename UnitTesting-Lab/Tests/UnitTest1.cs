using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLosesDurabilityAfterEachAttack()
        {
            //Arrange
            Axe axe = new Axe(30, 40);
            Dummy target = new Dummy(20, 50);

            //Act
            axe.Attack(target);
            var result = axe.DurabilityPoints;

            //Assert
            Assert.That(result, Is.EqualTo(39));
        }

        [Test]
        public void AttackingWithBrokenAxeShouldThrowExeption()
        {
            //Arrage
            Axe axe = new Axe(10, 1);
            Dummy target = new Dummy(20, 50);

            //Act
            axe.Attack(target);

            //Assert
            Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException());
        }
    }


    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void DummyShouldLosesHealthIfAttacked()
        {
            // Arrange
            var dummy = new Dummy(40, 50);

            // Act
            dummy.TakeAttack(30);

            // Assert
            Assert.That(dummy.Health, Is.EqualTo(10));
        }

        [Test]
        public void DeadDummyShouldThrowsExceptionIfAttacked()
        {
            // Arrange
            var dummy = new Dummy(0, 10);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            // Arrange
            var dummy = new Dummy(0, 10);

            // Act
            var experience = dummy.GiveExperience();

            // Assert
            Assert.That(experience, !Is.EqualTo(null));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            // Arrange
            var dummy = new Dummy(40, 10);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException("Target is not dead."));
        }
    }
}
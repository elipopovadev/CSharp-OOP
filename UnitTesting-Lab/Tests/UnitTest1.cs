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
            Assert.Throws<InvalidOperationException>(()=> throw new InvalidOperationException());
        }
    }
}
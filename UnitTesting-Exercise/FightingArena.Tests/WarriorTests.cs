using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateTheConstructor()
        {
            // Arrange
            // Act
            var warrior = new Warrior("viking", 50, 80);

            // Assert
            Assert.That(() => warrior.Name, Is.EqualTo("viking"));
            Assert.That(() => warrior.Damage, Is.EqualTo(50));
            Assert.That(() => warrior.HP, Is.EqualTo(80));
        }

        [Test]
        public void ValidateIfThrowExceptionWhenNameIsEmpty()
        {
            // Arrange
            // Act

            //Assert
            Assert.That(() => new Warrior(" ", 50, 80), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ValidateIfThrowExceptionWhenDamageIsNegativeNumberOrZero(int damage)
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => new Warrior("viking", damage, 80), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void ValidateIfThrowExceptionWhenHPIsNegativeNumber()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => new Warrior("viking", 50, -1), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [TestCase(30)]
        [TestCase(29)]
        public void ValidateIfThrowExceptionWhenWarriorAttackWithLessHPThanMinimum(int HP)
        {
            // Arrange
            // Act
            var warrior = new Warrior("viking", 50, HP);
            var anotherWarrior = new Warrior("anotherViking", 40, 50);

            // Assert
            Assert.That(() => warrior.Attack(anotherWarrior), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [TestCase(30)]
        [TestCase(29)]
        public void ValidateIfThrowExceptionWhenDefenceWarriorHPIsLessThanMinimum(int HP)
        {
            // Arrange
            // Act
            var warrior = new Warrior("viking", 50, 80);
            var anotherWarrior = new Warrior("anotherViking", 40, HP);

            // Assert
            Assert.That(() => warrior.Attack(anotherWarrior), Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void ValidateIfThrowExceptionWhenWarriorTryToAttackAnotherTooStrongWarriorWithHigherDamage()
        {
            // Arrange
            // Act
            var warrior = new Warrior("viking", 50, 80);
            var anotherWarrior = new Warrior("anotherViking", 200, 80);

            // Assert
            Assert.That(() => warrior.Attack(anotherWarrior), Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void ValidateIfAttackWorkCorrectly()
        {
            // Arrange
            var warrior = new Warrior("viking", 50, 110);
            var defenceWarrior = new Warrior("anotherViking", 50, 80);

            // Act
            warrior.Attack(defenceWarrior);

            // Assert
            Assert.That(() => warrior.HP, Is.EqualTo(60));
        }

        [Test]
        public void ValidateIfSetToZeroDefenceWarriorHPWhenAttackWarriorDamageIsBiggerThanDefenceWarriorHP()
        {
            // Arrange
            var warrior = new Warrior("viking", 100, 110);
            var defenceWarrior = new Warrior("defenceViking", 50, 80);

            // Act
            warrior.Attack(defenceWarrior);

            // Assert
            Assert.That(() => defenceWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void ValidateIfDefenceWarriorHPReduceByAttackerDamageWhenDefenceHPIsBigger()
        {
            // Arrange
            var warrior = new Warrior("viking", 100, 110);
            var defenceWarrior = new Warrior("defenceViking", 50, 210);

            // Act
            warrior.Attack(defenceWarrior);

            // Assert
            Assert.That(() => defenceWarrior.HP, Is.EqualTo(110));
        }
    }
}
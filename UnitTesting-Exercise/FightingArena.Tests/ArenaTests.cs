using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        [SetUp]
        public void Setup()
        {
            firstWarrior = new Warrior("viking", 50, 80);
            secondWarrior = new Warrior("secondViking", 60, 90);
            arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
        }

        [Test]
        public void ValidateIfArenaIncreaseCountAfterEnrollCommand()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void ValidateIfArenaContainsEnrolledWarrior()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => arena.Warriors, Has.Member(firstWarrior));
        }

        [Test]
        public void ValidateIfEnrollCommandThrowExceptionWhenWarriorIsAlreadyEnrolled()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => arena.Enroll(firstWarrior), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfFightCommandThrowExceptionWhenDefenderWarriorIsMissing()
        {
            // Arrange
            // Act
            var defender = new Warrior("anotherOrk", 50, 60);

            // Assert
            Assert.That(() => arena.Fight(firstWarrior.Name, defender.Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defender.Name} enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfFightCommandThrowExceptionWhenAttackerWarriorIsMissing()
        {
            // Arrange
            // Act
            var attacker = new Warrior("ork", 60, 80);

            // Assert
            Assert.That(() => arena.Fight(attacker.Name, firstWarrior.Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attacker.Name} enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfAttackCommandWorkCorrectlyWhenBothOfWarriorsExistInTheArena()
        {
            // Arrange
            // Act
            arena.Fight(firstWarrior.Name, secondWarrior.Name);

            // Assert
            Assert.That(() => firstWarrior.Attack(secondWarrior), !Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {secondWarrior.Name} enrolled for the fights!"));
        }
    }
}


using Moq;
using NUnit.Framework;
using Skeleton.Iterfaces;

namespace Tests
{
    [TestFixture]
    public class HeroTestsMocking
    {
        const int experiance = 200;

        [Test]
        public void AttackLogicShouldWorkCorrectly()
        {
            // Arrange
            var weaponMock = Mock.Of<IWeapon>();

            var targetMock = new Mock<ITarget>();
            targetMock.Setup(t => t.IsDead())
                .Returns(true);
            targetMock.Setup(t => t.GiveExperience())
                .Returns(200);

            var hero = new Hero("TestHero", weaponMock);

            // Act
            hero.Attack(targetMock.Object);

            // Assert
            Assert.That(hero.Experience, Is.EqualTo(experiance));
        }
    }
}

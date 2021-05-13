using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("opel", "zafira", 10, 50);
        }

        [Test]
        public void ValidateTheCarConstructor()
        {
            // Arrange

            // Act
            // Assert
            Assert.That(car.Make, Is.EqualTo("opel"));
            Assert.That(car.Model, Is.EqualTo("zafira"));
            Assert.That(car.FuelConsumption, Is.EqualTo(10));
            Assert.That(car.FuelCapacity, Is.EqualTo(50));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void ValidateMakePropertyIfThrowExceptionWhenMakeIsNullOrEmpty()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => new Car(null, "zafira", 10, 50), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void ValidateModelPropertyIfThrowExceptionWhenModelIsNullOrEmpty()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => new Car("opel", null, 10, 50), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void ValidateFuelConsumptionIfThrowExceptionWhenItsZeroOrNegative()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => new Car("opel", "zafira", 0, 50), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void ValidateFuelCapacityIfThrowExceptionWhenItsNegativeNumber()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => new Car("opel", "zafira", 10, 0), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void ValidateRefuelCommandIfThrowExceptionWhenFuelToRefuelIsZeroOrNegative()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => car.Refuel(0), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void ValidateRefuelCommandIfFuelToRefuelIsSmallerThanFuelCapacity()
        {
            // Arrange

            // Act
            car.Refuel(50);

            // Assert
            Assert.That(() => car.FuelAmount, Is.EqualTo(50));
        }

        [Test]
        public void ValidateRefuelCommandIfFuelToRefuelIsBiggerThanFuelCapacity()
        {
            // Arrange

            // Act
            car.Refuel(51);

            // Assert
            Assert.That(() => car.FuelAmount, Is.EqualTo(50));
        }

        [Test]
        public void ValidateDriveCommandIfWorkCorrectly()
        {
            // Arrange

            // Act
            car.Refuel(30);
            car.Drive(15);

            // Assert
            double fuelNeeded = (15 / 100) * 10;
            double result = car.FuelAmount - fuelNeeded;
            Assert.That(result, Is.EqualTo(28.5));
        }

        [Test]
        public void ValidateDriveCommandIfThrowExceptionWhenTheFuelIsNotEnough()
        {
            // Arrange

            // Act
            car.Refuel(1);

            // Assert
            Assert.That(()=> car.Drive(15), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}
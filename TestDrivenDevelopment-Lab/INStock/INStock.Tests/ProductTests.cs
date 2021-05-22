namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        public void ValidateTheConstructor()
        {
            // Arrange
            // Act
            var product = new Product("testProduct", 4, 5);

            // Assert
            Assert.That(product.Name, Is.EqualTo("testProduct"));
            Assert.That(product.Price, Is.EqualTo(4));
            Assert.That(product.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void TheNameOfProductShouldNotBeNullOrEmpty()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => new Product("", 2, 5), Throws.ArgumentException.With.Message.EqualTo("The name of product should not be null"));
        }


        [Test]
        public void ThePriceOfProductShouldNotBeZero()
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("testProduct", 0, 5), "The price can not be zero");
        }

        [Test]
        public void ThePriceOfProductShouldNotBeNegativeNumber()
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("testProduct", -1, 5), "The price can not be negative number");
        }

        [Test]
        public void TheQuantityShouldNotBeNegativeNumber()
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("testProduct", 1, -3), "The quantity can not be negative number");
        }
    }
}
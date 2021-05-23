namespace INStock.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;

    public class ProductStockTests
    {
        [Test]
        public void TheNewProductShouldBeAddedInTheProductStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void TheDuplicateProductShouldNotBeenAddedInProductStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var duplicateProduct = new Product("testProduct", 5, 7);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(() => productStock.Add(duplicateProduct), Throws.ArgumentException.With.Message.EqualTo($"An item with the same key has already been added. Key: {duplicateProduct.Label}"));
        }

        [Test]
        public void TheContainsCommandShouldReturnTrueWhenProductIsInStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void TheContainsCommandShouldReturnFalseWhenProductIsNotInStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProductIsNotInStock", 5, 7);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(!productStock.Contains(newProduct));
        }

       
        [Test]
        public void TheCountShouldWorkCorrectly()
        {
            // Arrange      
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(productStock.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ValidateIfFindCommandWorkCorrectly()
        {
            // Arrange
            // Act
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);
            productStock.Add(product);
            productStock.Add(newProduct);
           
            // Assert
            Assert.That(productStock.Find(1), Is.EqualTo(newProduct));
        }

        [TestCase(-1)]
        [TestCase(-2)]
   
        public void ValidateIfFindCommandThrowExceptionWhenIndexIsOutOfRange(int index)
        {
            // Arrange
            // Act
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);
            productStock.Add(product);
            productStock.Add(newProduct);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        public void ValidateIfFindByLabelCommandWorkCorrectly()
        {
            // Arrange
            // Act
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);
            productStock.Add(product);
            productStock.Add(newProduct);

            // Assert
            Assert.That(productStock.FindByLabel("testProduct"), Is.EqualTo(product));
        }

        [Test]
        public void ValidateIfFindByLabelCommandThrowExceptionWhenProductLabelDoesNotExist()
        {
            // Arrange
            // Act
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);
            productStock.Add(product);
            productStock.Add(newProduct);

            // Assert
            Assert.Throws<ArgumentException>(()=> productStock.FindByLabel("testProduct5"),"The product does not exist in Stock");
        }
    }
}

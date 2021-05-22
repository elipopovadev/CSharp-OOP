namespace INStock.Tests
{
    using NUnit.Framework;
    using System.Linq;

    public class ProductStockTests
    {
        [Test]
        public void TheNewProductShouldBeAddedInTheProductStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m , 5);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(productStock.Any(p => p.Name == "testProduct"));
        }

        [Test]
        public void TheDuplicateProductShouldBeChangedInProductStockWhenBeenAdded()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var duplicateProduct = new Product("testProduct", 5, 7);

            // Act
            productStock.Add(product);
            productStock.Add(duplicateProduct);

            // Assert
            Assert.That(productStock.Any(p => p.Name == "testProduct" && p.Price == 5 && !productStock.Any(p => p.Name == "testProduct" && p.Price == 4.60m)));
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
            Assert.That(productStock.Contains(product) = true);
        }

        [Test]
        public void TheContainsCommandShouldReturnFalseWhenProductIsNotInStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);

            // Act
            productStock.Add(product);

            // Assert
            Assert.That(productStock.Contains(newProduct) = false);
        }

       
        [Test]
        public void TheCountShouldWorkCorrectly()
        {
            // Arrange
            // Act
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);

            // Assert
            Assert.That(productStock.Count(), Is.EqualTo(1));
        }
    }
}

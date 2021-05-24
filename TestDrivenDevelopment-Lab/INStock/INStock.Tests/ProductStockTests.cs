namespace INStock.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    
    public class ProductStockTests
    {
        private ProductStock productStock;
        private Product product;
        private Product newProduct;
        private Product anotherProduct;
        private Product nextProduct2;

        [SetUp]   
        public void SetUpProductStock()
        {
            productStock = new ProductStock();
            product = new Product("testProduct", 4.60m, 5);
            newProduct = new Product("testProduct2", 5, 7);
            anotherProduct = new Product("testProduct3", 4, 8);
            nextProduct2 = new Product("testProduct4", 4, 8);
            productStock.Add(product);
            productStock.Add(newProduct);
            productStock.Add(anotherProduct);
            productStock.Add(nextProduct2);
        }

        [Test]
        public void TheNewProductShouldBeAddedInTheProductStock()
        {
            // Arrange
            var productStock = new ProductStock();
            var product100 = new Product("testProduct", 4.60m, 5);

            // Act
            productStock.Add(product100);

            // Assert
            Assert.That(productStock.Contains(product100));
        }

        [Test]
        public void TheDuplicateProductShouldNotBeenAddedInProductStock()
        {
            // Arrange
            // Act        
            var duplicateProduct = new Product("testProduct", 5, 7);


            // Assert
            Assert.That(() => productStock.Add(duplicateProduct), Throws.ArgumentException.With.Message.EqualTo($"An item with the same key has already been added. Key: {duplicateProduct.Label}"));
        }

        [Test]
        public void TheContainsCommandShouldReturnTrueWhenProductIsInStock()
        {
            // Arrange
            // Act
   

            // Assert
            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void TheContainsCommandShouldReturnFalseWhenProductIsNotInStock()
        {
            // Arrange
            // Act
            var newProductDoesNotExist = new Product("testProductIsNotInStock", 5, 7);

            // Assert
            Assert.That(!productStock.Contains(newProductDoesNotExist));
        }

       
        [Test]
        public void TheCountShouldWorkCorrectly()
        {
            // Arrange      
            var product5 = new Product("testProduct5", 4.60m, 5);

            // Act
            productStock.Add(product5);

            // Assert
            Assert.That(productStock.Count(), Is.EqualTo(5));
        }

        [Test]
        public void ValidateIfFindCommandWorkCorrectly()
        {
            // Arrange
            // Act
           
            // Assert
            Assert.That(productStock.Find(1), Is.EqualTo(newProduct));
        }

        [TestCase(-1)]
        [TestCase(-2)]
   
        public void ValidateIfFindCommandThrowExceptionWhenIndexIsOutOfRange(int index)
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        public void ValidateIfFindByLabelCommandWorkCorrectly()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(productStock.FindByLabel("testProduct"), Is.EqualTo(product));
        }

        [Test]
        public void ValidateIfFindByLabelCommandThrowExceptionWhenProductLabelDoesNotExist()
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentException>(()=> productStock.FindByLabel("testProduct5"),"The product does not exist in Stock");
        }

        [Test]
        public void TheCommandFindAllInPriceRangeShouldWorkCorrectly()
        {
            // Arrange
            // Act
          
            var result = new List<Product> {newProduct, product, anotherProduct, nextProduct2};

            // Assert
            CollectionAssert.AreEquivalent(result, productStock.FindAllInPriceRange(3, 6));
        }

        [Test]
        public void TheCommandFindAllInPriceRangeShouldReturnEmptyCollectionIFThereAreNotProductInRange()
        {
            // Arrange
            // Act
           
            var result = new List<Product>();
            
            // Assert
            CollectionAssert.AreEqual(result, productStock.FindAllInPriceRange(2, 3));
        }

        [Test]
        public void TheCommandFindAllByPriceShouldWorkCorrectly()
        {
            // Arrange
            // Act
           
            var result = new List<Product> { anotherProduct, nextProduct2 };

            // Assert
            CollectionAssert.AreEqual(result, productStock.FindAllByPrice(4));
        }

        [Test]
        public void TheCommandFindAllByPriceShouldReturnEmptyCollectionIfThePriceDoesNotExist()
        {
            // Arrange
            // Act

            var result = new List<Product>();

            // Assert
            CollectionAssert.AreEqual(result, productStock.FindAllByPrice(3));
        }

        [Test]
        public void TheCommandFindMostExpensiveProductShouldWorkCorrectly()
        {
            // Arrange
            // Act
           
            Product mostExpensiveProduct = productStock.FindMostExpensiveProduct();

            // Assert
            Assert.That(mostExpensiveProduct, Is.EqualTo(newProduct));
        }

        [Test]
        public void TheCommandFindAllByQuantity()
        {
            // Arrange
            //  Act
            var productsWithTheSameQuantity = new List<Product> {anotherProduct, nextProduct2};

            // Assert
            CollectionAssert.AreEqual(productsWithTheSameQuantity, productStock.FindAllByQuantity(8));
        }

        [Test]
        public void TheCommandFindAllByQuantityShouldReturnEmptyCollectionIfTheQuantityDoesNotExist()
        {
            // Arrange
            // Act
         
            var emptyList = new List<Product>();

            // Assert
            CollectionAssert.AreEqual(emptyList, productStock.FindAllByQuantity(10));
        }

        [Test]
        public void TheGetEnumeratorShouldWorkCorrectly()
        {
            // Arrange
            // Act

            var expectedResult = new List<Product> { product, newProduct, anotherProduct, nextProduct2 };

            // Assert
            CollectionAssert.AreEqual(expectedResult, productStock.ToList());
        }
    }
}

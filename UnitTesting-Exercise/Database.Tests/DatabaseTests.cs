using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[4] { 1, 2, 3, 4 });
        }

        [Test]
        public void ValidateTheConstructor()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithBiggerDataThanCapacity()
        {
            int[] data = new int[17] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Assert.That(() => new Database.Database(data), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void ValidateAddCommand()
        {
            // Arrange
            // Act
            database.Add(5);

            // Assert
            Assert.That(database.Count, Is.EqualTo(5));
        }

        [Test]
        public void ValidateIfAddCommandThrowExceptionWhenOverTheCapacity()
        {
            // Arrange
            var database = new Database.Database(new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            // Act
            // Assert
            Assert.That(() => database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void ValidateRemoveCommand()
        {
            // Arrange

            // Act
            database.Remove();

            // Assert
            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void ValidateIfRemoveCommandThrowExceptionWhenDatabaseIsEmpty()
        {
            // Arrange
            var database = new Database.Database();

            // Act
            // Assert
            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]
        [TestCase(new int[] {})]
        public void FetchCommandShouldReturnCopyOfData(int[] expectedData)
        {
            // Arrange
            this.database = new Database.Database(expectedData);

            // Act
             int[] resultArray  = database.Fetch();

            // Assert
            CollectionAssert.AreEqual(expectedData,resultArray);
        }
    }
}
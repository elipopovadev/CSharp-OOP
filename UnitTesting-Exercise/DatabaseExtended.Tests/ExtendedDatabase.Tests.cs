using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Database.Database database;
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(new int[4] { 1, 2, 3, 4 });

            var firstPerson = new Person(1234, "Gosho");
            var secondPerson = new Person(4567, "Misho");
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(new Person[2] { firstPerson, secondPerson });
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

        [Test]
        public void ValidateFetchCommand()
        {
            // Arrange

            // Act
            int[] resultArray = database.Fetch();

            // Assert
            Assert.That(() => resultArray, Is.EqualTo(new int[4] { 1, 2, 3, 4 }));
        }

        [Test]
        public void ValidateTheConstructorOfExtendedDatabase()
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() => extendedDatabase.Count, Is.EqualTo(2));
        }

        [Test]
        public void ValidateTheConstructorIfThrowExceptionWhenOverTheCapacity()
        {
            // Arrange
            // Act
            var listWithPeople = new List<Person>();
            int capacity = 16;
            for (int i = 0; i <= capacity; i++)
            {
                int id = i + 1;
                string name = "Gosho"+ i;
                var person = new Person(id, name);
                listWithPeople.Add(person);
            }

            // Assert          
            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(listWithPeople.ToArray()), Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void ValidateIfAddCommandThrowExceptionWhenOverTheCapacityInExtendedDatabase()
        {
            // Arrange
            var listWithPeople = new List<Person>();
            int capacity = 16;
            for (int i = 0; i < capacity; i++)
            {
                int id = i + 1;
                string name = "Gosho" + i;
                var person = new Person(id, name);
                listWithPeople.Add(person);
            }

            var extendedDatabase = new ExtendedDatabase.ExtendedDatabase(listWithPeople.ToArray());
            var nextPerson = new Person(1234, "Pesho");

            // Act
            // Assert
            Assert.That(() => extendedDatabase.Add(nextPerson), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void ValidateIfAddCommandThrowExceptionWhenThereIsAlreadyUserWithThisName()
        {
            // Arrange
            var nextPerson = new Person(12345, "Misho");

            // Act
            // Assert
            Assert.That(() => extendedDatabase.Add(nextPerson), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));          
        }

        [Test]
        public void ValidateIfAddCommandThrowExceptionWhenThereIsAlreadyUserWithThisID()
        {
            // Arrange
            var nextPerson = new Person(1234, "Drago");

            // Act
            // Assert
            Assert.That(() => extendedDatabase.Add(nextPerson), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void ValidateIfAddCommandWorkCorrectly()
        {
            // Arrange
            var nextPerson = new Person(234563, "Ivan");

            // Act
            extendedDatabase.Add(nextPerson);

            // Assert
            Assert.That(() => extendedDatabase.Count, Is.EqualTo(3));
        }

        [Test]
        public void ValidateIfRemoveCommandThrowExceptionWhenExtendedDatabaseCountIsZero()
        {
            // Arrange
            var extendedDatabase = new ExtendedDatabase.ExtendedDatabase();

            // Act
            // Assert
            Assert.That(() => extendedDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ValidateIfRemoveCommandWorkCorrectly()
        {
            // Arrange

            // Act
            extendedDatabase.Remove();

            // Assert
            Assert.That(() => extendedDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidateIfCommandFindByUsernameThrowExceptionWithEmptyOrNullParameter()
        {
            // Arrange

            // Act
            // Assert
            Assert.That(() => extendedDatabase.FindByUsername(null), Throws.ArgumentNullException.With.Message.EqualTo("Value cannot be null. (Parameter 'Username parameter is null!')"));
        }

        [Test]
        public void ValidateIfCommandFindByUsernameThrowExceptionWhenNameNotExistInExtendedDatabase()
        {
            // Arrange

            // Act
            // Assert
            Assert.That(() => extendedDatabase.FindByUsername("Ivan"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void ValidateIfCommandFindByUsernameWorkCorrectly()
        {
            // Arrange

            // Act
            var findedPerson = extendedDatabase.FindByUsername("Gosho");

            // Assert
            Assert.That(() => findedPerson.UserName, Is.EqualTo("Gosho"));
        }

        [Test]
        public void ValidateIfCommandFindByIdThrowExceptionWhenIdIsNegativeNumber()
        {
            // Arrange
 
            // Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1), "Id should be a positive number!");
        }

        [Test]
        public void ValidateIfCommandFindByIdThrowExceptionWhenIdNotExist()
        {
            // Arrange
      
            // Act
            // Assert
            Assert.That(() => extendedDatabase.FindById(12345), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void ValidateIfCommandFindByIdWorkCorrectly()
        {
            // Arrange

            // Act
            var findedPerson = extendedDatabase.FindById(1234);
            // Assert
            Assert.That(() => findedPerson.Id, Is.EqualTo(1234));
        }
    }
}
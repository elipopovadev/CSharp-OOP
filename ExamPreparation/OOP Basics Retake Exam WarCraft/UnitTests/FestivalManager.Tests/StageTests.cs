namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetStage()
        {
            stage = new Stage();
        }

        [Test]
        public void TheCommandAddPerformerShouldAddPerformer()
        {
            // Arrange
            var newPerformer = new Performer("TestFirstName", "TestLastName", 18);

            // Act
            stage.AddPerformer(newPerformer);

            // Assert
            CollectionAssert.Contains(stage.Performers, newPerformer);
        }

        [Test]
        public void TheCommandAddPerformerShouldThrowExceptionIfPerformerAgeIsLessThan18()
        {
            // Arrange
            var newPerformer = new Performer("TestFirstName", "TestLastName", 17);
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(newPerformer), "You can only add performers that are at least 18.");
        }

        [Test]
        public void TheCommandAddPerformerShouldThrowExceptionIfPerformerIsNull()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null), "Can not be null");
        }

        [Test]
        public void TheCommandAddSongShouldWorkCorrectly()
        {
            // Arrange
            var newSong = new Song("TestName", new TimeSpan(0, 2, 30));
            var newPerformer = new Performer("TestFirstName", "TestLastName", 18);

            // Act
            stage.AddSong(newSong);
            stage.AddPerformer(newPerformer);
            stage.AddSongToPerformer(newSong.Name, newPerformer.FullName);

            // Assert
            Assert.That(stage.Play(), Is.EqualTo($"{stage.Performers.Count} performers played {1} songs"));
        }

        [Test]
        public void TheCommandAddSongShouldThrowExceptionIfSongDurationIsLessThan1min()
        {
            // Arrange
            var newSong = new Song("TestName", new TimeSpan(0, 0, 59));

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => stage.AddSong(newSong), $"You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void TheCommandAddSongsShouldThrowExceptionIfSongForAddIsNull()
        {
            // Arrange
            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null), "Can not be null");
        }

        [Test]
        public void TheCommandAddSongToPerformerShouldThrowExceptionWhenSongIsNull()
        {
            // Arrange
            var newPerformer = new Performer("TestFirstName", "TestLastName", 18);

            // Act
            stage.AddPerformer(newPerformer);

            // Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, newPerformer.FullName), "Can not be null");
        }

        [Test]
        public void TheCommandAddSongToPerformerShouldThrowExceptionWhenPerformerIsNull()
        {
            // Arrange
            var newSong = new Song("TestName", new TimeSpan(0, 2, 30));

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(newSong.Name, null), "Can not be null");
        }

        [Test]
        public void TheCommandAddSongToPerformerShouldWorkCorrectly()
        {
            // Arrange
            var firstPerformer = new Performer("TestFistName1", "TestLastName1", 30);
            var secondPerformer = new Performer("TestFirstName2", "TestLastName2", 35);

            var firstSong = new Song("TestName1", new TimeSpan(0, 2, 30));
            var secondSong = new Song("TestName2", new TimeSpan(0, 3, 30));

            stage.AddPerformer(firstPerformer);
            stage.AddPerformer(secondPerformer);
            stage.AddSong(firstSong);
            stage.AddSong(secondSong);

            // Act
            stage.AddSongToPerformer(firstSong.Name, firstPerformer.FullName);

            // Assert
            Assert.That(stage.AddSongToPerformer(firstSong.Name, firstPerformer.FullName), Is.EqualTo($"{firstSong} will be performed by {firstPerformer}"));
        }

        [Test]
        public void TheCommandAddSongToPerformerShouldThrowExceptionIfPerformerDoesNotExist()
        {
            // Arrange
            var firstSong = new Song("TestName1", new TimeSpan(0, 2, 30));

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(firstSong.Name, "NameDoesNotExist"), "There is no performer with this name.");
        }

        [Test]
        public void TheCommandAddSondToPerformerShouldThrowExceptionIfSongDoesNotExist()
        {
            // Arrange
            var firstPerformer = new Performer("TestFistName1", "TestLastName1", 30);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("NameDoesNotExist", firstPerformer.FullName), "There is no song with this name.");
        }
    }
}
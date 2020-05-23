using _07_RepoPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace _07_RepoPattern_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private StreamingContentRepository _repo = new StreamingContentRepository();
        [TestInitialize]
        public void SeedRepo()
        {
            StreamingContent snatch = new StreamingContent("Snatch", "Guy Ritchie movie", 4.8, MaturityRating.R, GenreType.Comedy);
            StreamingContent dieHard = new StreamingContent("Die Hard", "The ultimate christmas film", 4.8, MaturityRating.R, GenreType.Christmas);
            StreamingContent moana = new StreamingContent("Moana", "Disney?", 4.0, MaturityRating.G, GenreType.Christmas);

            _repo.AddContentToDirectory(snatch);
            _repo.AddContentToDirectory(dieHard);
            _repo.AddContentToDirectory(moana);
        }   

        [TestMethod]
        public void AddContentGetCount()
        {
            // Arrange
            // StreamingContent snatch = new StreamingContent("Snatch", "Guy Ritchie movie", 4.8, MaturityRating.R, GenreType.Comedy);
            // StreamingContent dieHard = new StreamingContent("Die Hard", "The ultimate christmas film", 4.8, MaturityRating.R, GenreType.Christmas);
            // Act
            // _repo.AddContentToDirectory(snatch);
            // _repo.AddContentToDirectory(dieHard);
            // SeedRepo();
            // Assert
            int expected = 2;
            int actual = _repo.GetContents().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddContentCountShouldIncrease()
        {
            StreamingContent dieHard = new StreamingContent("Die Hard", "The ultimate christmas film", 4.8, MaturityRating.R, GenreType.Christmas);

            bool wasAdded = _repo.AddContentToDirectory(dieHard);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetContentByTitleShouldGetContent()
        {
            // Arrange
            StreamingContent dieHard = new StreamingContent("Die Hard", "The ultimate christmas film", 4.8, MaturityRating.R, GenreType.Christmas);
            _repo.AddContentToDirectory(dieHard);

            // Act
            StreamingContent testContent = _repo.GetContentByTitle("die hard");

            // Assert
            Assert.AreEqual(dieHard, testContent);
        }
        [TestMethod]
        public void UpdateContentShouldUpdate()
        {
            StreamingContent newContent = new StreamingContent("Snatch", "Guy Ritchie movie", 4.8, MaturityRating.R, GenreType.Action);
            _repo.UpdateContentByTitle("snatch", newContent);
            // SeedRepo(); <-- Don't need this if it's a [TestInitialize] method
            GenreType expected = GenreType.Action;
            GenreType actual = _repo.GetContentByTitle("snatch").Genre;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldGetFamilyFriendlyContentOnly()
        {
            // Arrange
            // Action
            int actual = _repo.GetFamilyFriendlyContent().Count;
            int expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveContentShouldReduceList()
        {
            // Arrange
            // Act
            _repo.RemoveContentByTitle("snatch");

            int expected = 2;
            int actual = _repo.GetContents().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}

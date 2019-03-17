using System;
using System.Web;
using FinalProject.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalProjectTest.Tests
{
    [TestClass]
    public class MovieHistoryServiceTest
    {
        private MovieHistoryService movieHistoryService = new MovieHistoryService();
        MockHelpers mock = new MockHelpers();

        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = mock.FakeHttpContext();

        }


        [TestMethod]
        public void GetPopularMovies_Test()
        {
            //Arrange
 

            //Act
            var moviesReturned = movieHistoryService.GetPopularMovies();
            
            //Asset
            Assert.IsNotNull(moviesReturned.MovieOne);
            Assert.IsNotNull(moviesReturned.MovieTwo);

        }

        [TestMethod]
        public void GetGenre_Test()
        {
            //Arrange


            //Act
            var moviesReturned = movieHistoryService.GetGenre();

            //Asset
            Assert.IsNotNull(moviesReturned.GenreOne);
            Assert.IsNotNull(moviesReturned.GenreTwo);

        }

        [TestMethod]
        public void GetByGenre_Test()
        {
            //Arrange
            int genreId = 16;

            //Act
            var moviesReturned = movieHistoryService.GetByGenre(genreId);

            //Asset
            Assert.IsNotNull(moviesReturned.GenreMovieOne);
            Assert.IsNotNull(moviesReturned.GenreMovieTwo);
            Assert.IsTrue(moviesReturned.GenreMovieOne.genre_ids.Contains(genreId));
            Assert.IsTrue(moviesReturned.GenreMovieTwo.genre_ids.Contains(genreId));


        }

    }
}

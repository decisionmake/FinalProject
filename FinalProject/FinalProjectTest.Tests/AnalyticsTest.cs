using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.Models.DAL_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalProjectTest.Tests
{
    [TestClass]
    public class AnalyticsTest
    {
        public Analytics analyticsTesClass = new Analytics();
        MockHelpers mock = new MockHelpers();
        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = mock.FakeHttpContext();
            HttpContext.Current.Session["SelectedMovie"] = "Deadpool 2";
        }

        [TestMethod]
        public void AverageTimesSelected_Test()
        {
            //Arrange
            decimal averageMin = 0;
            decimal averageMax = 100;
            var db = mock.Database();

            //Act
            decimal averageReturned = analyticsTesClass.AverageTimesSelected(db);

            //Assert
            Assert.IsTrue(averageReturned >= averageMin && averageReturned <= averageMax);


        }

        [TestMethod]
        public void FrequencySkipped_Test()
        {
            //Arrange
            decimal averageMin = 0;
            decimal averageMax = 100;
            var db = mock.Database();

            //Act
            decimal averageReturned = analyticsTesClass.FrequencySkipped(db);

            //Assert
            Assert.IsTrue(averageReturned >= averageMin && averageReturned <= averageMax);

        }


    }
    public class MockHelpers
    {
        public HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://localhost/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 10, true, HttpCookieMode.AutoDetect, SessionStateMode.InProc, false);

            SessionStateUtility.AddHttpSessionStateToContext(httpContext, sessionContainer);

            return httpContext;
        }

        public MovieVotingHistoryDbContext Database()
        {
            MovieVotingHistoryDbContext database = new MovieVotingHistoryDbContext();

            MovieHistory Movie = new MovieHistory
            {
                ID = 1,
                MovieName = "Deadpool 2",
                NumberOfTimesChosen = 3
            };

            MovieHistory MovieTwo = new MovieHistory
            {
                ID = 2,
                MovieName = "Rush Hour",
                NumberOfTimesChosen = 5
            };

            RejectedMovieList MovieThree = new RejectedMovieList
            {
                ID = 1,
                Indecision_TrackerID = 1,
                MoviesSkipped = "Deadpool 2"
            };

            RejectedMovieList MovieFour = new RejectedMovieList
            {
                ID = 1,
                Indecision_TrackerID = 1,
                MoviesSkipped = "Rush Hour"
            };

            database.Database.Delete();
            database.Database.Create();
            var list = database.Movie.Count();
           

            database.Movie.Add(Movie);
            database.Movie.Add(MovieTwo);
            database.RejectedMovies.Add(MovieThree);
            database.RejectedMovies.Add(MovieFour);
            database.SaveChanges();

            return database;

        }
    }

}

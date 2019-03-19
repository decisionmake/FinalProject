using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProjectTest.Tests
{
    [TestClass()]
    public class FoodService_Tests
    {
        private FoodService _foodService = new FoodService();
        MockHelpers mock = new MockHelpers();
        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = mock.FakeHttpContext();

        }


        [TestMethod()]
        public void Index_Test()
        {
            //Arrange 
            string zip = "48083";


            //Act
            var restaurantsReturned = _foodService.Index(zip).Result;

            //Assert
            Assert.IsNotNull(restaurantsReturned.BusinessOne);
            Assert.IsNotNull(restaurantsReturned.BusinessTwo);
        }

        [TestMethod]
        public void TrackFood_Test()
        {

        }
    }
}
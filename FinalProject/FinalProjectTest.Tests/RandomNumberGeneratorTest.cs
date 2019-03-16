using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject.BLL;

namespace FinalProjectTest.Tests
{
    [TestClass]
    public class RandomNumberGeneratorTest
    {
        [TestMethod]
        public void GetNumberMovie_Test_MaxNumber()
        {
            //Arrange
            var testMaxNumber = 10;
            
            //Act
            int[] arrayReturned = RandomNumberGenerator.GetNumberMovie(testMaxNumber);

            //Asset
            Assert.IsTrue(arrayReturned[0] <= testMaxNumber);
            Assert.IsTrue(arrayReturned[1] <= testMaxNumber);

        }

        [TestMethod]
        public void GetNumberMovie_Test_NumbersNotEqual()
        {
            //Arrange
            var testMaxNumber = 10;

            //Act
            int[] arrayReturned = RandomNumberGenerator.GetNumberMovie(testMaxNumber);

            //Asset
            Assert.IsTrue(arrayReturned[0] != arrayReturned[1]);

        }

        [TestMethod]
        public void GetNumberApiPage_Test_NumberBetweenRange()
        {
            //Arrange
            var testMaxNumber = 10;
            var testMinNumber = 1;

            //Act
            var numberReturned = RandomNumberGenerator.GetNumberApiPage(testMaxNumber);

            //Asset
            Assert.IsTrue(numberReturned >= testMinNumber && numberReturned <= testMaxNumber);

        }

    }
}

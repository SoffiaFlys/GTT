using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTT.Entities;
using Moq;
using GTT.Models;

namespace GTT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConverterTest()
        {
            //arrange
            Mock<Tour> mock = new Mock<Tour>();
            var t = new TourView( mock.Object );
            //act
            var total = TourView.CurrencyConvert( "EUR", "USD" );
            var real = 0.8937M;
            //assert
            Assert.AreEqual( ( double ) real, ( double ) total );
        }
    }
}

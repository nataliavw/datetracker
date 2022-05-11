using NUnit.Framework;
using System.Collections.Generic;

namespace DateTracker.Tests
{
    public class ListClassTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewClassContainsEmptyList()
        {
            //Arrange
            var SUT = new ListClass();
            //Act
            List<DateEntry> result = SUT.GetList();
            //Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
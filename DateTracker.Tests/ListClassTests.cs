using DateTracker.DTOs;
using NUnit.Framework;
using System;
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

        [Test]
        public void AmendedClassContainsEntry()
        {
            //Arrange
            var SUT = new ListClass();
            DateEntry dateEntry = new DateEntry
            {
                date = DateTime.Parse("2001/01/01")
            };
            //Act
            SUT.Add(dateEntry);
            var result = SUT.GetList();
            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(dateEntry, result[0]);
        }


        [Test]
        public void FutureDatesThrowAnException()
        {
            //Arrange
            var SUT = new ListClass();
            var dateEntry = new DateEntry
            {
                date = DateTime.Now.AddDays(1)
            };
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Add(dateEntry));
            var result = SUT.GetList();
            Assert.AreEqual(0, result.Count);
        }
    }
}
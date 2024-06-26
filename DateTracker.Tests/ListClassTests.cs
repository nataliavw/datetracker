using DateTracker.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DateTracker.Tests
{
    public class DateRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewClassContainsEmptyList()
        {
            //Arrange
            var SUT = new DateRepository();
            //Act
            List<DateEntry> result = SUT.GetList();
            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void AmendedClassContainsEntry()
        {
            //Arrange
            var SUT = new DateRepository();
            DateEntry dateEntry = new DateEntry(DateTime.Parse("2001/01/01"));
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
            var SUT = new DateRepository();
            var dateEntry = new DateEntry(DateTime.Now.AddDays(1));
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Add(dateEntry));
            var result = SUT.GetList();
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void RandomisedClassContainsEntries()
        {
            //Arrange
            var SUT = new DateRepository();
            //Act
            SUT.Randomise();
            var result = SUT.GetList();
            //Assert
            Assert.AreEqual(50, result.Count);
        }

        [Test]
        public void GetDiffIsAccurate()
        {
            //Arrange
            var SUT = new DateRepository();
            var TestDate = DateTime.Now.AddDays(-5);
            TimeSpan lowerDateDiff = DateTime.Now - TestDate-TimeSpan.FromSeconds(1);
            TimeSpan upperDateDiff = DateTime.Now - TestDate+TimeSpan.FromSeconds(1);
            //Act
            var result = SUT.TimeElapsed(TestDate);
            //Assert
            Assert.IsTrue(result < upperDateDiff);
            Assert.IsTrue(result > lowerDateDiff);
        }

        [Test]
        public void SortingReturnsOrderedDates()
        {
            //Arrange
            var SUT = new DateRepository();
            DateEntry parsedDate1 = new DateEntry(DateTime.Parse("1/1/2000"));
            DateEntry parsedDate2 = new DateEntry(DateTime.Parse("2/2/2000"));
            DateEntry parsedDate3 = new DateEntry(DateTime.Parse("3/3/2000"));
            SUT.Add(parsedDate2);
            SUT.Add(parsedDate1);
            SUT.Add(parsedDate3);
            //Act
            var result = SUT.GetSortedDates();
            //Assert
            Assert.AreEqual(parsedDate1, result[0]);
            Assert.AreEqual(parsedDate2, result[1]);
            Assert.AreEqual(parsedDate3, result[2]);
        }

        [Test]
        public void MedianDateIsAccurate()
        {
            //Arrange
            var SUT = new DateRepository();
            DateEntry parsedDate1 = new DateEntry(DateTime.Parse("1/1/2000"));
            DateEntry parsedDate2 = new DateEntry(DateTime.Parse("2/2/2000"));
            DateEntry parsedDate3 = new DateEntry(DateTime.Parse("3/3/2000"));
            DateEntry expectedResult = new DateEntry(DateTime.Parse("3/3/2000"));
            DateEntry parsedDate4 = new DateEntry(DateTime.Parse("4/4/2000"));
            DateEntry parsedDate5 = new DateEntry(DateTime.Parse("5/5/2000"));
            DateEntry parsedDate6 = new DateEntry(DateTime.Parse("6/6/2000"));
            SUT.Add(parsedDate1);
            SUT.Add(parsedDate2);
            SUT.Add(parsedDate3);
            SUT.Add(expectedResult);
            SUT.Add(parsedDate4);
            SUT.Add(parsedDate5);
            SUT.Add(parsedDate6);
            //Act
            var result = SUT.GetMedianDateEntry();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
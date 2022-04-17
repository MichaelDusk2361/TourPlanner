using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL.Mock;
using TourPlanner.Model;

namespace TourPlanner.Test.DAL
{
    public class TestDBMock
    {

        [SetUp]
        public void Setup()
        {
            DBMock.Reset();
        }

        [Test]
        public void TestGetAll()
        {
            var currentDataCount = DBMock.GetMockData<Tour>().Count;
            Assert.AreEqual(expected: currentDataCount, actual: 5);
        }

        [Test]
        public void TestUpdate()
        {
            var currentData = (DBMock.GetMockData<Tour>()[0] as Tour).Description;
            var updatedData = new Tour(DBMock.GetMockData<Tour>()[0] as Tour) { Description = "123" };
            //test before update
            Assert.AreEqual(expected: currentData, actual: (DBMock.GetMockData<Tour>()[0] as Tour).Description);
            DBMock.Update(updatedData);
            //test after update
            Assert.AreNotEqual(expected: currentData, actual: (DBMock.GetMockData<Tour>()[0] as Tour).Description);
        }

        [Test]
        public void TestInsert()
        {
            var currentDataCount = DBMock.GetMockData<Tour>().Count;
            DBMock.Insert(new Tour());
            Assert.AreEqual(expected: currentDataCount + 1, actual: DBMock.GetMockData<Tour>().Count);
        }

        [Test]
        public void TestDelete()
        {
            var currentDataCount = DBMock.GetMockData<Tour>().Count;
            DBMock.Delete(new Tour() { Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7") });
            Assert.AreEqual(expected: currentDataCount - 1, actual: DBMock.GetMockData<Tour>().Count);
        }

    }
}

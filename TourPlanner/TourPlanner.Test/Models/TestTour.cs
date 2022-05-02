using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.Test.Models
{
    public class TestTour
    {
        [Test]
        public void TestTransportType_CantAssignInvalidValue()
        {
            var tour = new Tour();
            tour.TransportType = "abc";
            Assert.AreEqual(expected: "fastest", actual: tour.TransportType);
        }

        [Test]
        public void TestTransportType_CanAssignValidValue()
        {
            var tour = new Tour();
            tour.TransportType = "fastest";
            Assert.AreEqual(expected: "fastest", actual: tour.TransportType);

            tour.TransportType = "pedestrian";
            Assert.AreEqual(expected: "pedestrian", actual: tour.TransportType);

            tour.TransportType = "shortest";
            Assert.AreEqual(expected: "shortest", actual: tour.TransportType);
        }
    }
}

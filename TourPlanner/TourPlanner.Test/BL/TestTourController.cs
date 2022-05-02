using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Controller;
using TourPlanner.BL.Factory;
using TourPlanner.Common;
using TourPlanner.DAL.Mock;
using TourPlanner.Model;

namespace TourPlanner.Test.BL
{
    public class TestTourController
    {
        public IControllerFactory Factory { get; set; } = new ControllerFactoryMock();


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ConfigFile.Parse("AppConfig.json");
            Directory.CreateDirectory(ConfigFile.AppSettings("MapDir"));
        }

        [Test]
        public async Task TestUpdateTour_ChangesTourAndCreatesFile()
        {
            using (var controller = Factory.CreateTourController())
            {
                var tour = new Tour()
                {
                    Name = "2. Tour",
                    Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                };
                await controller.RequestAndUpdateTour(tour);
            }

            Assert.AreEqual(actual: (DBMock.GetMockData<Tour>()[0] as Tour).Name, expected: "2. Tour");
            Assert.IsTrue(File.Exists($"{ConfigFile.AppSettings("MapDir")}7c9e6679-7425-40de-944b-e07fc1f90ae7.png"));
        }

        [Test]
        public void TestSearch_IsCaseInsensitive()
        {
            var res = TourController.TourContainsString(new Tour()
            {
                Name = "1. Tour",
                Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
            }, "1. tour");

            Assert.IsTrue(res);
        }

        [Test]
        public void TestSearch_CanFindStringInTourLogs()
        {
            using var controller = Factory.CreateTourController();

            var res = controller.TourLogContainString(new Tour()
            {
                Name = "1. Tour",
                Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
            }, "abcde");

            Assert.IsTrue(res);
        }

        [Test]
        public void TestSearch_CantFindStringInTourLogs()
        {
            using var controller = Factory.CreateTourController();

            var res = controller.TourLogContainString(new Tour()
            {
                Name = "1. Tour",
                Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
            }, "abcdefg");

            Assert.IsFalse(res);
        }

        [OneTimeTearDown]
        public void RemoveMapsDir()
        {
            Directory.Delete(ConfigFile.AppSettings("MapDir"), true);
        }
    }
}

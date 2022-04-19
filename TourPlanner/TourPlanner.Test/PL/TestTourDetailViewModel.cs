using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TourPlanner.DAL.Mock;
using TourPlanner.Model;

namespace TourPlanner.Test.PL
{
    public class TestTourDetailViewModel : TestViewModelBase
    {
        [Test]
        public void TestPopularity_HasCorrectValue()
        {
            Tours.SelectedTour = Tours.AllTours[0];
            var childFriendliness = (from log in DBMock.GetMockData<TourLog>() where (log as TourLog).TourId == Tours.SelectedTour.Id select log).Count();
            Assert.AreEqual(actual: TourDetail.Popularity, expected: childFriendliness);
        }

        [Test]
        public void TestChildFriendliness_HasCorrectValue()
        {
            Tours.SelectedTour = Tours.AllTours[0];
            var logs = (from log in DBMock.GetMockData<TourLog>() where (log as TourLog).TourId == Tours.SelectedTour.Id select log).ToList();

            var difficultySum = 0;
            logs.ForEach(x => difficultySum += (x as TourLog).Difficulty);

            var childFriendliness =  difficultySum / logs.Count;
            Assert.AreEqual(actual: TourDetail.ChildFriendliness, expected: childFriendliness);
        }

        [Test]
        public void TestCancel_OriginalObjectIsNotAltered()
        {
            Tours.SelectedTour = Tours.AllTours[0];
            string selectedOriginal = JsonConvert.SerializeObject(Tours.SelectedTour);
            TourDetail.SelectedTour.Description = "235711131719";
            TourDetail.CancelChangesCommand.Execute(null);
            TourDetail.ApplyChangesCommand.Execute(null);
            Assert.AreEqual(expected: selectedOriginal, actual: JsonConvert.SerializeObject(Tours.SelectedTour));
        }

        [Test]
        public void TestApply_OriginalIsAltered()
        {
            Tours.SelectedTour = Tours.AllTours[0];
            Assert.AreNotEqual(expected: "Maps/7c9e6679-7425-40de-944b-e07fc1f90ae7.png", actual: TourDetail.SelectedTour.ImageUrl);
            TourDetail.ApplyChangesCommand.Execute(null);
            //the apply changes command contains async method and the wrapping execute method can not be awaited
            //causing test to fail
            //Thread.Sleep(100);
            Assert.AreEqual(expected: "Maps/7c9e6679-7425-40de-944b-e07fc1f90ae7.png", actual: Tours.SelectedTour.ImageUrl);
        }
    }
}

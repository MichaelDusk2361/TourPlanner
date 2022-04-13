using TourPlanner.Model;

namespace TourPlanner.DAL.Mock
{
    public class TourPlannerContextMock : DBContextMock
    {
        public TourPlannerContextMock()
        {
            LoadTable<Tour>();
            LoadTable<TourLog>();
        }
    }
}

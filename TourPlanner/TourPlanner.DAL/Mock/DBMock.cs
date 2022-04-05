using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.DAL.Mock
{
    public class DBMock
    {
        static public List<ITEntity> GetMockData<TEntity>() where TEntity : class, ITEntity
        {
            if (typeof(TEntity).IsAssignableFrom(typeof(Tour)))
            {
                return GetMockDataTour();
            }
            else if (typeof(TEntity).IsAssignableFrom(typeof(TourLog)))
            {
                return GetMockDataTourLog();
            }
            

            throw new NotImplementedException();
        }


        private static List<ITEntity> GetMockDataTour()
        {
            //maybe we need better data
            return new()
            {
                new Tour() { Name = "1. Tour" },
                new Tour() { Name = "2. Tour" },
                new Tour() { Name = "3. Tour" },
                new Tour() { Name = "4. Tour" },
                new Tour() { Name = "5. Tour" },
                new Tour() { Name = "6. Tour" },
                new Tour() { Name = "7. Tour" },
                new Tour() { Name = "8. Tour" },
                new Tour() { Name = "9. Tour" },
                new Tour() { Name = "10. Tour" },
            };
        }

        private static List<ITEntity> GetMockDataTourLog()
        {
            //maybe we need better data
            return new()
            {
                new TourLog(),
                new TourLog(),
                new TourLog(),
                new TourLog(),
                new TourLog(),
            };
        }
    }
}

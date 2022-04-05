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
                new Tour()
                {
                    Name = "1. Tour",
                    Id = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),                    
                },
                new Tour()
                {
                    Name = "2. Tour",
                    Id = new("8c9e6679-7425-40de-944b-e07fc1f90ae7"),
                },
                new Tour()
                {
                    Name = "3. Tour",
                    Id = new("9c9e6679-7425-40de-944b-e07fc1f90ae7"),
                },
                new Tour()
                {
                    Name = "4. Tour",
                    Id = new("ac9e6679-7425-40de-944b-e07fc1f90ae7"),
                },
                new Tour()
                {
                    Name = "5. Tour",
                    Id = new("bc9e6679-7425-40de-944b-e07fc1f90ae7"),
                },
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

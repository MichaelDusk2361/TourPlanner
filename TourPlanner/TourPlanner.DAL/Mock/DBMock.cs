using System.Reflection;
using TourPlanner.DAL.Exceptions;
using TourPlanner.Model;
using TourPlanner.Model.Attributes;

namespace TourPlanner.DAL.Mock
{
    public static class DBMock
    {

        static public Dictionary<string, List<ITEntity>> Data { get; private set; } = new()
        {
            { GetTableName(typeof(Tour)), CreateTourData() },
            { GetTableName(typeof(TourLog)), CreateTourLogData() },
        };

        static public void Update<TEntity>(TEntity entity) where TEntity : class, ITEntity
        {
            var target = (from e in Data[GetTableName(entity.GetType())] where e.Id == entity.Id select e).First();

            if (target.Version > entity.Version)
                throw new StaleObjectStateException(GetTableName(typeof(TEntity)));

            entity.Version++;

            if (target != null)
            {
                var sourceProperties = typeof(TEntity).GetProperties();
                foreach (var sourceProp in sourceProperties)
                {
                    var targetProp = entity.GetType().GetProperty(sourceProp.Name);
                    targetProp?.SetValue(target, sourceProp.GetValue(entity, null), null);
                }
            }
        }

        public static void Clear()
        {
            Data[GetTableName(typeof(Tour))] = new();
            Data[GetTableName(typeof(TourLog))] = new();
        }

        private static List<ITEntity> CreateTourData()
        {
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

        private static List<ITEntity> CreateTourLogData()
        {
            return new()
            {
                new TourLog()
                {
                    Id = new("7c9e6679-7425-40de-944b-e07fc1f91ae7"),
                    TourId = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    CompletionTime = 1234,
                    Comment = "abc",
                    Date = DateTime.Now,
                    Difficulty = 1,
                    Rating = 4,
                },
                new TourLog()
                {
                    Id = new("7c9e6679-7425-40df-944b-e07fc1f91ae7"),
                    TourId = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    CompletionTime = 1234,
                    Comment = "abcd",
                    Date = DateTime.Now,
                    Difficulty = 2,
                    Rating = 5,
                },
                new TourLog()
                {
                    Id = new("7c9e6679-7425-42de-944b-e07fc1f91ae7"),
                    TourId = new("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    CompletionTime = 1234,
                    Comment = "abcde",
                    Date = DateTime.Now,
                    Difficulty = 3,
                    Rating = 6,
                },
                new TourLog()
                {
                    Id = new("7c9e6679-7425-43de-944b-e07fc1f91ae7"),
                    TourId = new("8c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    CompletionTime = 1234,
                    Comment = "abcdef",
                    Date = DateTime.Now,
                    Difficulty = 4,
                    Rating = 7,
                },
                new TourLog()
                {
                    Id = new("7c9e6679-7425-44de-944b-e07fc1f91ae7"),
                    TourId = new("8c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    CompletionTime = 1234,
                    Comment = "abcdefg",
                    Date = DateTime.Now,
                    Difficulty = 5,
                    Rating = 8,
                },
            };
        }

        static public void Reset()
        {
            Data[GetTableName(typeof(Tour))] = CreateTourData();
            Data[GetTableName(typeof(TourLog))] = CreateTourLogData();
        }

        static public void Delete<TEntity>(TEntity entity) where TEntity : class, ITEntity
        {
            Data[GetTableName(entity.GetType())].RemoveAll(e => e.Id == entity.Id);
        }

        static public void Insert<TEntity>(TEntity entity) where TEntity : class, ITEntity
        {
            Data[GetTableName(entity.GetType())].Add(entity);
        }

        static public List<ITEntity> GetMockData<TEntity>() where TEntity : class, ITEntity
        {
            return new(Data[GetTableName(typeof(TEntity))]);
        }

        private static string GetTableName(Type entityType)
        {
            var res = entityType.GetCustomAttribute<DataSourceAttribute>(false)?.TableName;
            if (res == null)
                throw new ArgumentException($"Could not get table name of {entityType.Name}");
            return res;
        }
    }
}

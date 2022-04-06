using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;
using TourPlanner.Model.Attributes;

namespace TourPlanner.DAL.Mock
{
    public class DBMock
    {
        //tooDo:
        //get all entries should work like orm using data source attribute of ITEntity
        //add insert, update and delete for in memory data

        static public Dictionary<string, List<ITEntity>> Data { get; private set; } = new()
        {
            {
                GetTableName(typeof(Tour)),
                new()
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
                }
            },

            {
                GetTableName(typeof(TourLog)),
                new()
                {
                    new TourLog(),
                    new TourLog(),
                    new TourLog(),
                    new TourLog(),
                    new TourLog(),
                }
            }
        };


        static public List<ITEntity> GetMockData<TEntity>() where TEntity : class, ITEntity
        {
            return Data[GetTableName(typeof(TEntity))] as List<ITEntity>;
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

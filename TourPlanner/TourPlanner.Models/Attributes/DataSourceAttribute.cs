using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Model.Attributes {
    [AttributeUsage(AttributeTargets.Class)]
    public class DataSourceAttribute : Attribute {
        public string TableName { get; private set; }

        public DataSourceAttribute(string tableName) {
            TableName = tableName;
        }
    }
}

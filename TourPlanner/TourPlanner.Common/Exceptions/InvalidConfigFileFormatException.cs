using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Common.Exceptions
{
    public class InvalidConfigFileFormatException : Exception
    {
        public InvalidConfigFileFormatException() : base()
        {

        }

        public InvalidConfigFileFormatException(string message) : base(message)
        {

        }

        public InvalidConfigFileFormatException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

namespace TourPlanner.DAL.Exceptions
{
    public class DBConnectionException : Exception
    {

        public DBConnectionException() { }

        public DBConnectionException(string message) : base(message) { }

        public DBConnectionException(string message, Exception inner) : base(message, inner) { }
    }
}

namespace TourPlanner.DAL.Exceptions
{
    class OrmException : Exception
    {

        public OrmException() { }

        public OrmException(string message) : base(message) { }

        public OrmException(string message, Exception inner) : base(message, inner) { }
    }
}

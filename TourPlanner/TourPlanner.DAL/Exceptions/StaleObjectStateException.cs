namespace TourPlanner.DAL.Exceptions
{
    class StaleObjectStateException : Exception
    {
        public StaleObjectStateException() { }

        public StaleObjectStateException(string message) : base(message) { }

        public StaleObjectStateException(string message, Exception inner) : base(message, inner) { }
    }
}

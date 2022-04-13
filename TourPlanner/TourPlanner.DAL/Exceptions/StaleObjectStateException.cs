namespace TourPlanner.DAL.Exceptions
{
    public class StaleObjectStateException : Exception
    {
        public StaleObjectStateException() { }

        public StaleObjectStateException(string message) : base(message) { }

        public StaleObjectStateException(string message, Exception inner) : base(message, inner) { }
    }
}

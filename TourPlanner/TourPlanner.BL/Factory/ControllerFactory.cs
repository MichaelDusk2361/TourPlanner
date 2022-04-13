using TourPlanner.BL.Controller;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.Common.Logging;
using TourPlanner.DAL;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactory : IControllerFactory
    {
        private static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

        public TourController CreateTourController()
        {
            try
            {
                var uow = new UnitOfWork();
                var mapquestapi = new MapQuestAPIRequest();
                return new(uow, mapquestapi);
            }
            catch (KeyNotFoundException)
            {
                s_logger.Fatal("Config file is missing parameters for db connection");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                s_logger.Fatal("Could not connect to DB");
                Environment.Exit(1);
            }
            return null;
        }

        public TourLogController CreateTourLogController()
        {
            try
            {
                var uow = new UnitOfWork();
                var mapquestapi = new MapQuestAPIRequest();
                return new(uow, mapquestapi);
            }
            catch (KeyNotFoundException)
            {
                s_logger.Fatal("Config file is missing parameters for db connection");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                s_logger.Fatal("Could not connect to DB");
                Environment.Exit(1);
            }
            return null;
        }
    }
}

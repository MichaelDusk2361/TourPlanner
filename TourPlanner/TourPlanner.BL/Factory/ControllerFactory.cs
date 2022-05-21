using TourPlanner.BL.Controller;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.Common.Logging;
using TourPlanner.DAL;
using TourPlanner.DAL.Context;
using TourPlanner.DAL.Exceptions;
using TourPlanner.DAL.Mock;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactory : IControllerFactory
    {
        private static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

        public ControllerFactory()
        {
            DBMock.Clear();
        }


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
            catch (DBConnectionException)
            {
                if(!DBContext.InitialConnectionAttemptFailed)
                    s_logger.Error("Could not connect to DB");
                DBContext.InitialConnectionAttemptFailed = true;

                try
                {
                    var uow = new UnitOfWorkMock();
                    var mapquestapi = new MapQuestAPIRequest();
                    return new(uow, mapquestapi);
                }
                catch
                {
                    s_logger.Fatal("Could not use fallback in memory db");
                    Environment.Exit(1);
                }
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
            catch (DBConnectionException)
            {
                if (!DBContext.InitialConnectionAttemptFailed)
                    s_logger.Error("Could not connect to DB");

                DBContext.InitialConnectionAttemptFailed = true;
                try
                {
                    var uow = new UnitOfWorkMock();
                    var mapquestapi = new MapQuestAPIRequest();
                    return new(uow, mapquestapi);
                }
                catch
                {
                    s_logger.Fatal("Could not use fallback in memory db");
                    Environment.Exit(1);
                }
            }
            return null;
        }
    }
}

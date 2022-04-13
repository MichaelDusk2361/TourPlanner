using System.IO;
using System.Windows;
using TourPlanner.BL.Factory;
using TourPlanner.Common;
using TourPlanner.Common.Logging;
using TourPlanner.PL.ViewModel.Main;
using TourPlanner.PL.ViewModel.Sub;

namespace TourPlanner.PL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        private static ILoggerWrapper logger = LoggerFactory.GetLogger();

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {

            logger.Debug("This is a debug message.");
            logger.Fatal("This is a fatal message.");
            logger.Warn("This is a warning message.");
            logger.Error("This is an error message.");

            ConfigFile.Parse("AppConfig.json");

            Directory.CreateDirectory(ConfigFile.AppSettings("MapDir"));

            var searchBarViewModel = new SearchBarViewModel();
            var toursViewModel = new ToursViewModel();
            var tourDetailViewModel = new TourDetailViewModel();
            var menuBarViewModel = new MenuBarViewModel();
            var logsViewModel = new LogsViewModel();
            var controllerFactory = CreateControllerFactory();
            var mainViewModel = new MainViewModel(searchBarViewModel, toursViewModel, tourDetailViewModel, menuBarViewModel, logsViewModel, controllerFactory);

            var window = new MainWindow
            {
                DataContext = mainViewModel,
                SearchBarView = { DataContext = searchBarViewModel },
                ToursView = { DataContext = toursViewModel },
                TourDetailView = { DataContext = tourDetailViewModel },
                MenuBarView = { DataContext = menuBarViewModel },
                LogsView = { DataContext = logsViewModel },
            };

            window.Show();
        }

        private static IControllerFactory CreateControllerFactory()
        {
            return ConfigFile.AppSettings("ProductionEnvironment") == "true" ? new ControllerFactory() : new ControllerFactoryMock();
        }
    }
}

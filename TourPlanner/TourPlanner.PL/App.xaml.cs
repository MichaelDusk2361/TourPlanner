using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using TourPlanner.BL.Factory;
using TourPlanner.Common;
using TourPlanner.Common.Exceptions;
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
        private static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {

            try
            {
                ConfigFile.Parse("AppConfig.json");
            }
            catch (InvalidConfigFileFormatException)
            {
                s_logger.Fatal("Could not parse config file due to invalid format");
                Environment.Exit(1);
            }
            catch (FileNotFoundException)
            {
                s_logger.Fatal("Config file not found");
                Environment.Exit(1);
            }


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

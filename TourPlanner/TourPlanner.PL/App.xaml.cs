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


        public SearchBarViewModel searchBarViewModel { get; set; }
        public ToursViewModel toursViewModel { get; set; }
        public TourDetailViewModel tourDetailViewModel { get; set; }
        public MenuBarViewModel menuBarViewModel { get; set; }
        public LogsViewModel logsViewModel { get; set; }
        public IControllerFactory controllerFactory { get; set; }
        public MainViewModel mainViewModel { get; set; }

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

            searchBarViewModel = new SearchBarViewModel();
            toursViewModel = new ToursViewModel();
            tourDetailViewModel = new TourDetailViewModel();
            menuBarViewModel = new MenuBarViewModel();
            logsViewModel = new LogsViewModel();
            controllerFactory = CreateControllerFactory();
            mainViewModel = new MainViewModel(searchBarViewModel, toursViewModel, tourDetailViewModel, menuBarViewModel, logsViewModel, controllerFactory);

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

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                controllerFactory.CreateTourController().ExportIfInMemoryDBIsUsed(null);
            }
            finally
            {
                base.OnExit(e);
            }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            return ConfigFile.AppSettings("ProductionEnvironment") == "true" ? new ControllerFactory() : new ControllerFactoryMock();
        }
    }
}

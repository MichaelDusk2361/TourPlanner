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


        public SearchBarViewModel SearchBarViewModel { get; set; }
        public ToursViewModel ToursViewModel { get; set; }
        public TourDetailViewModel TourDetailViewModel { get; set; }
        public MenuBarViewModel MenuBarViewModel { get; set; }
        public LogsViewModel LogsViewModel { get; set; }
        public IControllerFactory ControllerFactory { get; set; }
        public MainViewModel MainViewModel { get; set; }

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

            SearchBarViewModel = new SearchBarViewModel();
            ToursViewModel = new ToursViewModel();
            TourDetailViewModel = new TourDetailViewModel();
            MenuBarViewModel = new MenuBarViewModel();
            LogsViewModel = new LogsViewModel();
            ControllerFactory = CreateControllerFactory();
            MainViewModel = new MainViewModel(SearchBarViewModel, ToursViewModel, TourDetailViewModel, MenuBarViewModel, LogsViewModel, ControllerFactory);

            var window = new MainWindow
            {
                DataContext = MainViewModel,
                SearchBarView = { DataContext = SearchBarViewModel },
                ToursView = { DataContext = ToursViewModel },
                TourDetailView = { DataContext = TourDetailViewModel },
                MenuBarView = { DataContext = MenuBarViewModel },
                LogsView = { DataContext = LogsViewModel },
            };

            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                ControllerFactory.CreateTourController().ExportIfInMemoryDBIsUsed(null);
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

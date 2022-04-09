using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner.BL.Factory;
using TourPlanner.Common;
using TourPlanner.PL.ViewModel;
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
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
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
            var useProductionDatabase = ConfigFile.Parse("AppConfig.json")?["ProductionDatabase"] == "true";
            return useProductionDatabase ? new ControllerFactory() : new ControllerFactoryMock();
        }
    }
}

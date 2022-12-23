using BusinessLogicLayer.Interfaces;
using Ninject;
using Share_Class.Global;
using Share_Class.Utils;
using Share_Class.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Share_Class
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations());

            IDbDataOperations dbDataOperations = kernel.Get<IDbDataOperations>();

            GlobalSettings.dbDataOperations = dbDataOperations;
            GlobalSettings.NotifyModels = new INotifyModels.NotifyModels();
            GlobalSettings.NotifyModels.Load(dbDataOperations);

            MainWindow view = new MainWindow();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}

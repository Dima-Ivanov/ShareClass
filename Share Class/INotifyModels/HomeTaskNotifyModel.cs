using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Views;
using Share_Class.ViewModels;

namespace Share_Class.INotifyModels
{
    public class HomeTaskNotifyModel : INotifyBase
    {
        public HomeTaskNotifyModel(HomeTaskModel homeTaskModel)
        {
            OpenHomeTaskCommand = new DelegateCommand(OpenHomeTaskCommandHandler);

            this.homeTaskModel = homeTaskModel;

            Name = homeTaskModel.Name;
            Deadline_Date = homeTaskModel.Deadline_Date;
        }

        private HomeTaskModel homeTaskModel;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime _deadlineDate;
        public DateTime Deadline_Date
        {
            get
            {
                return _deadlineDate;
            }
            set
            {
                _deadlineDate = value;
                OnPropertyChanged("Deadline_Date");
            }
        }

        public DelegateCommand OpenHomeTaskCommand { get; }
        private void OpenHomeTaskCommandHandler()
        {
            HomeTask view = new HomeTask();
            HomeTaskViewModel vm = new HomeTaskViewModel();
            vm.InitializeHomeTask(this.homeTaskModel);
            view.DataContext = vm;
            view.Show();
        }
    }
}

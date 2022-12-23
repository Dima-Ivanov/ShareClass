using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Share_Class.ViewModels
{
    public class CreateHomeTaskViewModel : INotifyBase
    {
        private ClassRoomModel classRoomModel;

        public CreateHomeTaskViewModel()
        {
            CreateHomeTaskCommand = new DelegateCommand<object>(CreateHomeTaskCommandHandler);
        }

        public void InitializeViewModel(ClassRoomModel classRoomModel)
        {
            this.classRoomModel = classRoomModel;
        }

        private string _name = "";
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

        private string _description = "";
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _deadline = DateTime.Now.ToString();
        public string DeadLine
        {
            get
            {
                return _deadline;
            }
            set
            {
                _deadline = value;
                OnPropertyChanged("DeadLine");
            }
        }

        public DelegateCommand<object> CreateHomeTaskCommand { get; }
        private void CreateHomeTaskCommandHandler(object param)
        {
            if (_name == string.Empty || _description == string.Empty || _deadline == string.Empty)
            {
                return;
            }

            var newHomeTask = new HomeTaskModel();
            newHomeTask.Name = _name;
            newHomeTask.Description = _description;
            newHomeTask.Creation_Date = DateTime.Now;

            if (DateTime.TryParse(_deadline, out var deadlineDateTime))
            {
                newHomeTask.Deadline_Date = deadlineDateTime;
            }
            else
            {
                return;
            }

            newHomeTask.ClassRoom_ID = classRoomModel.ID;

            if (param is Window window)
            {
                GlobalSettings.dbDataOperations.AddHomeTask(newHomeTask);
                GlobalSettings.NotifyModels.HomeTaskNotifyModels.Add(new INotifyModels.HomeTaskNotifyModel(newHomeTask));

                window.Close();
            }
        }
    }
}

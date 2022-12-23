using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share_Class.MVVM;
using BusinessLogicLayer.Models;
using Share_Class.INotifyModels;
using Prism.Commands;
using System.Windows;
using Share_Class.Global;

namespace Share_Class.ViewModels
{
    public class JoinClassConfirmViewModel : INotifyBase
    {
        public JoinClassConfirmViewModel()
        {
            JoinCommand = new DelegateCommand<object>(JoinCommandHandler);
            CloseCommand = new DelegateCommand<object>(CloseCommandHandler);
        }

        public void InitializeViewModel(ClassRoomModel classRoomModel)
        {
            this.classRoomModel = classRoomModel;
            this.ClassRoomIModel = new ClassRoomNotifyModel(classRoomModel);
            this.Teacher = "";
            this.Students = "";
        }

        private ClassRoomModel classRoomModel;

        private ClassRoomNotifyModel _classRoomIModel;

        public ClassRoomNotifyModel ClassRoomIModel
        {
            get
            {
                return _classRoomIModel;
            }
            set
            {
                _classRoomIModel = value;
                OnPropertyChanged("ClassRoomIModel");
            }
        }

        public string Teacher
        {
            get
            {
                return "Teacher: " + _classRoomIModel?.Teacher_Name;
            }
            set
            {
                OnPropertyChanged("Teacher");
            }
        }

        public string Students
        {
            get
            {
                return "Students: " + _classRoomIModel?.Students_Count.ToString();
            }
            set
            {
                OnPropertyChanged("Students");
            }
        }

        public DelegateCommand<object> JoinCommand { get; }
        private void JoinCommandHandler(object param)
        {
            var newClassRoomsUsers = new ClassRoomsUsersModel();
            newClassRoomsUsers.ClassRoom_ID = classRoomModel.ID;
            newClassRoomsUsers.User_ID = GlobalSettings.CurentUser.ID;

            foreach (var link in GlobalSettings.dbDataOperations.ClassRoomsUsersModels)
            {
                if (link.User_ID == newClassRoomsUsers.User_ID && link.ClassRoom_ID == newClassRoomsUsers.ClassRoom_ID)
                {
                    if (param is Window window)
                    {
                        window.Close();
                    }
                    return;
                }
            }

            if (param is Window window1)
            {
                GlobalSettings.dbDataOperations.AddClassRoomsUsers(newClassRoomsUsers);
                window1.Close();
            }
        }

        public DelegateCommand<object> CloseCommand { get; }
        private void CloseCommandHandler(object param)
        {
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}

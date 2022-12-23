using Prism.Commands;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Share_Class.Global;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer;

namespace Share_Class.ViewModels
{
    public class CreateClassViewModel : INotifyBase
    {
        public CreateClassViewModel() 
        {
            CreateClassButtonClickCommand = new DelegateCommand<object>(CreateClassButtonClickCommandHandler);
        }

        public DelegateCommand<object> CreateClassButtonClickCommand { get; }

        private void CreateClassButtonClickCommandHandler(object param)
        {
            if (_name == string.Empty)
            {
                return;
            }

            if (param is Window window)
            {
                var newClassRoom = new ClassRoomModel();
                newClassRoom.Name = _name;
                newClassRoom.InvitationCode = Guid.NewGuid();
                newClassRoom.Description = _description;
                newClassRoom.Teacher_Name = _teacherName;
                newClassRoom.Students_Count = 1;
                newClassRoom.Creation_Date = DateTime.Now;
                newClassRoom.Administrator_ID = GlobalSettings.CurentUser.ID;

                GlobalSettings.dbDataOperations.AddClassRoom(newClassRoom);

                var classRoomsUsersModel = new ClassRoomsUsersModel();
                classRoomsUsersModel.User_ID = GlobalSettings.CurentUser.ID;
                classRoomsUsersModel.ClassRoom_ID = newClassRoom.ID;
                GlobalSettings.dbDataOperations.AddClassRoomsUsers(classRoomsUsersModel);

                GlobalSettings.NotifyModels.ClassRoomNotifyModels.Add(new INotifyModels.ClassRoomNotifyModel(newClassRoom));

                window.Close();
            }
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

        private string _teacherName = "";
        public string Teacher_Name
        {
            get
            {
                return _teacherName;
            }
            set
            {
                _teacherName = value;
                OnPropertyChanged("Teacher_Name");
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
    }
}

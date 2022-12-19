using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.MVVM;
using Share_Class.Views;
using Share_Class.ViewModels;

namespace Share_Class.INotifyModels
{
    public class ClassRoomIModel : INotifyBase
    {
        public ClassRoomIModel(ClassRoomModel classRoomModel) 
        {
            OpenClassRoomCommand = new DelegateCommand(OpenClassRoomCommandHandler);

            this.classRoomModel = classRoomModel;

            this.Name = classRoomModel.Name;
            this.Teacher_Name = classRoomModel.Teacher_Name;
        }

        private ClassRoomModel classRoomModel;

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

        private string _teacherName;
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

        public DelegateCommand OpenClassRoomCommand { get; }
        private void OpenClassRoomCommandHandler()
        {
            ClassRoom classRoom = new ClassRoom();

            ClassRoomViewModel classRoomViewModel = new ClassRoomViewModel();
            classRoomViewModel.InitializeClassRoom(this.classRoomModel);
            classRoom.DataContext = classRoomViewModel;

            classRoom.Show();
        }
    }
}

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
    public class ClassRoomNotifyModel : INotifyBase
    {
        public ClassRoomNotifyModel(ClassRoomModel classRoomModel) 
        {
            OpenClassRoomCommand = new DelegateCommand(OpenClassRoomCommandHandler);

            this.classRoomModel = classRoomModel;

            this.ID = classRoomModel.ID;
            this.Name = classRoomModel.Name;
            this.Teacher_Name = classRoomModel.Teacher_Name;
            this.Description = classRoomModel.Description;
            this.Students_Count = classRoomModel.Students_Count;
        }

        private ClassRoomModel classRoomModel;

        public int ID { get; set; }

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

        private string _description;
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

        private int _studentsCount;
        public int Students_Count
        {
            get
            {
                return _studentsCount;
            }
            set
            {
                _studentsCount = value;
                OnPropertyChanged("_studentsCount");
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

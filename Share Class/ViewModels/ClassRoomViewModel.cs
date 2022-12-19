using BusinessLogicLayer.Models;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.ViewModels
{
    public class ClassRoomViewModel : INotifyBase
    {
        public void InitializeClassRoom(ClassRoomModel classRoomModel)
        {
            this.classRoomModel = classRoomModel;
            Name = classRoomModel.Name;
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
    }
}

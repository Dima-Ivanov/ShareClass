using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.INotifyModels
{
    public class NotifyModels
    {
        public NotifyModels()
        {
            ClassRoomNotifyModels = new ObservableCollection<ClassRoomNotifyModel>();
            HomeTask_FileNotifyModels = new ObservableCollection<HomeTask_FileNotifyModel>();
            HomeTaskNotifyModels = new ObservableCollection<HomeTaskNotifyModel>();
            Solution_FileNotifyModels = new ObservableCollection<Solution_FileNotifyModel>();
            SolutionNotifyModels = new ObservableCollection<SolutionNotifyModel>();
            UserNotifyModels = new ObservableCollection<UserNotifyModel>();
        }

        public void Load(IDbDataOperations dbDataOperations)
        {
            foreach (var model in dbDataOperations.ClassRoomModels)
            {
                ClassRoomNotifyModels.Add(new ClassRoomNotifyModel(model));
            }
            foreach (var model in dbDataOperations.HomeTask_FileModels)
            {
                HomeTask_FileNotifyModels.Add(new HomeTask_FileNotifyModel(model));
            }
            foreach (var model in dbDataOperations.HomeTaskModels)
            {
                HomeTaskNotifyModels.Add(new HomeTaskNotifyModel(model));
            }
            foreach (var model in dbDataOperations.Solution_FileModels)
            {
                Solution_FileNotifyModels.Add(new Solution_FileNotifyModel(model));
            }
            foreach (var model in dbDataOperations.SolutionModels)
            {
                SolutionNotifyModels.Add(new SolutionNotifyModel(model));
            }
            foreach (var model in dbDataOperations.UserModels)
            {
                UserNotifyModels.Add(new UserNotifyModel(model));
            }
        }

        public ObservableCollection<ClassRoomNotifyModel> ClassRoomNotifyModels { get; set; }
        public ObservableCollection<HomeTask_FileNotifyModel> HomeTask_FileNotifyModels { get; set; }
        public ObservableCollection<HomeTaskNotifyModel> HomeTaskNotifyModels { get; set; }
        public ObservableCollection<Solution_FileNotifyModel> Solution_FileNotifyModels { get; set; }
        public ObservableCollection<SolutionNotifyModel> SolutionNotifyModels { get; set; }
        public ObservableCollection<UserNotifyModel> UserNotifyModels { get; set; }
    }
}

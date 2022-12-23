using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.INotifyModels;
using Share_Class.MVVM;
using Share_Class.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.ViewModels
{
    public class ClassRoomViewModel : INotifyBase
    {
        private ClassRoomModel classRoomModel;

        public ClassRoomViewModel() 
        {
            CreateHomeTaskCommand = new DelegateCommand(CreateHomeTaskCommandHandler);
            OnSearchTextInputCommand = new DelegateCommand(OnSearchTextInputCommandHandler);

        }

        public void InitializeClassRoom(ClassRoomModel classRoomModel)
        {
            this.classRoomModel = classRoomModel;
            Name = classRoomModel.Name;
            Code = classRoomModel.InvitationCode.ToString();

            LoadUsers();
            LoadHomeTasks();
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<UserNotifyModel>();

            Dictionary<int, UserModel> idToUser = new Dictionary<int, UserModel>();
            foreach (var user in GlobalSettings.dbDataOperations.UserModels)
            {
                idToUser.Add(user.ID, user);
            }

            foreach (var classRoomsToUsers in GlobalSettings.dbDataOperations.ClassRoomsUsersModels.Where(i => i.ClassRoom_ID == classRoomModel.ID))
            {
                Users.Add(new UserNotifyModel(idToUser[classRoomsToUsers.User_ID]));
            }

            foreach (var user in Users)
            {
                user.CalculateScore(this.classRoomModel.ID);
            }

            Users = new ObservableCollection<UserNotifyModel>(Users.OrderByDescending(i => i.Score));
        }

        private void LoadHomeTasks()
        {
            HomeTasks = new ObservableCollection<HomeTaskNotifyModel>();

            foreach (var task in GlobalSettings.dbDataOperations.HomeTaskModels.Where(i => i.ClassRoom_ID == classRoomModel.ID))
            {
                HomeTasks.Add(new HomeTaskNotifyModel(task));
            }

            ShownHomeTasks = HomeTasks;
        }

        public DelegateCommand CreateHomeTaskCommand { get; }

        private void CreateHomeTaskCommandHandler()
        {
            CreateHomeTaskDialog createHomeTaskDialog = new CreateHomeTaskDialog();
            CreateHomeTaskViewModel createHomeTaskViewModel = new CreateHomeTaskViewModel();
            createHomeTaskViewModel.InitializeViewModel(this.classRoomModel);
            createHomeTaskDialog.DataContext = createHomeTaskViewModel;
            createHomeTaskDialog.ShowDialog();

            LoadHomeTasks();
        }


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

        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        private ObservableCollection<UserNotifyModel> _users;
        public ObservableCollection<UserNotifyModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        private ObservableCollection<HomeTaskNotifyModel> _homeTasks;
        public ObservableCollection<HomeTaskNotifyModel> HomeTasks
        {
            get
            {
                return _homeTasks;
            }
            set
            {
                _homeTasks = value;
                OnPropertyChanged("HomeTasks");
            }
        }

        private ObservableCollection<HomeTaskNotifyModel> _shownHomeTasks;
        public ObservableCollection<HomeTaskNotifyModel> ShownHomeTasks
        {
            get
            {
                return _shownHomeTasks;
            }
            set
            {
                _shownHomeTasks = value;
                OnPropertyChanged("ShownHomeTasks");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public DelegateCommand OnSearchTextInputCommand { get; }
        private void OnSearchTextInputCommandHandler()
        {
            if (_searchText == string.Empty)
            {
                ShownHomeTasks = HomeTasks;
            }
            else
            {
                var newShownHomeTasks = new ObservableCollection<HomeTaskNotifyModel>();

                var lowerSearch = _searchText.ToLower();

                foreach (var homeTask in HomeTasks)
                {
                    var lowerName = homeTask.Name.ToLower();

                    if (lowerName.Contains(lowerSearch))
                    {
                        newShownHomeTasks.Add(homeTask);
                    }
                }

                ShownHomeTasks = newShownHomeTasks;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.IO;
using System.Windows;
using Share_Class.MVVM;
using Share_Class.INotifyModels;
using BusinessLogicLayer.Models;
using Share_Class.Views;
using Share_Class.Global;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer;

namespace Share_Class.ViewModels
{
    public class MainWindowViewModel : INotifyBase
    {
        private IDbDataOperations dbDataOperations;
        private NotifyModels notifyModels;

        public MainWindowViewModel()
        {
            LogInDialog logInDialog = new LogInDialog();
            LogInViewModel logInViewModel = new LogInViewModel();
            logInDialog.DataContext = logInViewModel;
            logInDialog.ShowDialog();

            this.dbDataOperations = GlobalSettings.dbDataOperations;
            this.notifyModels = GlobalSettings.NotifyModels;

            UserName = GlobalSettings.CurentUser.Login;

            OnSearchTextInputCommand = new DelegateCommand(OnSearchTextInputCommandHandler);
            SearchClassRoomCommand = new DelegateCommand(SearchClassRoomCommandHandler);
            CreateClassRoomCommand = new DelegateCommand(CreateClassRoomCommandHandler);

            LoadClassRooms();

            LoadHomeTasks();
        }

        private void LoadHomeTasks()
        {
            HomeTasks = new ObservableCollection<HomeTaskNotifyModel>();

            HashSet<int> classRoomsIDs = new HashSet<int>();

            foreach(var classRoom in ClassRooms)
            {
                classRoomsIDs.Add(classRoom.ID);
            }

            foreach (var task in GlobalSettings.dbDataOperations.HomeTaskModels)
            {
                if (classRoomsIDs.Contains(task.ClassRoom_ID) && task.Deadline_Date > DateTime.Now)
                {
                    HomeTasks.Add(new HomeTaskNotifyModel(task));
                }
            }

            HomeTasks = new ObservableCollection<HomeTaskNotifyModel>(HomeTasks.OrderBy(i => i.Deadline_Date).ThenBy(i => i.Name));
        }

        private void LoadClassRooms()
        {
            ClassRooms = new ObservableCollection<ClassRoomNotifyModel>();

            Dictionary<int, ClassRoomNotifyModel> dict = new Dictionary<int, ClassRoomNotifyModel>();

            foreach (var classRoom in notifyModels.ClassRoomNotifyModels)
            {
                dict.Add(classRoom.ID, classRoom);
            }

            foreach (var classRoomsUsers in dbDataOperations.ClassRoomsUsersModels.Where(i => i.User_ID == GlobalSettings.CurentUser.ID))
            {
                ClassRooms.Add(dict[classRoomsUsers.ClassRoom_ID]);
            }

            ShownClassRooms = ClassRooms;
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

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ObservableCollection<ClassRoomNotifyModel> _classRooms;
        public ObservableCollection<ClassRoomNotifyModel> ClassRooms
        {
            get
            {
                return _classRooms;
            }
            set
            {
                _classRooms = value;
                OnPropertyChanged("ClassRooms");
            }
        }

        private ObservableCollection<ClassRoomNotifyModel> _shownClassRooms;
        public ObservableCollection<ClassRoomNotifyModel> ShownClassRooms
        {
            get
            {
                return _shownClassRooms;
            }
            set
            {
                _shownClassRooms = new ObservableCollection<ClassRoomNotifyModel>(value.OrderBy(c => c.Name).ThenBy(c => c.Teacher_Name));
                OnPropertyChanged("ShownClassRooms");
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
                _homeTasks = new ObservableCollection<HomeTaskNotifyModel>(value.OrderBy(h => h.Deadline_Date));
                OnPropertyChanged("HomeTasks");
            }
        }

        public DelegateCommand OnSearchTextInputCommand { get; }
        private void OnSearchTextInputCommandHandler()
        {
            if (_searchText == string.Empty)
            {
                ShownClassRooms = ClassRooms;
            }
            else
            {
                var newShownClassRooms = new ObservableCollection<ClassRoomNotifyModel>();

                var lowerSearch = _searchText.ToLower();

                foreach (var classRoom in ClassRooms)
                {
                    var lowerName = classRoom.Name.ToLower();
                    var lowerTeacherName = classRoom.Teacher_Name.ToLower();
                   
                    if (lowerName.Contains(lowerSearch) || lowerTeacherName.Contains(lowerSearch))
                    {
                        newShownClassRooms.Add(classRoom);
                    }
                }

                ShownClassRooms = newShownClassRooms;
            }
        }

        public DelegateCommand SearchClassRoomCommand { get; }
        private void SearchClassRoomCommandHandler()
        {
            JoinClassDialog joinClassDialog = new JoinClassDialog();
            joinClassDialog.DataContext = new JoinClassViewModel();
            joinClassDialog.ShowDialog();

            LoadClassRooms();
            LoadHomeTasks();
        }

        public DelegateCommand CreateClassRoomCommand { get; }
        private void CreateClassRoomCommandHandler()
        {
            CreateClassDialog createClassDialog = new CreateClassDialog();
            createClassDialog.DataContext = new CreateClassViewModel();
            createClassDialog.ShowDialog();
            
            LoadClassRooms();
        }

        //Stream[] checkStream = null;
        //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        //dlg.Multiselect = true;
        //Nullable<bool> result = dlg.ShowDialog();

        //if (result == true)
        //{
        //    try
        //    {
        //        if ((checkStream = dlg.OpenFiles()) != null)
        //        {
        //            string[] filenames = dlg.FileNames;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        //    }

        //}
    }
}

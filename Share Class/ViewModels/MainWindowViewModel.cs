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

namespace Share_Class.ViewModels
{
    public class MainWindowViewModel : INotifyBase
    {
        public MainWindowViewModel()
        {
            OnSearchTextInputCommand = new DelegateCommand(OnSearchTextInputCommandHandler);
            SearchClassRoomCommand = new DelegateCommand(SearchClassRoomCommandHandler);
            CreateClassRoomCommand = new DelegateCommand(CreateClassRoomCommandHandler);

            ClassRooms = new ObservableCollection<ClassRoomIModel>();
            HomeTasks = new ObservableCollection<HomeTaskIModel>();

            ClassRoomModel classRoomModel = new ClassRoomModel();
            classRoomModel.Name = "Test Class";
            classRoomModel.Teacher_Name = "Fomina";

            ClassRoomModel classRoomModel1 = new ClassRoomModel();
            classRoomModel1.Name = "Test Class1";
            classRoomModel1.Teacher_Name = "Dimas";

            ClassRooms.Add(new ClassRoomIModel(classRoomModel));
            ClassRooms.Add(new ClassRoomIModel(classRoomModel1));

            HomeTaskModel homeTaskModel = new HomeTaskModel();
            homeTaskModel.Name = "Mathesha";
            homeTaskModel.Deadline_Date = DateTime.Now;
            HomeTasks.Add(new HomeTaskIModel(homeTaskModel));

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

        private ObservableCollection<ClassRoomIModel> _classRooms;
        public ObservableCollection<ClassRoomIModel> ClassRooms
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

        private ObservableCollection<ClassRoomIModel> _shownClassRooms;
        public ObservableCollection<ClassRoomIModel> ShownClassRooms
        {
            get
            {
                return _shownClassRooms;
            }
            set
            {
                _shownClassRooms = new ObservableCollection<ClassRoomIModel>(value.OrderBy(c => c.Name).ThenBy(c => c.Teacher_Name));
                OnPropertyChanged("ShownClassRooms");
            }
        }

        private ObservableCollection<HomeTaskIModel> _homeTasks;
        public ObservableCollection<HomeTaskIModel> HomeTasks
        {
            get
            {
                return _homeTasks;
            }
            set
            {
                _homeTasks = new ObservableCollection<HomeTaskIModel>(value.OrderBy(h => h.Deadline_Date));
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
                var newShownClassRooms = new ObservableCollection<ClassRoomIModel>();

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
            joinClassDialog.Show();
        }

        public DelegateCommand CreateClassRoomCommand { get; }
        private void CreateClassRoomCommandHandler()
        {
            CreateClassDialog createClassDialog = new CreateClassDialog();
            createClassDialog.DataContext = new CreateClassViewModel();
            createClassDialog.Show();
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

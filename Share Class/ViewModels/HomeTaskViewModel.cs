using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.INotifyModels;
using Share_Class.MVVM;

namespace Share_Class.ViewModels
{
    public class HomeTaskViewModel : INotifyBase
    {
        private HomeTaskModel homeTaskModel;

        public HomeTaskViewModel() 
        {
            CreateSolutionCommand = new DelegateCommand(CreateSolutionCommandHandler);
            Solutions = new ObservableCollection<SolutionNotifyModel>();
        }

        public void InitializeHomeTask(HomeTaskModel homeTaskModel)
        {
            this.homeTaskModel = homeTaskModel;

            this.Name = homeTaskModel.Name;
            this.Description = homeTaskModel.Description;

            LoadSolutions();
        }

        private void LoadSolutions()
        {
            Solutions = new ObservableCollection<SolutionNotifyModel>();

            foreach (var solution in GlobalSettings.dbDataOperations.SolutionModels.Where(i => i.HomeTask_ID == homeTaskModel.ID))
            {
                Solutions.Add(new SolutionNotifyModel(solution));
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

        private ObservableCollection<SolutionNotifyModel> _solutions;
        public ObservableCollection<SolutionNotifyModel> Solutions
        {
            get
            {
                return _solutions;
            }
            set
            {
                _solutions = value;
                OnPropertyChanged("Solutions");
            }
        }

        private string _solutionText = "";
        public string SolutionText
        {
            get
            {
                return _solutionText;
            }
            set
            {
                _solutionText = value;
                OnPropertyChanged("SolutionText");
            }
        }

        public DelegateCommand CreateSolutionCommand { get; }
        private void CreateSolutionCommandHandler()
        {
            if (_solutionText == string.Empty)
            {
                return;
            }

            var newSolution = new SolutionModel();
            newSolution.Solution_Text = _solutionText;
            newSolution.HomeTask_ID = homeTaskModel.ID;
            newSolution.UserID = GlobalSettings.CurentUser.ID;

            GlobalSettings.dbDataOperations.AddSolution(newSolution);

            var solutionNotify = new SolutionNotifyModel(newSolution);
            Solutions.Add(solutionNotify);
            GlobalSettings.NotifyModels.SolutionNotifyModels.Add(solutionNotify);
        }
    }
}

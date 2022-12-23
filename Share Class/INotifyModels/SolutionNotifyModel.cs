using BusinessLogicLayer.Models;
using Share_Class.Global;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Class.INotifyModels
{
    public class SolutionNotifyModel : INotifyBase
    {
        public SolutionNotifyModel(SolutionModel solutionModel)
        {
            this.solutionModel = solutionModel;

            this.SolutionText = solutionModel.Solution_Text;

            var user = GlobalSettings.dbDataOperations.UserModels.FirstOrDefault(i => i.ID == solutionModel.UserID);

            if (user != null)
            {
                UserName = user.Login;
            }
            else
            {
                UserName = "NotFound";
            }
        }

        private SolutionModel solutionModel;

        private string _solutionText;
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
    }
}

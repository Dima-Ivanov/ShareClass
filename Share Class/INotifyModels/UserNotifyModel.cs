using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.INotifyModels
{
    public class UserNotifyModel : INotifyBase
    {
        public UserNotifyModel(UserModel userModel)
        {
            this.userModel = userModel;

            this.Name = userModel.Name;
            Score = 0;
        }

        public void CalculateScore(int ClassRoomID)
        {
            HashSet<int> homeTasksID = new HashSet<int>();
            foreach (var homeTask in GlobalSettings.dbDataOperations.HomeTaskModels.Where(i => i.ClassRoom_ID == ClassRoomID))
            {
                homeTasksID.Add(homeTask.ID);
            }

            HashSet<int> solutionsID = new HashSet<int>();
            foreach (var solution in GlobalSettings.dbDataOperations.SolutionModels)
            {
                if (homeTasksID.Contains(solution.HomeTask_ID))
                {
                    solutionsID.Add(solution.ID);
                }
            }

            Dictionary<int, ReactionTypeModel> idToReactionType = new Dictionary<int, ReactionTypeModel>();
            foreach (var reaction in GlobalSettings.dbDataOperations.ReactionModels)
            {
                if (reaction.User_ID == userModel.ID && solutionsID.Contains(reaction.Solution_ID))
                {
                    var reactionType = idToReactionType[reaction.Reaction_Type];

                    switch(reactionType.Name)
                    {
                        case "Like":
                            Score++;
                            break;

                        case "Dislike":
                            Score--;
                            break;
                    }
                }
            }
        }

        private UserModel userModel;

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

        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }
    }
}
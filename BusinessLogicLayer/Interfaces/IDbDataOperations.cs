using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDbDataOperations
    {
        bool Save();
        List<ClassRoomModel> ClassRoomModels { get; set; }
        void AddClassRoom(ClassRoomModel classRoomModel);

        List<ClassRoomsUsersModel> ClassRoomsUsersModels { get; set; }
        void AddClassRoomsUsers(ClassRoomsUsersModel classRoomsUsersModel);

        List<HomeTask_FileModel> HomeTask_FileModels { get; set; }
        void AddHomeTask_File(HomeTask_FileModel homeTask_FileModel);

        List<HomeTaskModel> HomeTaskModels { get; set; }
        void AddHomeTask(HomeTaskModel homeTaskModel);

        List<ReactionModel> ReactionModels { get; set; }
        void AddReaction(ReactionModel reactionModel);

        List<ReactionTypeModel> ReactionTypeModels { get; set; }
        void AddReactionType(ReactionTypeModel reactionTypeModel);

        List<Solution_FileModel> Solution_FileModels { get; set; }
        void AddSolution_File(Solution_FileModel solution_FileModel);

        List<SolutionModel> SolutionModels { get; set; }
        void AddSolution(SolutionModel solutionModel);

        List<UserModel> UserModels { get; set; }
        void AddUser(UserModel userModel);
    }
}

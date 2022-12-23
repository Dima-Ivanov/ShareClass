using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DbDataOperations : IDbDataOperations
    {
        IDBRepository dBRepository;

        public DbDataOperations(IDBRepository dBRepository)
        {
            this.dBRepository = dBRepository;

            this.ClassRoomModels = dBRepository.ClassRooms.GetList().Select(i => new ClassRoomModel(i)).ToList();
            this.ClassRoomsUsersModels = dBRepository.ClassRoomsUsers.GetList().Select(i => new ClassRoomsUsersModel(i)).ToList();
            this.HomeTask_FileModels = dBRepository.HomeTask_Files.GetList().Select(i => new HomeTask_FileModel(i)).ToList();
            this.HomeTaskModels = dBRepository.HomeTasks.GetList().Select(i => new HomeTaskModel(i)).ToList();
            this.ReactionModels = dBRepository.Reactions.GetList().Select(i => new ReactionModel(i)).ToList();
            this.ReactionTypeModels = dBRepository.ReactionTypes.GetList().Select(i => new ReactionTypeModel(i)).ToList();
            this.Solution_FileModels = dBRepository.Solution_Files.GetList().Select(i => new Solution_FileModel(i)).ToList();
            this.SolutionModels = dBRepository.Solutions.GetList().Select(i => new SolutionModel(i)).ToList();
            this.UserModels = dBRepository.Users.GetList().Select(i => new UserModel(i)).ToList();
        }

        public bool Save()
        {
            if (dBRepository.Save() > 0) return true;
            return false;
        }

        public List<ClassRoomModel> ClassRoomModels { get; set; }
        public void AddClassRoom(ClassRoomModel classRoomModel)
        {
            ClassRoomModels.Add(classRoomModel);
            classRoomModel.ID = dBRepository.ClassRooms.Create(classRoomModel.CreateEntity());
            Save();
        }

        public List<ClassRoomsUsersModel> ClassRoomsUsersModels { get; set; }
        public void AddClassRoomsUsers(ClassRoomsUsersModel classRoomsUsersModel)
        {
            ClassRoomsUsersModels.Add(classRoomsUsersModel);
            classRoomsUsersModel.ID = dBRepository.ClassRoomsUsers.Create(classRoomsUsersModel.CreateEntity());
            Save();
        }

        public List<HomeTask_FileModel> HomeTask_FileModels { get; set; }
        public void AddHomeTask_File(HomeTask_FileModel homeTask_FileModel)
        {
            HomeTask_FileModels.Add(homeTask_FileModel);
            homeTask_FileModel.ID = dBRepository.HomeTask_Files.Create(homeTask_FileModel.CreateEntity());
            Save();
        }

        public List<HomeTaskModel> HomeTaskModels { get; set; }
        public void AddHomeTask(HomeTaskModel homeTaskModel)
        {
            HomeTaskModels.Add(homeTaskModel);
            homeTaskModel.ID = dBRepository.HomeTasks.Create(homeTaskModel.CreateEntity());
            Save();
        }

        public List<ReactionModel> ReactionModels { get; set; }
        public void AddReaction(ReactionModel reactionModel)
        {
            ReactionModels.Add(reactionModel);
            reactionModel.ID = dBRepository.Reactions.Create(reactionModel.CreateEntity());
            Save();
        }

        public List<ReactionTypeModel> ReactionTypeModels { get; set; }
        public void AddReactionType(ReactionTypeModel reactionTypeModel)
        {
            ReactionTypeModels.Add(reactionTypeModel);
            reactionTypeModel.ID = dBRepository.ReactionTypes.Create(reactionTypeModel.CreateEntity());
            Save();
        }

        public List<Solution_FileModel> Solution_FileModels { get; set; }
        public void AddSolution_File(Solution_FileModel solution_FileModel)
        {
            Solution_FileModels.Add(solution_FileModel);
            solution_FileModel.ID = dBRepository.Solution_Files.Create(solution_FileModel.CreateEntity());
            Save();
        }

        public List<SolutionModel> SolutionModels { get; set; }
        public void AddSolution(SolutionModel solutionModel)
        {
            SolutionModels.Add(solutionModel);
            solutionModel.ID = dBRepository.Solutions.Create(solutionModel.CreateEntity());
            Save();
        }

        public List<UserModel> UserModels { get; set; }
        public void AddUser(UserModel userModel)
        {
            UserModels.Add(userModel);
            userModel.ID = dBRepository.Users.Create(userModel.CreateEntity());
            Save();
        }
    }
}

using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataRepository : IDBRepository
    {
        private DataContext dataContext;

        public DataRepository()
        {
            dataContext = new DataContext();
        }

        public int Save()
        {
            return dataContext.SaveChanges();
        }

        private ClassRoomRepository classRoomRepository;
        public IRepository<ClassRoom> ClassRooms 
        { 
            get
            {
                if (classRoomRepository == null)
                {
                    classRoomRepository = new ClassRoomRepository(dataContext);
                }
                return classRoomRepository;
            }
        }

        private ClassRoomsUsersRepository classRoomsUsersRepository;
        public ClassRoomsUsersRepository ClassRoomsUsers
        {
            get
            {
                if (classRoomsUsersRepository == null)
                {
                    classRoomsUsersRepository = new ClassRoomsUsersRepository(dataContext);
                }
                return classRoomsUsersRepository;
            }
        }

        private HomeTaskRepository homeTaskRepository;
        public IRepository<HomeTask> HomeTasks
        {
            get
            {
                if (homeTaskRepository == null)
                {
                    homeTaskRepository = new HomeTaskRepository(dataContext);
                }
                return homeTaskRepository;
            }
        }

        private HomeTask_FileRepository homeTask_FileRepository;
        public IRepository<HomeTask_File> HomeTask_Files
        {
            get
            {
                if (homeTask_FileRepository == null)
                {
                    homeTask_FileRepository = new HomeTask_FileRepository(dataContext);
                }
                return homeTask_FileRepository;
            }
        }

        private ReactionRepository reactionRepository;
        public IRepository<Reaction> Reactions
        {
            get
            {
                if (reactionRepository == null)
                {
                    reactionRepository = new ReactionRepository(dataContext);
                }
                return reactionRepository;
            }
        }

        private ReactionTypeRepository reactionTypeRepository;
        public IRepository<ReactionType> ReactionTypes
        {
            get
            {
                if (reactionTypeRepository == null)
                {
                    reactionTypeRepository = new ReactionTypeRepository(dataContext);
                }
                return reactionTypeRepository;
            }
        }

        private SolutionRepository solutionRepository;
        public IRepository<Solution> Solutions
        {
            get
            {
                if (solutionRepository == null)
                {
                    solutionRepository = new SolutionRepository(dataContext);
                }
                return solutionRepository;
            }
        }

        private Solution_FileRepository solution_FileRepository;
        public IRepository<Solution_File> Solution_Files
        {
            get
            {
                if (solution_FileRepository == null)
                {
                    solution_FileRepository = new Solution_FileRepository(dataContext);
                }
                return solution_FileRepository;
            }
        }

        private UserRepository userRepository;
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(dataContext);
                }
                return userRepository;
            }
        }
    }
}

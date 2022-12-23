using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Interfaces
{
    public interface IDBRepository
    {
        int Save();
        IRepository<ClassRoom> ClassRooms { get; }
        ClassRoomsUsersRepository ClassRoomsUsers { get; }
        IRepository<HomeTask> HomeTasks { get; }
        IRepository<HomeTask_File> HomeTask_Files { get; }
        IRepository<Reaction> Reactions { get; }
        IRepository<ReactionType> ReactionTypes { get; }
        IRepository<Solution> Solutions { get; }
        IRepository<Solution_File> Solution_Files { get; }
        IRepository<User> Users { get; }
    }
}

using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=ShareClassEntities")
        {
            
        }

        public virtual DbSet<ClassRoom> DBClassRoom { get; set; }
        public virtual DbSet<ClassRoomsUsers> DBClassRoomsUsers { get; set; }
        public virtual DbSet<HomeTask> DBHomeTask { get; set; }
        public virtual DbSet<HomeTask_File> DBHomeTask_File { get; set; }
        public virtual DbSet<Reaction> DBReaction { get; set; }
        public virtual DbSet<ReactionType> DBReactionType { get; set; }
        public virtual DbSet<Solution> DBSolution { get; set; }
        public virtual DbSet<Solution_File> DBSolution_File { get; set; }
        public virtual DbSet<User> DBUser { get; set; }
    }
}

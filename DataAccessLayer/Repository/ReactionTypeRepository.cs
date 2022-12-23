using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ReactionTypeRepository : IRepository<ReactionType>
    {
        private DataContext dataContext;
        private int maxID;

        public ReactionTypeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<ReactionType> GetList()
        {
            return dataContext.DBReactionType.ToList();
        }

        public ReactionType GetItem(int ID)
        {
            return dataContext.DBReactionType.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(ReactionType classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBReactionType.Add(classRoom);
            return maxID;
        }

        public void Update(ReactionType classRoom)
        {
            var itemToReplace = dataContext.DBReactionType.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBReactionType.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBReactionType.Remove(itemToDelete);
            }
        }
    }
}

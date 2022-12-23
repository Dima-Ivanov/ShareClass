using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ReactionRepository : IRepository<Reaction>
    {
        private DataContext dataContext;
        private int maxID;

        public ReactionRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<Reaction> GetList()
        {
            return dataContext.DBReaction.ToList();
        }

        public Reaction GetItem(int ID)
        {
            return dataContext.DBReaction.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(Reaction classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBReaction.Add(classRoom);
            return maxID;
        }

        public void Update(Reaction classRoom)
        {
            var itemToReplace = dataContext.DBReaction.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBReaction.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBReaction.Remove(itemToDelete);
            }
        }
    }
}

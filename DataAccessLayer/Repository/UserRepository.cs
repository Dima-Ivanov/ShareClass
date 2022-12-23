using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IRepository<User>
    {
        private DataContext dataContext;
        private int maxID;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<User> GetList()
        {
            return dataContext.DBUser.ToList();
        }

        public User GetItem(int ID)
        {
            return dataContext.DBUser.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(User classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBUser.Add(classRoom);
            return maxID;
        }

        public void Update(User classRoom)
        {
            var itemToReplace = dataContext.DBUser.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBUser.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBUser.Remove(itemToDelete);
            }
        }
    }
}

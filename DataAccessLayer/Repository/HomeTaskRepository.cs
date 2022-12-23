using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class HomeTaskRepository : IRepository<HomeTask>
    {
        private DataContext dataContext;
        private int maxID;

        public HomeTaskRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<HomeTask> GetList()
        {
            return dataContext.DBHomeTask.ToList();
        }

        public HomeTask GetItem(int ID)
        {
            return dataContext.DBHomeTask.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(HomeTask classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBHomeTask.Add(classRoom);
            return maxID;
        }

        public void Update(HomeTask classRoom)
        {
            var itemToReplace = dataContext.DBHomeTask.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBHomeTask.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBHomeTask.Remove(itemToDelete);
            }
        }
    }
}

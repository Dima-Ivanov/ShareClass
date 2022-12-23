using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class HomeTask_FileRepository : IRepository<HomeTask_File>
    {
        private DataContext dataContext;
        private int maxID;

        public HomeTask_FileRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<HomeTask_File> GetList()
        {
            return dataContext.DBHomeTask_File.ToList();
        }

        public HomeTask_File GetItem(int ID)
        {
            return dataContext.DBHomeTask_File.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(HomeTask_File homeTask_File)
        {
            homeTask_File.ID = ++maxID;
            dataContext.DBHomeTask_File.Add(homeTask_File);
            return maxID;
        }

        public void Update(HomeTask_File homeTask_File)
        {
            var itemToReplace = dataContext.DBHomeTask_File.FirstOrDefault(i => i.ID == homeTask_File.ID);

            if (itemToReplace != null)
            {
                itemToReplace = homeTask_File;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBHomeTask_File.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBHomeTask_File.Remove(itemToDelete);
            }
        }
    }
}

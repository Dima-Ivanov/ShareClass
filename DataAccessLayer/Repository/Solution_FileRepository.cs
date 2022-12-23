using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class Solution_FileRepository : IRepository<Solution_File>
    {
        private DataContext dataContext;
        private int maxID;

        public Solution_FileRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<Solution_File> GetList()
        {
            return dataContext.DBSolution_File.ToList();
        }

        public Solution_File GetItem(int ID)
        {
            return dataContext.DBSolution_File.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(Solution_File classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBSolution_File.Add(classRoom);
            return maxID;
        }

        public void Update(Solution_File classRoom)
        {
            var itemToReplace = dataContext.DBSolution_File.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBSolution_File.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBSolution_File.Remove(itemToDelete);
            }
        }
    }
}

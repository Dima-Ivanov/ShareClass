using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SolutionRepository : IRepository<Solution>
    {
        private DataContext dataContext;
        private int maxID;

        public SolutionRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<Solution> GetList()
        {
            return dataContext.DBSolution.ToList();
        }

        public Solution GetItem(int ID)
        {
            return dataContext.DBSolution.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(Solution classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBSolution.Add(classRoom);
            return maxID;
        }

        public void Update(Solution classRoom)
        {
            var itemToReplace = dataContext.DBSolution.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBSolution.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBSolution.Remove(itemToDelete);
            }
        }
    }
}

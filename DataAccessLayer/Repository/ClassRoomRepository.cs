using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ClassRoomRepository : IRepository<ClassRoom>
    {
        private DataContext dataContext;
        private int maxID;

        public ClassRoomRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<ClassRoom> GetList()
        {
            return dataContext.DBClassRoom.ToList();
        }

        public ClassRoom GetItem(int ID)
        {
            return dataContext.DBClassRoom.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(ClassRoom classRoom)
        {
            classRoom.ID = ++maxID;
            dataContext.DBClassRoom.Add(classRoom);
            return maxID;
        }

        public void Update(ClassRoom classRoom)
        {
            var itemToReplace = dataContext.DBClassRoom.FirstOrDefault(i => i.ID == classRoom.ID);

            if (itemToReplace != null)
            {
                itemToReplace = classRoom;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBClassRoom.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBClassRoom.Remove(itemToDelete);
            }
        }
    }
}

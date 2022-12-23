using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ClassRoomsUsersRepository : IRepository<ClassRoomsUsers>
    {
        private DataContext dataContext;
        private int maxID;

        public ClassRoomsUsersRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

            var list = GetList();

            maxID = 0;
            foreach (var item in list)
            {
                maxID = Math.Max(maxID, item.ID);
            }
        }

        public List<ClassRoomsUsers> GetList()
        {
            return dataContext.DBClassRoomsUsers.ToList();
        }

        public ClassRoomsUsers GetItem(int ID)
        {
            return dataContext.DBClassRoomsUsers.FirstOrDefault(i => i.ID == ID);
        }

        public int Create(ClassRoomsUsers ClassRoomsUsers)
        {
            ClassRoomsUsers.ID = ++maxID;
            dataContext.DBClassRoomsUsers.Add(ClassRoomsUsers);
            return maxID;
        }

        public void Update(ClassRoomsUsers ClassRoomsUsers)
        {
            var itemToReplace = dataContext.DBClassRoomsUsers.FirstOrDefault(i => i.ID == ClassRoomsUsers.ID);

            if (itemToReplace != null)
            {
                itemToReplace = ClassRoomsUsers;
            }
        }

        public void Delete(int ID)
        {
            var itemToDelete = dataContext.DBClassRoomsUsers.FirstOrDefault(i => i.ID == ID);

            if (itemToDelete != null)
            {
                dataContext.DBClassRoomsUsers.Remove(itemToDelete);
            }
        }
    }
}

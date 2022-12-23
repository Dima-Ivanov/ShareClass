using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ClassRoomsUsersModel : IModel<ClassRoomsUsers>
    {
        public ClassRoomsUsersModel()
        {

        }

        public ClassRoomsUsersModel(ClassRoomsUsers classRoomUsers)
        {
            this.ID = classRoomUsers.ID;
            this.User_ID = classRoomUsers.User_ID;
            this.ClassRoom_ID = classRoomUsers.ClassRoom_ID;
            this.Status = classRoomUsers.Status;
        }

        public ClassRoomsUsers CreateEntity()
        {
            var entity = new ClassRoomsUsers();

            entity.ID = this.ID;
            entity.User_ID = this.User_ID;
            entity.ClassRoom_ID = this.ClassRoom_ID;
            entity.Status = this.Status;

            return entity;
        }

        public int ID { get; set; }
        public int User_ID { get; set; }
        public int ClassRoom_ID { get; set; }
        public byte Status { get; set; }
    }
}

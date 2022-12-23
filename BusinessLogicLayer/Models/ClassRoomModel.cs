using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ClassRoomModel : IModel<ClassRoom>
    {
        public ClassRoomModel()
        {
        }

        public ClassRoomModel(ClassRoom classRoom)
        {
            this.ID = classRoom.ID;
            this.Name = classRoom.Name;
            this.InvitationCode = classRoom.InvitationCode;
            this.Description = classRoom.Description;
            this.Teacher_Name = classRoom.Teacher_Name;
            this.Students_Count = classRoom.Students_Count;
            this.Creation_Date = classRoom.Creation_Date;
            this.Administrator_ID = classRoom.Administrator_ID;
        }

        public ClassRoom CreateEntity()
        {
            var entity = new ClassRoom();

            entity.ID = this.ID;
            entity.Name = this.Name;
            entity.InvitationCode = this.InvitationCode;
            entity.Description = this.Description;
            entity.Teacher_Name = this.Teacher_Name;
            entity.Students_Count = this.Students_Count;
            entity.Creation_Date = this.Creation_Date;
            entity.Administrator_ID = this.Administrator_ID;

            return entity;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Guid InvitationCode { get; set; }
        public string Description { get; set; }
        public string Teacher_Name { get; set; }
        public int Students_Count { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public int Administrator_ID { get; set; }
    }
}

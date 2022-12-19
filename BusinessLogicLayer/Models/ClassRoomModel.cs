using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ClassRoomModel
    {
        public ClassRoomModel()
        {
            this.ClassRoomsUsers = new HashSet<ClassRoomsUsersModel>();
            this.HomeTask = new HashSet<HomeTaskModel>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Teacher_Name { get; set; }
        public int Students_Count { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public int Administrator_ID { get; set; }
        public ICollection<ClassRoomsUsersModel> ClassRoomsUsers { get; set; }
        public ICollection<HomeTaskModel> HomeTask { get; set; }
    }
}

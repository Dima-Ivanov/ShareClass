using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("ClassRoomsUsers")]
    public class ClassRoomsUsers
    {
        [Key]
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int ClassRoom_ID { get; set; }
        public byte Status { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual User User { get; set; }
    }
}

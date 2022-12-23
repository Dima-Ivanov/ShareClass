using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            this.ClassRoomsUsers = new HashSet<ClassRoomsUsers>();
            this.Reaction = new HashSet<Reaction>();
        }

        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public long Password_Hash { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoomsUsers> ClassRoomsUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reaction> Reaction { get; set; }
    }
}

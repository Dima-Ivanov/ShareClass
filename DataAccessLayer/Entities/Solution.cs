using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("Solution")]
    public class Solution
    {
        public Solution()
        {
            this.Reaction = new HashSet<Reaction>();
            this.Solution_File = new HashSet<Solution_File>();
        }

        [Key]
        public int ID { get; set; }
        public string Solution_Text { get; set; }
        public int HomeTask_ID { get; set; }
        public int UserID { get; set; }

        public virtual HomeTask HomeTask { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reaction> Reaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solution_File> Solution_File { get; set; }
    }
}

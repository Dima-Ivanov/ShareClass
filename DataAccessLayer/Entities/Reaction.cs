using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("Reaction")]
    public class Reaction
    {
        [Key]
        public int ID { get; set; }
        public int Reaction_Type { get; set; }
        public int Solution_ID { get; set; }
        public int User_ID { get; set; }

        public virtual ReactionType ReactionType { get; set; }
        public virtual Solution Solution { get; set; }
        public virtual User User { get; set; }
    }
}

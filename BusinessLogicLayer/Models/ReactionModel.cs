using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ReactionModel : IModel<Reaction>
    {
        public ReactionModel()
        {

        }

        public ReactionModel(Reaction reaction)
        {
            this.ID = reaction.ID;
            this.Reaction_Type = reaction.Reaction_Type;
            this.Solution_ID = reaction.Solution_ID;
            this.User_ID = reaction.User_ID;
        }

        public Reaction CreateEntity()
        {
            var entity = new Reaction();

            entity.ID = this.ID;
            entity.Reaction_Type = this.Reaction_Type;
            entity.Solution_ID = this.Solution_ID;
            entity.User_ID = this.User_ID;

            return entity;
        }

        public int ID { get; set; }
        public int Reaction_Type { get; set; }
        public int Solution_ID { get; set; }
        public int User_ID { get; set; }
    }
}

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ReactionTypeModel : IModel<ReactionType>
    {
        public ReactionTypeModel() 
        { 

        }

        public ReactionTypeModel(ReactionType reactionType)
        {
            this.ID = reactionType.ID;
            this.Name = reactionType.Name;
        }

        public ReactionType CreateEntity()
        {
            var entity = new ReactionType();

            entity.ID = this.ID;
            entity.Name = this.Name;

            return entity;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}

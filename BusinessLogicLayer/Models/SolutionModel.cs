using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class SolutionModel : IModel<Solution>
    {
        public SolutionModel()
        {

        }

        public SolutionModel(Solution solution) : this()
        {
            this.ID = solution.ID;
            this.Solution_Text = solution.Solution_Text;
            this.HomeTask_ID = solution.HomeTask_ID;
            this.UserID = solution.UserID;
        }

        public Solution CreateEntity()
        {
            var entity = new Solution();

            entity.ID = this.ID;
            entity.Solution_Text = this.Solution_Text;
            entity.HomeTask_ID = this.HomeTask_ID;
            entity.UserID = this.UserID;

            return entity;
        }

        public int ID { get; set; }
        public string Solution_Text { get; set; }
        public int HomeTask_ID { get; set; }
        public int UserID { get; set; }
    }
}

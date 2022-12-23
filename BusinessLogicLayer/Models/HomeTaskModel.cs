using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Models
{
    public class HomeTaskModel : IModel<HomeTask>
    {
        public HomeTaskModel()
        {
        }

        public HomeTaskModel(HomeTask homeTask)
        {
            this.ID = homeTask.ID;
            this.Name = homeTask.Name;
            this.Description = homeTask.Description;
            this.Creation_Date = homeTask.Creation_Date;
            this.Deadline_Date = homeTask.Deadline_Date;
            this.ClassRoom_ID = homeTask.ClassRoom_ID;
        }

        public HomeTask CreateEntity()
        {
            var entity = new HomeTask();

            entity.ID = this.ID;
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.Creation_Date = this.Creation_Date;
            entity.Deadline_Date = this.Deadline_Date;
            entity.ClassRoom_ID = this.ClassRoom_ID;

            return entity;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public System.DateTime Deadline_Date { get; set; }
        public int ClassRoom_ID { get; set; }
    }
}

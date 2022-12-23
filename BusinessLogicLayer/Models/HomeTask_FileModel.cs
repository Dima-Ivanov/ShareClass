using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class HomeTask_FileModel : IModel<HomeTask_File>
    {
        public HomeTask_FileModel()
        {

        }

        public HomeTask_FileModel(HomeTask_File homeTask_File)
        {
            this.ID = homeTask_File.ID;
            this.File_Name = homeTask_File.File_Name;
            this.HomeTask_ID = homeTask_File.HomeTask_ID;
        }

        public HomeTask_File CreateEntity()
        {
            var entity = new HomeTask_File();

            entity.ID = this.ID;
            entity.File_Name = this.File_Name;
            entity.HomeTask_ID = this.HomeTask_ID;

            return entity;
        }

        public int ID { get; set; }
        public string File_Name { get; set; }
        public int HomeTask_ID { get; set; }
    }
}

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Solution_FileModel : IModel<Solution_File>
    {
        public Solution_FileModel()
        {

        }

        public Solution_FileModel(Solution_File solution_File)
        {
            this.ID = solution_File.ID;
            this.File_Name = solution_File.File_Name;
            this.Solution_ID = solution_File.Solution_ID;
        }

        public Solution_File CreateEntity()
        {
            var entity = new Solution_File();

            entity.ID = this.ID;
            entity.File_Name = this.File_Name;
            entity.Solution_ID = this.Solution_ID;

            return entity;
        }

        public int ID { get; set; }
        public string File_Name { get; set; }
        public int Solution_ID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using DataAccessLayer.Context;

namespace BusinessLogicLayer.Models
{
    public class HomeTaskModel
    {
        public HomeTaskModel()
        {
            this.HomeTask_File = new HashSet<HomeTask_FileModel>();
            this.Solution = new HashSet<SolutionModel>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public System.DateTime Deadline_Date { get; set; }
        public int ClassRoom_ID { get; set; }

        public ClassRoom ClassRoom { get; set; }
        public ICollection<HomeTask_FileModel> HomeTask_File { get; set; }
        public ICollection<SolutionModel> Solution { get; set; }
    }
}

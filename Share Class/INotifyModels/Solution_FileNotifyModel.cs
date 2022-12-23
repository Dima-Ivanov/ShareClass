using BusinessLogicLayer.Models;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.INotifyModels
{
    public class Solution_FileNotifyModel : INotifyBase
    {
        public Solution_FileNotifyModel(Solution_FileModel solution_FileModel)
        {
            this.solution_FileModel = solution_FileModel;
        }

        private Solution_FileModel solution_FileModel;
    }
}

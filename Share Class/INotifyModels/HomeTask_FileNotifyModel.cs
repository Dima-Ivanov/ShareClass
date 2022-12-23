using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.MVVM;
using Share_Class.Views;
using Share_Class.ViewModels;

namespace Share_Class.INotifyModels
{
    public class HomeTask_FileNotifyModel : INotifyBase
    {
        public HomeTask_FileNotifyModel(HomeTask_FileModel homeTask_FileModel)
        {
            this.homeTask_FileModel = homeTask_FileModel;
        }

        private HomeTask_FileModel homeTask_FileModel;
    }
}

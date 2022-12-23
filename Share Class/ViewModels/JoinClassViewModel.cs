using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.MVVM;
using Share_Class.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Share_Class.ViewModels
{
    public class JoinClassViewModel : INotifyBase
    {
        public JoinClassViewModel()
        {
            FindCommand = new DelegateCommand<object>(FindCommandHandler);
            CloseCommand = new DelegateCommand<object>(CloseCommandHandler);
        }

        private string _invitationCode = "";
        public string InvitationCode
        {
            get
            {
                return _invitationCode;
            }
            set
            {
                _invitationCode = value;
                OnPropertyChanged("InvitationCode");
            }
        }

        public DelegateCommand<object> FindCommand { get; }
        private void FindCommandHandler(object param)
        {
            if (_invitationCode == string.Empty)
            {
                return;
            }

            var findClass = GlobalSettings.dbDataOperations.ClassRoomModels.FirstOrDefault(i => i.InvitationCode.ToString() == _invitationCode);

            if (findClass != null && param is Window window)
            {
                JoinClassConfirmDialog view = new JoinClassConfirmDialog();
                JoinClassConfirmViewModel vm = new JoinClassConfirmViewModel();
                vm.InitializeViewModel(findClass);
                view.DataContext = vm;
                view.ShowDialog();

                window.Close();
            }
        }

        public DelegateCommand<object> CloseCommand { get; }
        private void CloseCommandHandler(object param)
        {
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}

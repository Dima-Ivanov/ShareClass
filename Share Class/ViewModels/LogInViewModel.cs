using Prism.Commands;
using Share_Class.MVVM;
using Share_Class.Views;
using Share_Class.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Share_Class.Global;
using System.Security.Policy;
using System.Security.Cryptography;
using System.Windows;

namespace Share_Class.ViewModels
{
    public class LogInViewModel : INotifyBase
    {
        public LogInViewModel()
        {
            SignUpHintCommand = new DelegateCommand(SignUpHintCommandHandler);
            LogInCommand = new DelegateCommand<object>(LogInCommandHandler);
        }

        private string _login = "";
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password = "";
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public DelegateCommand SignUpHintCommand { get; }
        private void SignUpHintCommandHandler()
        {
            SignUpDialog signUpDialog = new SignUpDialog();
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            signUpDialog.DataContext = signUpViewModel;
            signUpDialog.ShowDialog();
        }

        public DelegateCommand<object> LogInCommand { get; }
        private void LogInCommandHandler(object param)
        {
            var user = GlobalSettings.dbDataOperations.UserModels.FirstOrDefault(u => u.Login == _login);

            if (user == null) return;

            var hashCode = GlobalUtils.CalculateHash(_password);

            if (user.Password_Hash == hashCode && param is Window window)
            {
                GlobalSettings.CurentUser = user;
                window.Close();
            }
        }
    }
}

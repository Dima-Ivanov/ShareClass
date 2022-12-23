using BusinessLogicLayer.Models;
using Prism.Commands;
using Share_Class.Global;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Share_Class.ViewModels
{
    public class SignUpViewModel : INotifyBase
    {
        public SignUpViewModel()
        {
            SignUpCommand = new DelegateCommand<object>(SignUpCommandHandler);
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
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

        public DelegateCommand<object> SignUpCommand { get; }
        private void SignUpCommandHandler(object param)
        {
            if (_name == string.Empty || _login == string.Empty || _password == string.Empty)
            {
                return;
            }

            var existUser = GlobalSettings.dbDataOperations.UserModels.FirstOrDefault(u => u.Login == _login);

            if (existUser != null)
            {
                return;
            }

            var newUser = new UserModel();
            newUser.Name = _name;
            newUser.Login = _login;
            newUser.Password_Hash = GlobalUtils.CalculateHash(_password);

            if (param is Window window)
            {
                GlobalSettings.dbDataOperations.AddUser(newUser);
                GlobalSettings.NotifyModels.UserNotifyModels.Add(new INotifyModels.UserNotifyModel(newUser));

                window.Close();
            }
        }
    }
}

using Prism.Commands;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.ViewModels
{
    public class SignUpViewModel : INotifyBase
    {
        public SignUpViewModel()
        {
            SignUpCommand = new DelegateCommand(SignUpCommandHandler);
        }

        private string _name;
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

        private string _login;
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

        private string _password;
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

        public DelegateCommand SignUpCommand { get; }
        private void SignUpCommandHandler()
        {
            // add new user to DataBase
        }
    }
}

using Prism.Commands;
using Share_Class.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Share_Class.ViewModels
{
    public class LogInViewModel : INotifyBase
    {
        public LogInViewModel()
        {
            SignUpHintCommand = new DelegateCommand(SignUpHintCommandHandler);
            LogInCommand = new DelegateCommand(LogInCommandHandler);
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

        public DelegateCommand SignUpHintCommand { get; }
        private void SignUpHintCommandHandler()
        {
            // open sign up dialog window
        }

        public DelegateCommand LogInCommand { get; }
        private void LogInCommandHandler()
        {
            // log in to system, close this window
        }
    }
}

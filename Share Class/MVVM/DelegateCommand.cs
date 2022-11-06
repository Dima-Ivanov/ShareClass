using System;
using System.Windows.Input;

namespace Share_Class.MVVM
{
    public class DelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object param)
        {
            return this.canExecute == null || this.canExecute(param);
        }

        public void Execute(object param)
        {
            this.execute(param);
        }
    }
}

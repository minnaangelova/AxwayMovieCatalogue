using System;
using System.Windows.Input;

namespace MovieCatalogueAppWPF
{
    class LambdaCommand : ICommand
    {
        private readonly Action _action;

        public LambdaCommand(Action action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}


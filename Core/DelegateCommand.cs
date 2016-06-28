using System;
using System.Windows.Input;

namespace Core
{
    /// <summary>
    ///     Simple implementation of <see cref="ICommand" /> interface.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        ///     Creates a new instance of <see cref="DelegateCommand" />.
        /// </summary>
        /// <param name="execute">Action to execute</param>
        /// <param name="canExecute">Function to perform CanExecute check</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
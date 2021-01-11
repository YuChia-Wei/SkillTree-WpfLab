using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class BmiCommand : ICommand
    {
        private Func<object, bool> _canExecuteHandler;
        private Func<object, decimal> _executeHandler;

        public BmiCommand(Func<object, decimal> executeHandler, Func<object, bool> canExecuteHandler)
        {
            _executeHandler = executeHandler ?? throw new ArgumentNullException("execute handler can not be null");
            _canExecuteHandler =
                canExecuteHandler ?? throw new ArgumentNullException("canExecute handler can not be null");
        }

        public BmiCommand(Func<object, decimal> executeHandler) : this(executeHandler, x => true)
        {
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to <see langword="null" />.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler(parameter);
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to <see langword="null" />.
        /// </param>
        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }

        /// <summary>Occurs when changes occur that affect whether or not the command should execute.</summary>
        public event EventHandler CanExecuteChanged;
    }
}
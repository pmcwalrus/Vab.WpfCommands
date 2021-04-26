using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Vab.WpfCommands.ErrorHandlers;
using Vab.WpfCommands.Misc;

namespace Vab.WpfCommands.Commands
{
    public class SimpleAsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        /// <summary>
        /// Simplest command that works with async methods
        /// </summary>
        /// <param name="execute">Action to execute</param>
        /// <param name="canExecute">Execution possibility</param>
        /// <param name="errorHandler">Error handler</param>
        public SimpleAsyncCommand(Func<Task> execute,
            Func<bool> canExecute = null,
            IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public bool CanExecute() => !_isExecuting && (_canExecute?.Invoke() ?? true);

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Excplicit implementation

        bool ICommand.CanExecute(object param) => CanExecute();

        void ICommand.Execute(object param) => ExecuteAsync().FireAndForgetSafeAsync(_errorHandler);

        #endregion
    }
}

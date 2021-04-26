using System;

namespace Vab.WpfCommands.ErrorHandlers
{
    public class ErrorNotificator : IErrorHandler
    {
        /// <summary>
        /// Event calls when exception throwed
        /// </summary>
        public event EventHandler<Exception> ExceptionThrowed = delegate { };
        public bool RethrowExceptions { get; }

        /// <summary>
        /// Error handler generates event call when exception throwed
        /// </summary>
        /// <param name="rethrowExceptions">True - throw exception anyway.</param>
        public ErrorNotificator(bool rethrowExceptions = false)
        {
            RethrowExceptions = rethrowExceptions;
        }

        void IErrorHandler.HandleError(Exception ex)
        {
            ExceptionThrowed?.Invoke(this, ex);
            if (RethrowExceptions)
                throw ex;
        }
    }
}

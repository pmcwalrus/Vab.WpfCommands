using System;

namespace Vab.WpfCommands.ErrorHandlers
{
    public interface IErrorHandler
    {
        /// <summary>
        /// Method for error handling
        /// </summary>
        /// <param name="ex">Throwed exception</param>
        void HandleError(Exception ex);
    }
}

using System;

namespace Vab.WpfCommands.ErrorHandlers
{
    /// <summary>
    /// The simplest handler that rethrow exceptions
    /// </summary>
    public class ErrorThrower : IErrorHandler
    {
        void IErrorHandler.HandleError(Exception ex) => throw ex;
    }
}

using System.Threading.Tasks;
using System.Windows.Input;

namespace Vab.WpfCommands.Commands
{
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Start execution if possible
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync();
        /// <summary>
        /// Returns true if execution is possible
        /// </summary>
        /// <returns></returns>
        bool CanExecute();
    }
}

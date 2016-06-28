using System.Windows.Input;
using Client.Data;
using Client.View;

namespace Client.ViewModelInterface
{
    /// <summary>
    ///     An interface that describe a viewmodel for <see cref="MainWindow" />.
    /// </summary>
    public interface IFunnyHoneyViewModel
    {
        /// <summary>
        ///     Gets the Apiary object.
        /// </summary>
        Apiary Apiary { get; }

        /// <summary>
        ///     Gets the sign that work is started
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        ///     Start work command
        /// </summary>
        ICommand StartCommand { get; }

        /// <summary>
        ///     Stop work command
        /// </summary>
        ICommand StopCommand { get; }

        /// <summary>
        ///     Collect honey command
        /// </summary>
        ICommand CollectCommand { get; }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Core.Annotations;

namespace Core.ViewModel
{
    /// <summary>
    ///     Object that implements INotifyPropertyChanged interface.
    /// </summary>
    public class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        ///     PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
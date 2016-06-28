using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Data;
using Client.Service;
using Client.View;
using Client.ViewModelInterface;
using Core;
using Core.ViewModel;

namespace Client.ViewModel
{
    /// <summary>
    ///     A viewmodel for <see cref="MainWindow" />.
    /// </summary>
    public class FunnyHoneyViewModel : NotificationObject, IFunnyHoneyViewModel
    {
        private bool _isStarted;
        private CancellationTokenSource _tokenSource;

        /// <summary>
        ///     Creates a new instance of <see cref="FunnyHoneyViewModel" />.
        /// </summary>
        public FunnyHoneyViewModel()
        {
            Apiary = ApiaryDataManager.Load();

            StartCommand = new DelegateCommand(StartExecute, o => !IsStarted);
            StopCommand = new DelegateCommand(StopExecute, o => IsStarted);
            CollectCommand = new DelegateCommand(CollectExecute, o => IsStarted);
        }

        /// <summary>
        ///     Gets the Apiary
        /// </summary>
        public Apiary Apiary { get; }

        /// <summary>
        ///     Gets the sign that work is started
        /// </summary>
        public bool IsStarted
        {
            get { return _isStarted; }
            private set
            {
                if (value == _isStarted) return;
                _isStarted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Start work command
        /// </summary>
        public ICommand StartCommand { get; }

        /// <summary>
        ///     Stop work command
        /// </summary>
        public ICommand StopCommand { get; }

        /// <summary>
        ///     Collect honey command
        /// </summary>
        public ICommand CollectCommand { get; }

        private void StartExecute(object param)
        {
            IsStarted = true;

            _tokenSource = new CancellationTokenSource();
            Task.WhenAll(new List<Task>
            {
                ApiaryProcessor.CreateBeesTask(Apiary, _tokenSource.Token),
                ApiaryProcessor.HoneyProductionTask(Apiary, _tokenSource.Token)
            });
        }

        private void StopExecute(object param)
        {
            IsStarted = false;
            _tokenSource.Cancel();
            ApiaryDataManager.Save(Apiary);
        }

        private void CollectExecute(object param)
        {
            ApiaryProcessor.CollectHoneyTask(Apiary, _tokenSource.Token);
        }
    }
}
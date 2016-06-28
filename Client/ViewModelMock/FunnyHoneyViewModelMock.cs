using System.Collections.Generic;
using System.Windows.Input;
using Client.Data;
using Client.View;
using Client.ViewModelInterface;
using Core;

namespace Client.ViewModelMock
{
    /// <summary>
    ///     A mock viewmodel for <see cref="MainWindow" />.
    /// </summary>
    public class FunnyHoneyViewModelMock : IFunnyHoneyViewModel
    {
        /// <summary>
        ///     Creates a new instance of <see cref="FunnyHoneyViewModelMock" />.
        /// </summary>
        public FunnyHoneyViewModelMock()
        {
            Apiary = new Apiary(new List<Hive>
            {
                new Hive
                {
                    AmountOfHoney = 100,
                    AmountOfWorkerBees = 1000,
                    AmountOfGuards = 120
                }
            });

            StartCommand = new DelegateCommand(StartExecute, o => IsStarted);
            StopCommand = new DelegateCommand(StopExecute, o => !IsStarted);
            CollectCommand = new DelegateCommand(CollectExecute, o => IsStarted);
        }

        /// <summary>
        ///     Gets the Apiary
        /// </summary>
        public Apiary Apiary { get; }

        /// <summary>
        ///     Gets the sign that work is started
        /// </summary>
        public bool IsStarted { get; private set; }

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
        }

        private void StopExecute(object param)
        {
            IsStarted = false;
        }

        private void CollectExecute(object param)
        {
        }
    }
}
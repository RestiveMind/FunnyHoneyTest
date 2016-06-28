using System.ComponentModel;
using System.Windows;
using Client.ViewModel;
using Client.ViewModelInterface;
using Client.ViewModelMock;
using Core.Service;

namespace Client.Service
{
    /// <summary>
    ///     Simple view model locator.
    /// </summary>
    public class ViewModelLocator
    {
        private readonly DependencyObject _obj = new DependencyObject();

        /// <summary>
        ///     Create a new instance of <see cref="ViewModelLocator" /> class.
        /// </summary>
        public ViewModelLocator()
        {
            if (IsDesignMode)
            {
                ServiceLocator.Default.Register(typeof(IFunnyHoneyViewModel), new FunnyHoneyViewModelMock());
            }
            else
            {
                ServiceLocator.Default.Register(typeof(IFunnyHoneyViewModel), new FunnyHoneyViewModel());
            }
        }

        private bool IsDesignMode => DesignerProperties.GetIsInDesignMode(_obj);

        /// <summary>
        ///     Gets an instance of a class that implements <see cref="IFunnyHoneyViewModel" /> interface.
        /// </summary>
        public IFunnyHoneyViewModel FunnyHoneyViewModel => ServiceLocator.Default.Resolve<IFunnyHoneyViewModel>();
    }
}
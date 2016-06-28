using System.Windows;
using Client.Service;

namespace Client
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static string ViewModelLocatorResourceName = "ViewModelLocator";

        protected override void OnExit(ExitEventArgs e)
        {
            var viewModelLocator = Current.FindResource(ViewModelLocatorResourceName) as ViewModelLocator;
            if (viewModelLocator != null)
                ApiaryDataManager.Save(viewModelLocator.FunnyHoneyViewModel.Apiary);
        }
    }
}
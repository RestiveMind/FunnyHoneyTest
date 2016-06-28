using Core.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test.ViewModel
{
    [TestClass]
    public class BaseViewModelTest
    {
        [TestMethod]
        public void PropertyChangedTest()
        {
            var vm = new TestViewModel();
            var propertyName = string.Empty;
            vm.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
            vm.Id = 1;
            Assert.AreEqual("Id", propertyName);
        }
    }

    internal class TestViewModel : NotificationObject
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }
    }
}
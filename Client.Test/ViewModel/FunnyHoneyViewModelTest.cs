using Client.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client.Test.ViewModel
{
    [TestClass]
    public class FunnyHoneyViewModelTest
    {
        [TestMethod]
        public void InitFieldsTest()
        {
            var vm = new FunnyHoneyViewModel();
            Assert.IsNotNull(vm.Apiary);
            Assert.IsNotNull(vm.StartCommand);
            Assert.IsNotNull(vm.StopCommand);
            Assert.IsNotNull(vm.CollectCommand);
            Assert.IsFalse(vm.IsStarted);
        }
    }
}
using Client.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client.Test.Service
{
    [TestClass]
    public class ViewModelLocatorTest
    {
        [TestMethod]
        public void FunnyHoneyViewModelInitTest()
        {
            var ml = new ViewModelLocator();
            Assert.IsNotNull(ml.FunnyHoneyViewModel);
        }
    }
}
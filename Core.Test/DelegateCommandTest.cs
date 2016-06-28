using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test
{
    [TestClass]
    public class DelegateCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var i = 0;
            var c = new DelegateCommand(o => i = 1, o => true);
            c.Execute(null);
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void CanExecuteTrueTest()
        {
            var c = new DelegateCommand(o => { }, o => true);
            Assert.IsTrue(c.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteFalseTest()
        {
            var c = new DelegateCommand(o => { }, o => false);
            Assert.IsFalse(c.CanExecute(null));
        }
    }
}
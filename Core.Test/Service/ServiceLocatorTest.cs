using System;
using Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test.Service
{
    [TestClass]
    public class ServiceLocatorTest
    {
        private object _obj;

        [TestInitialize]
        public void Init()
        {
            _obj = new object();
        }

        [TestMethod]
        public void RegisterTest()
        {
            ServiceLocator.Default.Register(typeof(object), _obj);
            var resolveObj = ServiceLocator.Default.Resolve<object>();
            Assert.AreEqual(_obj, resolveObj);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterExceptionTest()
        {
            ServiceLocator.Default.Register(_obj.GetType(), _obj);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ResolveExceptionTest()
        {
            ServiceLocator.Default.Resolve<string>();
        }
    }
}
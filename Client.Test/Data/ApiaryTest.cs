using System.Collections.Generic;
using Client.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client.Test.Data
{
    [TestClass]
    public class ApiaryTest
    {
        [TestMethod]
        public void InitTest()
        {
            var apiary = new Apiary();
            Assert.IsNotNull(apiary.Hives);
            Assert.AreEqual(apiary.Hives.Count, 0);
        }

        [TestMethod]
        public void NumberOfBeesTest()
        {
            var apiary = new Apiary(new List<Hive>
            {
                new Hive {AmountOfWorkerBees = 10}
            });

            Assert.AreEqual(apiary.NumberOfBees, 11);
        }

        [TestMethod]
        public void HivesCountTest()
        {
            var apiary = new Apiary(new List<Hive>
            {
                new Hive()
            });

            Assert.AreEqual(apiary.HivesCount, 1);
        }
    }
}
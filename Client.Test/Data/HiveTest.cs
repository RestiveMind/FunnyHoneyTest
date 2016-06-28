using Client.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client.Test.Data
{
    [TestClass]
    public class HiveTest
    {
        [TestMethod]
        public void AmountOfQueensTest()
        {
            var hive = new Hive();
            Assert.AreEqual(hive.AmountOfQueens, 1);
        }

        [TestMethod]
        public void TotalAmountOfBeesTest()
        {
            var hive = new Hive
            {
                AmountOfGuards = 10,
                AmountOfWorkerBees = 15
            };

            Assert.AreEqual(hive.TotalAmountOfBees, 26);
        }
    }
}
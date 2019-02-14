using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevenueCash.Models.Piezas;
using RevenueCash.ServicesLibrary;

namespace RevenueCash.UnitTests
{
    [TestClass]
    public class TableroUnitTest
    {
        [TestMethod]
        public void TestWhen_GeneratingNewBoard()
        {
            Tablero tablero = Tablero.GenerateBoard(15);

            Assert.AreEqual(15 * 15, tablero.Celdas.Length);
            Assert.AreEqual(15, tablero.Celdas.GetLength(0));
        }

        [TestMethod]
        public void TestWhen_()
        {
            var priestsDataSet = GeneradorDataSet.Priests();
            DataNamesMapper<Inventary> mapper = new DataNamesMapper<Inventary>();
            List<Inventary> persons = mapper.Map(priestsDataSet.Tables[0]).ToList();

            
        }
    }
}

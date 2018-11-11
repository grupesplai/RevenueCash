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

            //persons.AddRange(mapper.Map(ranchersDataSet.Tables[0]));

            IList<Inventary> lista = new List<Inventary>();
            foreach (var person in persons)
            {
                lista.Add(new Inventary() {
                    DateOfBirth = person.DateOfBirth,
                    FirstName = person.FirstName,
                     IsAmerican = person.IsAmerican,
                     JobTitle = person.JobTitle,
                     LastName = person.LastName,
                     TakenName = person.TakenName
                });
            }
            
        }
    }
}

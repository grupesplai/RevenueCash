using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevenueCash.Models.Piezas;
using System.Collections.Generic;
using System.Linq;

namespace RevenueCash.UnitTests
{
    [TestClass]
    public class MovimientosUnitTests
    {
        [TestMethod]
        public void TestWhen_GeneratingBoardFromString()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"---1---12-
                  -------1--
                  -11-------
                  ----------
                  ----------
                  ----BB----
                  --------3-
                  ----------
                  -2--------
                  ---------4", 3
            );

            Assert.AreEqual(null, tablero.Celdas[9, 0].Ficha);
            Assert.AreEqual(ColorFicha.Rojo, (tablero.Celdas[0, 3].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Amarillo, (tablero.Celdas[9, 9].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Verde, (tablero.Celdas[6, 8].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Azul, (tablero.Celdas[8, 1].Ficha as FichaRGB).Color);

            string tableroStr = tablero.ToString();
        }

        [TestMethod]
        public void TestWhen_GeneratingBoardFromStringWithRandoms()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"---1---12-
                  -------1--
                  -11-------
                  ----------
                  ----------
                  ----------
                  --------3-
                  ----------
                  -2--------
                  ---------4", 3
            );

            Assert.AreEqual(null, tablero.Celdas[9, 0].Ficha);
            Assert.AreEqual(ColorFicha.Rojo, (tablero.Celdas[0, 3].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Amarillo, (tablero.Celdas[9, 9].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Verde, (tablero.Celdas[6, 8].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Azul, (tablero.Celdas[8, 1].Ficha as FichaRGB).Color);
            string tableroStr = tablero.ToString();
        }

        [TestMethod]
        public void TestWhen_TreeInLine_1()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"-----
                  --2--
                  -1-1-
                  -----
                  -----", 1
            );

            IList<Celda> aRomper = tablero.NuevoMovimiento(2, 2, new FichaRGB(ColorFicha.Rojo));

            Assert.AreEqual(3, aRomper.Count);

            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 1) != 1) Assert.Fail("No hay ficha en posición (2,1)");
            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 2) != 1) Assert.Fail("No hay ficha en posición (2,2)");
            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 3) != 1) Assert.Fail("No hay ficha en posición (2,3)");
        }

        [TestMethod]
        public void TestWhen_TreeInLine_2()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"-----
                  --1--
                  ---2-
                  --1--
                  -----", 1
            );

            IList<Celda> aRomper = tablero.NuevoMovimiento(2, 2, new FichaRGB(ColorFicha.Rojo));

            Assert.AreEqual(3, aRomper.Count);

            if (aRomper.Count(t => t.RowIndex == 1 && t.ColIndex == 2) != 1) Assert.Fail("No hay ficha en posición (1,2)");
            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 2) != 1) Assert.Fail("No hay ficha en posición (2,2)");
            if (aRomper.Count(t => t.RowIndex == 3 && t.ColIndex == 2) != 1) Assert.Fail("No hay ficha en posición (3,2)");
        }

        [TestMethod]
        public void TestWhen_TreeInLine_3()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"-----
                  1----
                  -2---
                  1----
                  -----", 1
            );

            IList<Celda> aRomper = tablero.NuevoMovimiento(2, 0, new FichaRGB(ColorFicha.Rojo));

            Assert.AreEqual(3, aRomper.Count);

            if (aRomper.Count(t => t.RowIndex == 1 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (1,0)");
            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (2,0)");
            if (aRomper.Count(t => t.RowIndex == 3 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (3,0)");
        }

        [TestMethod]
        public void TestWhen_TreeInLine_4()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"-----
                  1----
                  -2---
                  11---
                  -----", 1
            );

            IList<Celda> aRomper = tablero.NuevoMovimiento(2, 0, new FichaRGB(ColorFicha.Rojo));

            Assert.AreEqual(4, aRomper.Count);

            if (aRomper.Count(t => t.RowIndex == 1 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (1,0)");
            if (aRomper.Count(t => t.RowIndex == 2 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (2,0)");
            if (aRomper.Count(t => t.RowIndex == 3 && t.ColIndex == 0) != 1) Assert.Fail("No hay ficha en posición (3,0)");
            if (aRomper.Count(t => t.RowIndex == 3 && t.ColIndex == 1) != 1) Assert.Fail("No hay ficha en posición (3,1)");
        }

        [TestMethod]
        public void TestWhen_GeneratingBoardWithBrick()
        {
            Tablero tablero = Tablero.GenerateBoardFromString(
                @"---1---12-
                  -------1--
                  -11-------
                  ----------
                  ----------
                  ----BB----
                  --------3-
                  ----------
                  -2--------
                  ---------4", 3
            );

            Assert.AreEqual(null, tablero.Celdas[9, 0].Ficha);
            Assert.AreEqual(ColorFicha.Rojo, (tablero.Celdas[0, 3].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Amarillo, (tablero.Celdas[9, 9].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Verde, (tablero.Celdas[6, 8].Ficha as FichaRGB).Color);
            Assert.AreEqual(ColorFicha.Azul, (tablero.Celdas[8, 1].Ficha as FichaRGB).Color);
            Assert.AreEqual(true, tablero.Celdas[5, 4].Ficha is FichaBrick);
            string tableroStr = tablero.ToString();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevenueCash.Models.Piezas;

namespace RevenueCash.UnitTests
{
    [TestClass]
    public class FichasUnitTests
    {
        [TestMethod]
        public void TestWhen_GeneratingPieceColor()
        {
            ColorFicha newColor = FichaRGB.GetRandomColorFicha();

            for (int vez = 1; vez <= 100; vez++)
            {
                ColorFicha otroColor = FichaRGB.GetRandomColorFicha();
                if (otroColor != newColor)
                    return;
            }

            Assert.Fail("No se generaron dos color distintos en 100 pasadas");
        }

        [TestMethod]
        public void TestWhen_GeneratingPieces()
        {
            FichaRGB newFicha = FichaRGB.GeneratePiece();

            for (int vez = 1; vez <= 100; vez++)
            {
                FichaRGB otraFicha = FichaRGB.GeneratePiece();
                if (otraFicha.Color != newFicha.Color)
                    return;
            }

            Assert.Fail("No se generaron dos fichas de color distinto en 100 pasadas");
        }

        [TestMethod]
        public void TestWhen_GeneratingPiecesNoRepeted()
        {
            ColorFicha newColor = FichaRGB.GetRandomColorFicha(3);

            for (int vez = 1; vez <= 8; vez++)
            {
                ColorFicha newColorDiferent = FichaRGB.GetRandomColorFicha(3);
                if (newColor != newColorDiferent)
                    Assert.AreNotEqual(newColor, newColorDiferent);
            }
        }
    }
}

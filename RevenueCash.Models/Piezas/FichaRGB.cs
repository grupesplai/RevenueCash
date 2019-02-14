using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.Models.Piezas
{
    public class FichaRGB : AbstractFicha
    {
        public FichaRGB()
        {
            base.Type = TypeFicha.ColorRGB;
        }

        public FichaRGB(ColorFicha color) : this()
        {
            this.Color = color;
        }

        public ColorFicha Color { get; set; }


        private static Random random = new Random();
        public static ColorFicha GetRandomColorFicha()
        {    
            int numeroRandom = random.Next(1, 5);           
            return (ColorFicha)numeroRandom;
        }

        public static ColorFicha GetRandomColorFicha(int maxRandom)
        {
           if(maxRandom > 5)  maxRandom = 5;
            int numeroRandom = random.Next(1, maxRandom);
            return (ColorFicha)numeroRandom;
        }

        public static FichaRGB GeneratePiece()
        {
            FichaRGB ficha = new FichaRGB();
            ficha.Color = FichaRGB.GetRandomColorFicha();
            return ficha;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.Models.Piezas
{
    public class Tablero
    {
        public Tablero()
        {
            FichaDisparo = new Dictionary<Posicion, IList<FichaDisparo>>();
        }

        public int Size { get; set; }

        public Celda[,] Celdas { get; set; }

        public int FaltanRomper
        {
            get
            {
                int cantidad = 0;
                foreach (var celda in Celdas)
                {
                    if (celda.Ficha != null) cantidad++;
                }
                return cantidad;
            }
        }

        public bool QuedanCeldasLibres
        {
            get
            {
                foreach (var celda in Celdas)
                {
                    if (celda.Ficha == null) return true;
                }
                return false;
            }
        }

        public static Tablero GenerateBoard(int size)
        {
            Tablero tablero = new Tablero();
            tablero.Size = size;
            tablero.Celdas = new Celda[size, size];

            return tablero;
        }

        public IDictionary<Posicion,IList<FichaDisparo>> FichaDisparo{ get; set; }


        IList<Celda> celdasYaChequeadas = new List<Celda>();

        public IList<Celda> NuevoMovimiento(int rowIndex, int colIndex, FichaRGB fichaNueva)
        {
            celdasYaChequeadas.Clear();
            IList<Celda> celdasARomper = new List<Celda>();

            this.Celdas[rowIndex, colIndex].Ficha = fichaNueva;
            celdasARomper.Add(this.Celdas[rowIndex, colIndex]);
            celdasYaChequeadas.Add(this.Celdas[rowIndex, colIndex]);


            checkCelda(rowIndex, colIndex - 1, fichaNueva, celdasARomper);
            checkCelda(rowIndex, colIndex + 1, fichaNueva, celdasARomper);
            checkCelda(rowIndex - 1, colIndex, fichaNueva, celdasARomper);
            checkCelda(rowIndex + 1, colIndex, fichaNueva, celdasARomper);

            if (celdasARomper.Count >= 3)
                return celdasARomper;
            else
                return null;

        }

        private bool yaSeChequeoCelda(int rowIndex, int colIndex)
        {
            return celdasYaChequeadas.Count(t => t.RowIndex == rowIndex && t.ColIndex == colIndex) > 0;
        }

       private void checkCelda(int rowIndex, int colIndex, FichaRGB fichaNueva, IList<Celda> celdasARomper)
        {
            if (yaSeChequeoCelda(rowIndex, colIndex)) return;
 
            if (rowIndex < 0 || colIndex < 0 || rowIndex > this.Size - 1 || colIndex > this.Size - 1)
                return;

            if (this.Celdas[rowIndex, colIndex].Ficha is FichaBrick)
            {
                this.celdasYaChequeadas.Add(this.Celdas[rowIndex, colIndex]);
                return;
            }
            if (this.Celdas[rowIndex, colIndex].Ficha != null && (this.Celdas[rowIndex, colIndex].Ficha as FichaRGB).Color == fichaNueva.Color)
            { 
                celdasARomper.Add(this.Celdas[rowIndex, colIndex]);
                this.celdasYaChequeadas.Add(this.Celdas[rowIndex, colIndex]);
                checkCelda(rowIndex - 1, colIndex, fichaNueva, celdasARomper);
                checkCelda(rowIndex + 1, colIndex, fichaNueva, celdasARomper);
                checkCelda(rowIndex, colIndex - 1, fichaNueva, celdasARomper);
                checkCelda(rowIndex, colIndex + 1, fichaNueva, celdasARomper);
            }
        }

        public static Tablero GenerateBoardFromString(string tableroStr, int levelNumber)
        {
            string[] lineas = tableroStr.Split('\n');
            Tablero tablero = Tablero.GenerateBoard(lineas.Length);

            int filaIndex = 0;
            foreach(string linea in lineas)
            {
                string lineaLimpia = linea.Trim().ToUpper();
                int colIndex = 0;
                foreach(char ficharChar in lineaLimpia)
                {
                    if (ficharChar == '-') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex);
                    if (ficharChar == '1') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaRGB(ColorFicha.Rojo));
                    if (ficharChar == '2') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaRGB(ColorFicha.Azul));
                    if (ficharChar == '3') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaRGB(ColorFicha.Verde));
                    if (ficharChar == '4') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaRGB(ColorFicha.Amarillo));
                    if (ficharChar == 'R') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaRGB(FichaRGB.GetRandomColorFicha(levelNumber + 2)));
                    if (ficharChar == 'B') tablero.Celdas[filaIndex, colIndex] = new Celda(filaIndex, colIndex, new FichaBrick());

                    colIndex++;
                }

                filaIndex++;
            }

            return tablero;
        }

        public override string ToString()
        {
            string tableroStr = "";

            for(var filaIndex = 0; filaIndex < this.Size; filaIndex++)
            {
                for(var columnaIndex = 0; columnaIndex < this.Size; columnaIndex++)
                {
                    if (this.Celdas[filaIndex, columnaIndex].Ficha == null)
                        tableroStr += "-";
                    else
                        if (this.Celdas[filaIndex, columnaIndex].Ficha is FichaRGB)
                        tableroStr += ((this.Celdas[filaIndex, columnaIndex].Ficha as FichaRGB).Color).ToString();//modificado
                    else tableroStr = "B";
                }

                tableroStr += "\n";
            }

            return tableroStr;
        }
    }
}

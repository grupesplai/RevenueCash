using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevenueCash.Models.Juego;
using RevenueCash.Models.Piezas;

namespace RevenueCash.ServicesLibrary.JuegosServices
{
    public class JuegoServices : IJuegoServices
    {
        public Game ComenzarNuevoJuego(int nivel)
        {
            Game nuevoJuego = Game.GenerateNewGame(GameDifficulty.Easy);
            nuevoJuego.Board = this.GetTableroDeNivel(1);
            return nuevoJuego;
        }

        public Game DisparaFicha(Game game, Posicion desdeDonde, int indice)
        {
            if(desdeDonde == Posicion.Arriba)
            {
                int indiceTope = -1;
                for (int fila = 0; fila<= game.Board.Size; fila++)
                {
                    if (game.Board.Celdas[fila, indice].Ficha != null)
                    {
                        if (fila == 0) return game;
                        indiceTope = fila - 1;
                        break;
                    }
                }
                    if(indiceTope == -1)return game;
                game.Board.Celdas[indiceTope,indice].Ficha = new Ficha(game.Board.FichaDisparo[desdeDonde][indice].Color);
                game.Board.FichaDisparo[desdeDonde][indice].Color = Ficha.GetRandomColorFicha();
                
            }
            return game;
        }

        public Tablero GetTableroDeNivel(int nivel)
        {
            if (nivel == 1)
            {
                Tablero tablero = Tablero.GenerateBoardFromString(
                @"XXXXXXXXXX
                  XXXXXXXXXX
                  XXXXXXXXXX
                  XXXXXXXXXX
                  XXXXXXRXXX
                  XXXXXXXRXX
                  XXXXXXXXXX
                  XXXXXRXXXX
                  XXRXXXXXXX
                  XXXXXXXXXX"
                );
                return tablero;
            }
            throw new Exception("NO se encontró el niviel deseado");
        }
        public IList<FichaDisparo> GetFichaDisparo(int size, Posicion desdeDonde)
        {
            IList<FichaDisparo> fichasLaterales = new List<FichaDisparo>();
            for (int indice = 0; indice < size; indice++) 
            {
                FichaDisparo ficha = new FichaDisparo(Ficha.GetRandomColorFicha(), desdeDonde,indice);
                fichasLaterales.Add(ficha);
            }
            return fichasLaterales;
        }
    }
}

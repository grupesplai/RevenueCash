using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevenueCash.Models.Juego;
using RevenueCash.Models.Piezas;
using RevenueCash.ServicesLibrary.Models;
using RevenueCash.Models;

namespace RevenueCash.ServicesLibrary.JuegosServices
{
    public class JuegoServices : IJuegoServices
    {
        public Game ComenzarNuevoJuego(int nivel)
        {
            Game nuevoJuego = Game.GenerateNewGame(GameDifficulty.Easy);
            nuevoJuego.CurrentLevel = this.GetLevel(1);
            nuevoJuego.Board = Tablero.GenerateBoardFromString(nuevoJuego.CurrentLevel.StringLevel);
            return nuevoJuego;
        }

        public Celda DisparaFicha(Game game, Posicion desdeDonde, int indice)
        {
            if(desdeDonde == Posicion.Arriba)
            {
                int indiceTope = -1;
                for (int fila = 0; fila<= game.Board.Size - 1; fila++)
                {
                    if (game.Board.Celdas[fila, indice].Ficha != null)
                    {
                        if (fila == 0) return null;
                        indiceTope = fila - 1;
                        break;
                    }
                }
                    if(indiceTope == -1) return null;
                //game.Board.Celdas[indiceTope,indice].Ficha = new Ficha(game.Board.FichaDisparo[desdeDonde][indice].Color);
                return game.Board.Celdas[indiceTope, indice];
            }

            if (desdeDonde == Posicion.Izquierda)
            {
                int indiceTope = -1;
                for (int columna = 0; columna <= game.Board.Size - 1; columna++)
                {
                    if (game.Board.Celdas[indice, columna].Ficha != null)
                    {
                        if (columna == 0) return null;
                        indiceTope = columna - 1;
                        break;
                    }
                }
                if (indiceTope == -1) return null;
                return game.Board.Celdas[indice, indiceTope];
            }

            if (desdeDonde == Posicion.Abajo)
            {
                int indiceTope = -1;
                for (int fila = game.Board.Size - 1; fila >= 0 ; fila--)
                {
                    if (game.Board.Celdas[fila, indice].Ficha != null)
                    {
                        if (fila == game.Board.Size -1) return null;
                        indiceTope = fila + 1;
                        break;
                    }
                }
                if (indiceTope == -1) return null;
                return game.Board.Celdas[indiceTope, indice];
            }

            if (desdeDonde == Posicion.Derecha)
            {
                int indiceTope = -1;
                for (int columna = game.Board.Size - 1; columna >= 0; columna--)
                {
                    if (game.Board.Celdas[indice, columna].Ficha != null)
                    {
                        if (columna == game.Board.Size - 1) return null;
                        indiceTope = columna + 1;
                        break;
                    }
                }
                if (indiceTope == -1) return null;
                return game.Board.Celdas[indice, indiceTope];
            }
            return null;
        }

        public Level GetLevel(int level)
        {
            if(Configurations.Levels.Count >= level)
            {
                return Configurations.Levels[level - 1];
            }
            throw new Exception("Level not found!");
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

        public MovimientoFicha NuevoMovimiento(Game game, Posicion desdeDonde, int indice)
        {
            MovimientoFicha movimiento = new MovimientoFicha();
            Celda dondePonerFicha = this.DisparaFicha(game, desdeDonde, indice);
            if (dondePonerFicha != null)
            {
                IList<Celda> celdasARomper = game.Board.NuevoMovimiento(dondePonerFicha.RowIndex, dondePonerFicha.ColIndex, new Ficha(game.Board.FichaDisparo[desdeDonde][indice].Color));
                if (celdasARomper != null)
                {
                    movimiento.CeldaRotas = celdasARomper;
                    movimiento.PuntosGanados = celdasARomper.Count * 10;
                    game.Score += movimiento.PuntosGanados;

                    foreach (var celda in celdasARomper)
                    {
                        game.Board.Celdas[celda.RowIndex, celda.ColIndex].Ficha = null;
                    }
                }
                game.Board.FichaDisparo[desdeDonde][indice].Color = Ficha.GetRandomColorFicha();
            }
            
            movimiento.Juego = game;

            return movimiento;
        }

        public Game GetNextLevel(Game actualGame)
        {
            actualGame.Score = 0;
            actualGame.CurrentLevel = this.GetLevel(2);
            actualGame.Board = Tablero.GenerateBoardFromString(actualGame.CurrentLevel.StringLevel);
            return actualGame;
        }
    }
}

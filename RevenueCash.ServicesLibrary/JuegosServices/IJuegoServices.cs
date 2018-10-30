using RevenueCash.Models.Juego;
using RevenueCash.Models.Piezas;
using RevenueCash.ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary.JuegosServices
{
    public interface IJuegoServices
    {
        Game ComenzarNuevoJuego(int nivel);

        Level GetLevel(int level);

        Celda DisparaFicha(Game game, Posicion desdeDonde, int indice);

        MovimientoFicha NuevoMovimiento(Game game, Posicion posicion, int indice);

        IList<FichaDisparo> GetFichaDisparo(Game juegoActual, Posicion desdeDonde);

        Game GetNextLevel(Game actualGame);
    }
}

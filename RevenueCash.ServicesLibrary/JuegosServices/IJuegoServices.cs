using RevenueCash.Models.Juego;
using RevenueCash.Models.Piezas;
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

        Tablero GetTableroDeNivel(int nivel);

        Game DisparaFicha(Game game, Posicion desdeDonde, int indice);

        IList<FichaDisparo> GetFichaDisparo(int size, Posicion desdeDonde);
    }
}

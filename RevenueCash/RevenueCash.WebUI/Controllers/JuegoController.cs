using RevenueCash.Models.Juego;
using RevenueCash.ServicesLibrary.JuegosServices;
using System.Web.Mvc;
using RevenueCash.Models.Piezas;
using System.Collections.Generic;
using RevenueCash.ServicesLibrary.Models;

namespace RevenueCash.WebUI.Controllers
{
    public class JuegoController : Controller
    {
        public object Game { get; private set; }

        public JuegoController()
        {
            _juegoServices = new JuegoServices();
        }

        private readonly IJuegoServices _juegoServices; 
        // GET: Juego
        public ActionResult Index()
        {
            if(Session["juegoActual"] != null)
            {
                Game gameActual = Session["juegoActual"] as Game;
                return View("Juego", gameActual);
            }
            return View();
        }
        public ActionResult Nuevo()
        {
            Game newGame = _juegoServices.ComenzarNuevoJuego(1);
            newGame.Board.FichaDisparo.Add(Posicion.Arriba, _juegoServices.GetFichaDisparo(newGame.Board.Size, Posicion.Arriba));
            newGame.Board.FichaDisparo.Add(Posicion.Abajo, _juegoServices.GetFichaDisparo(newGame.Board.Size, Posicion.Abajo));
            newGame.Board.FichaDisparo.Add(Posicion.Derecha, _juegoServices.GetFichaDisparo(newGame.Board.Size, Posicion.Derecha));
            newGame.Board.FichaDisparo.Add(Posicion.Izquierda, _juegoServices.GetFichaDisparo(newGame.Board.Size, Posicion.Izquierda));
            Session["juegoActual"] = newGame;
            return Redirect("/Juego");
        }

        public ActionResult Disparar(Posicion desdeDonde, int indice)
        {
            Game juegoActual = Session["juegoActual"] as Game;

            MovimientoFicha movimiento = _juegoServices.NuevoMovimiento(juegoActual, desdeDonde, indice);
            if (movimiento.Juego.JuegoFinalizado)
            {
                return RedirectToAction("/LevelFinished");
            }

            Session["juegoActual"] = movimiento.Juego;
            return Redirect("/Juego");
        }

        public ActionResult LevelFinished()
        {
            return View("/LevelFinished");
        }

        public ActionResult NextLevel(Posicion desdeDonde, int indice)
        {
            Game juegoActual = Session["juegoActual"]as Game;
            juegoActual = _juegoServices.GetNextLevel(juegoActual);

            Session["juegoActual"] = juegoActual;
            return Redirect("/Juego");

        }
    }
}
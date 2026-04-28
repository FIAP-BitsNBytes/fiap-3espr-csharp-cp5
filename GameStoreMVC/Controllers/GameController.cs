using Microsoft.AspNetCore.Mvc;

using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepositorio _repositorio;

        public GameController(IGameRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var games = _repositorio.ObterTodos();
            return View(games);
        }

        public IActionResult Criar()
        {
            return View(new Game());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }

            _repositorio.Adicionar(game);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var game = _repositorio.ObterPorId(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }

            _repositorio.Atualizar(game);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var game = _repositorio.ObterPorId(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmado(int id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

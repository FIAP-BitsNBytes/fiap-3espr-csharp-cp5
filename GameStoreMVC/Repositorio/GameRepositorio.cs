using GameStoreMVC.Interfaces;

using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;

namespace GameStoreMVC.Repositorio
{
    public class GameRepositorio : IGameRepositorio
    {
        private static readonly List<Game> Games = new();
        private static int _nextId = 1;

        public IEnumerable<Game> ObterTodos()
        {
            return Games.OrderBy(game => game.Nome).ToList();
        }

        public Game? ObterPorId(int id)
        {
            return Games.FirstOrDefault(game => game.Id == id);
        }

        public void Adicionar(Game game)
        {
            game.Id = _nextId++;
            Games.Add(game);
        }

        public void Atualizar(Game game)
        {
            var existente = ObterPorId(game.Id);
            if (existente == null)
            {
                return;
            }

            existente.Nome = game.Nome;
            existente.Genero = game.Genero;
            existente.Preco = game.Preco;
            existente.DataLancamento = game.DataLancamento;
        }

        public void Remover(int id)
        {
            var existente = ObterPorId(id);
            if (existente != null)
            {
                Games.Remove(existente);
            }
        }
    }
}

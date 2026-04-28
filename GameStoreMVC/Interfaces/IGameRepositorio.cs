using GameStoreMVC.Models;

namespace GameStoreMVC.Interfaces
{
    public interface IGameRepositorio
    {
        IEnumerable<Game> ObterTodos();
        Game? ObterPorId(int id);
        void Adicionar(Game game);
        void Atualizar(Game game);
        void Remover(int id);
    }
}

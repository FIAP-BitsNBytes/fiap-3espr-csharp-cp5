using GameStoreMVC.Models;

namespace GameStoreMVC.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidarLogin(string email, string senha);
        bool CriarUsuario(string nome, string email, string senha);
    }
}

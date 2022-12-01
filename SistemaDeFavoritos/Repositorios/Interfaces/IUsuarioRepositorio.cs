using SistemaDeFavoritos.Models;

namespace SistemaDeFavoritos.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id, string senha);
        Task<bool> Apagar(UsuarioModel usuario, int id, string senha);
    }
}

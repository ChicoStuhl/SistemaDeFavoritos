using SistemaDeFavoritos.Models;

namespace SistemaDeFavoritos.Repositorios.Interfaces
{
    public interface IFilmeRepositorio
    {
        Task<List<FilmeModel>> BuscarTodosFilmes();
        Task<FilmeModel> BuscarPorId(int id);
        Task<FilmeModel> Adicionar(FilmeModel filme);
        Task<FilmeModel> Atualizar(FilmeModel filme, int id);
        Task<bool> Apagar(int id);
    }
}

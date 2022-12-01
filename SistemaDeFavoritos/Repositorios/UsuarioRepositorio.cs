using Microsoft.EntityFrameworkCore;
using SistemaDeFavoritos.Data;
using SistemaDeFavoritos.Models;
using SistemaDeFavoritos.Repositorios.Interfaces;

namespace SistemaDeFavoritos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private SistemaDeFavoritosDBContext _dbContext;
        public UsuarioRepositorio(SistemaDeFavoritosDBContext sistemaDeFavoritosDBContext)
        {
            _dbContext = sistemaDeFavoritosDBContext;
        }
        
        public async Task<UsuarioModel> BuscarPorId(int id)
        {     
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id, string senha)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário de ID: {id} não foi encontrado no banco de dados!");
            }

            if (usuario.Senha != senha)
            {
                throw new Exception($"Senha do usuário de ID: {id} está incorreta!");
            }

            usuarioPorId.Nome= usuario.Nome;
            usuarioPorId.Email= usuario.Email;
            usuarioPorId.Idade= usuario.Idade;
            usuarioPorId.Senha= usuario.Senha;

            _dbContext.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }

        public async Task<bool> Apagar(UsuarioModel usuario, int id, string senha)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário de ID: {id} não foi encontrado no banco de dados!");
            }

            if (usuario.Senha != senha)
            {
                throw new Exception($"Senha do usuário de ID: {id} está incorreta!");
            }

            _dbContext.Usuarios.Remove(usuario);           
            await _dbContext.SaveChangesAsync();

            return true;

        }

        
    }
}

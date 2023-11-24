using BrincandoDeAPI.Data;
using BrincandoDeAPI.Models;
using BrincandoDeAPI.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrincandoDeAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<bool> RemoverUsuario(int id)
        {
            Usuario usuarioId = await BuscarPorId(id);
            if (usuarioId == null)
                throw new Exception("Usuario para o ID: não foi encontrado");

            _dbContext.Usuarios.Remove(usuarioId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, int id)
        {
            Usuario usuarioId = await BuscarPorId(id);
            if (usuarioId == null)
                throw new Exception("Usuario para o ID: não foi encontrado");

            usuarioId.NomeUsuario = usuario.NomeUsuario;
            usuarioId.Endereco = usuario.Endereco;
            usuarioId.CPF = usuario.CPF;
            usuarioId.Ativo= usuario.Ativo;

            _dbContext.Usuarios.Update(usuarioId);
            await _dbContext.SaveChangesAsync();

            return usuarioId;
        }
    }
}

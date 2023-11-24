using BrincandoDeAPI.Data;
using BrincandoDeAPI.Models;
using BrincandoDeAPI.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrincandoDeAPI.Repositorio
{
    public class TarefasRepositorio : ITarefaRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TarefasRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Tarefa>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).ToListAsync();
        }

        public async Task<Tarefa> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tarefa> Adicionar(Tarefa tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> Alterar(Tarefa tarefa, int id)
        {
            Tarefa tarefaEncontrada = await BuscarPorId(id);
            if(tarefaEncontrada == null)
                throw new Exception("Tarefa para o ID: não foi encontrado");

            tarefaEncontrada.Descricao = tarefa.Descricao;
            tarefaEncontrada.UsuarioId = tarefa.UsuarioId;
            tarefaEncontrada.Nome = tarefa.Nome;
            tarefaEncontrada.Status= tarefa.Status;

            _dbContext.Add(tarefaEncontrada);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> Excluir(int id)
        {
            Tarefa tarefa = await BuscarPorId(id);
            if(tarefa == null)
                throw new Exception("Tarefa para o ID: não foi encontrado");

            _dbContext.Remove(tarefa);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

using BrincandoDeAPI.Models;

namespace BrincandoDeAPI.Repositorio.Interfaces
{
    public interface ITarefaRepository
    {
        public Task<List<Tarefa>> BuscarTodasTarefas();
        public Task<Tarefa> BuscarPorId(int id);
        public Task<Tarefa> Adicionar(Tarefa tarefa);
        public Task<Tarefa> Alterar(Tarefa tarefa, int id);
        public Task<bool> Excluir(int id);
    }
}

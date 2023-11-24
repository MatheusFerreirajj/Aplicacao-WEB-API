using BrincandoDeAPI.Models;
using BrincandoDeAPI.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrincandoDeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> BuscarTodasTarefas()
        {
            List<Tarefa> tarefa = await _tarefaRepository.BuscarTodasTarefas();
            if(tarefa.Count == 0)
                return NotFound("Não foi encontrado nenhuma tarefa");

            return Ok(tarefa);
        }
        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<Tarefa>> BuscarTarefaPorId(int id)
        {
            Tarefa tarefa = await _tarefaRepository.BuscarPorId(id);
            if (tarefa == null)
                return NotFound("Não foi encontrado nenhuma tarefa com o id:");

            return Ok(tarefa);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<Tarefa>> Adicionar([FromBody] Tarefa tarefa)
        {
            await _tarefaRepository.Adicionar(tarefa);

            return Ok(tarefa);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<ActionResult<Tarefa>> Alterar([FromBody] Tarefa tarefa, int id)
        {
            tarefa.Id = id;
            Tarefa tarefaAlterar = await _tarefaRepository.Alterar(tarefa, id);

            return Ok(tarefaAlterar);
        }

        [HttpDelete("Excluir")]
        public async Task<ActionResult<bool>> Excluir(int id)
        {
            bool apagado = await _tarefaRepository.Excluir(id);

            return Ok(apagado);
        }

    }
}

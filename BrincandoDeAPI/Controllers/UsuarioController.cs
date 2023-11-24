using BrincandoDeAPI.Models;
using BrincandoDeAPI.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BrincandoDeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> BuscarTodosUsuarios()
        {
           List<Usuario> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            if (usuarios.Count == 0)
                return NotFound("Não foram encontrados nenhum usuário");

            return Ok(usuarios);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<Usuario>> BuscaUsuarioPorId(int id)
        {
            var usuario = await _usuarioRepository.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Não foi encontrado nenhum usuario com o id:");

            return Ok(usuario);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuario)
        {
            Usuario usuarioAdd = await _usuarioRepository.AdicionarUsuario(usuario);
            return Ok(usuarioAdd);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<ActionResult<Usuario>> Alterar([FromBody] Usuario usuario, int id)
        {
            usuario.Id = id;
            Usuario usuarioAlterar = await _usuarioRepository.AtualizarUsuario(usuario, id);

            return Ok(usuarioAlterar);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _usuarioRepository.RemoverUsuario(id);

            return Ok(apagado);
        }

    }
}

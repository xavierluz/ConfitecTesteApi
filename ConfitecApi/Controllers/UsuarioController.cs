using ConfitecApi.Commands;
using ConfitecApi.Handlers;
using ConfitecAplicacao.Usuarios.Interfaces;
using ConfitecCore.Usuarios.Entidades;
using ConfitecCore.Usuarios.Interfaces.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecApi.Controllers
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioAdicionarCommandHandler> logger;

        public UsuarioController(IMediator mediator, IUsuarioRepository repository, IUsuarioService usuarioService, ILogger<UsuarioAdicionarCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public async Task<IActionResult> AdicionarUsuario(AdicionarUsuarioCommand usuarioCommand)
        {
            usuarioCommand.ValidarData();
            var response = await _mediator.Send(usuarioCommand);
            return Ok(response);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioCommand  usuarioCommand)
        {
            usuarioCommand.ValidarData();
            var response = await _mediator.Send(usuarioCommand);
            return Ok(response);
        }

        [HttpPut("{id:int}/excluir")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            ExcluirUsuarioCommand usuarioCommand = new ExcluirUsuarioCommand();
            usuarioCommand.Id = id;
            var response = await _mediator.Send(usuarioCommand);
            return Ok(response);
        }

        [HttpGet("{id:int}/detalhes")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var response = await _repository.GetUsuario(id);
            return Ok(response);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _repository.GetUsuarios();
            return Ok(response);
        }
    }
}


using AutoMapper;
using ConfitecApi.Commands;
using ConfitecAplicacao.Usuarios.Interfaces;
using ConfitecCore.Usuarios.Entidades;
using MediatR;

namespace ConfitecApi.Handlers
{
    public class UsuarioAtualizarCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMediator _mediator;
        private IMapper _mapper;
        private ILogger<UsuarioAdicionarCommandHandler> _logger;

        public UsuarioAtualizarCommandHandler(IUsuarioService usuarioService, IMediator mediator, IMapper mapper, ILogger<UsuarioAdicionarCommandHandler> logger)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(request);
                await _usuarioService.Atualizar(usuario);
                _logger.LogInformation("Usuario atualizado com sucesso");
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Por verificar os dados do usuário");
            }
        }
    }
}

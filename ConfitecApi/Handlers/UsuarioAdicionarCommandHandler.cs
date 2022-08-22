using AutoMapper;
using ConfitecApi.Commands;
using ConfitecAplicacao.Usuarios.Interfaces;
using ConfitecCore.Usuarios.Entidades;
using MediatR;

namespace ConfitecApi.Handlers
{
    public class UsuarioAdicionarCommandHandler : IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMediator _mediator;
        private IMapper _mapper;
        private ILogger<UsuarioAdicionarCommandHandler> _logger;

        public UsuarioAdicionarCommandHandler(IUsuarioService usuarioService, IMediator mediator, IMapper mapper, ILogger<UsuarioAdicionarCommandHandler> logger)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(request);
                await _usuarioService.Adicionar(usuario);
                _logger.LogInformation("Usuario adicionado com sucesso");
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Por verificar os dados do usuário");
            }
        }
    }
}

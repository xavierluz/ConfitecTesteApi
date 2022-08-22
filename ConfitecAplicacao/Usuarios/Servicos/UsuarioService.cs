using ConfitecAplicacao.Usuarios.Interfaces;
using ConfitecCore.Usuarios.Entidades;
using ConfitecCore.Usuarios.Interfaces.Repositorios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecAplicacao.Usuarios.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository usuarioRepository;
        private ILogger<IUsuarioRepository> loggerUsuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<IUsuarioRepository> loggerUsuarioRepository)
        {
            this.usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            this.loggerUsuarioRepository = loggerUsuarioRepository ?? throw new ArgumentNullException(nameof(loggerUsuarioRepository));
        }

        public async  Task Adicionar(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException(nameof(usuario));

                await this.usuarioRepository.Adicionar(usuario);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            var resultado = await this.usuarioRepository.GetUsuario(usuario.Id);
            usuario.HistoricoEscolaridadeId = resultado.EscolaridadeId;

            await this.usuarioRepository.Atualizar(usuario);
        }

        public async Task Excluir(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));
            var resultado = await this.usuarioRepository.GetUsuario(id);

            await this.usuarioRepository.Excluir(resultado);
        }

        public  async Task<Usuario> GetUsuario(int id)
        {
            if (id < 1)
                throw new ArgumentNullException(nameof(id));

            var resultado = await this.usuarioRepository.GetUsuario(id);

            return resultado;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var resultados = await this.usuarioRepository.GetUsuarios();

            return resultados;
        }
    }
}

using ConfitecCore.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecAplicacao.Usuarios.Interfaces
{
    public interface IUsuarioService
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Excluir(int id);
        Task<Usuario> GetUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
    }
}

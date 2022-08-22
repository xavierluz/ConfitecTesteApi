using ConfitecCore.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecCore.Usuarios.Interfaces.Repositorios
{
    public interface IUsuarioRepository
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Excluir(Usuario usuario);
        Task<Usuario> GetUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
    }
}

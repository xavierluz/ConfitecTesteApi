using ConfitecCore.Usuarios.Entidades;
using ConfitecCore.Usuarios.Interfaces.Repositorios;
using ConfitecRepositorio.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecInfrastructure.Data.Repositorio
{
  
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly UsuarioContexto Contexto;

        public UsuarioRepository(UsuarioContexto contexto)
        {
            Contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public async Task Adicionar(Usuario usuario)
        {
            await Contexto.AddAsync(usuario);
            await Salvar();
        }

        public async Task Atualizar(Usuario usuario)
        {
            Contexto.Entry(usuario).State = EntityState.Modified;
            await Salvar();
        }

        public async Task Excluir(Usuario usuario)
        {
            Contexto.Remove(usuario);
            await Salvar();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var query = await Contexto.Usuarios.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var query = await Contexto.Usuarios.AsNoTracking().ToListAsync();

            return query;
        }

        private async Task<int> Salvar()
        {
            return await Contexto.SaveChangesAsync();
        }
    }
}

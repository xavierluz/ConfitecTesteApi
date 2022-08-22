using ConfitecCore.Usuarios.Agregacao;
using ConfitecCore.Usuarios.Entidades;
using ConfitecInfrastructure.Data.Mapeamento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecRepositorio.Data.Contexto
{
    public class UsuarioContexto:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options)
        {
                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapearUsuario.Mapear(modelBuilder);
        }
    }
}

using ConfitecCore.Usuarios.Agregacao;
using ConfitecCore.Usuarios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ConfitecInfrastructure.Data.Mapeamento
{
    internal static class MapearUsuario
    {
        internal static void Mapear(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Usuario>().Property(x => x.SobreNome).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(x => x.EscolaridadeId).IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.HistoricoEscolaridadeId);

            modelBuilder.Entity<Escolaridade>().HasKey(x => x.Id);
            modelBuilder.Entity<Escolaridade>().Property(x => x.Descricao).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Usuario>().HasOne(x => x.Escolaridade).WithMany(x => x.Usuarios).HasForeignKey(x => x.EscolaridadeId).IsRequired().HasConstraintName("FK_Escolaridade");
            modelBuilder.Entity<Usuario>().HasOne(x => x.Escolaridade).WithMany(x => x.Usuarios).HasForeignKey(x => x.HistoricoEscolaridadeId).HasConstraintName("FK_HistoricoEscaloridade");

        }
    }
}

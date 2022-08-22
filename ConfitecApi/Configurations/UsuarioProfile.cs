using AutoMapper;
using ConfitecApi.Commands;
using ConfitecCore.Usuarios.Entidades;

namespace ConfitecApi.Configurations
{
    public class UsuarioProfile: Profile
    {
        public UsuarioProfile()
        {
            CreateMap<AdicionarUsuarioCommand, Usuario>()
                .ForMember(c=> c.EscolaridadeId,u=> u.MapFrom(s=> s.EscolaridadeId))
                .ReverseMap();

            CreateMap<AtualizarUsuarioCommand, Usuario>()
               .ForMember(c => c.EscolaridadeId, u => u.MapFrom(s => s.EscolaridadeId))
               .ReverseMap();
        }
    }
}

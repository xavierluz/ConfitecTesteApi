using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ConfitecApi.Commands
{
    public class ExcluirUsuarioCommand : IRequest<bool>
    {
        [Required(ErrorMessage = "Id do usuário é obrigatório")]
        public int Id { get; set; }
        
    }
}

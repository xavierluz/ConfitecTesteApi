using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ConfitecApi.Commands
{
    public class AdicionarUsuarioCommand: IRequest<bool>
    {
        [Required(ErrorMessage ="Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o sobre nome do usuário")]
        public string SobreNome { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Digite email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite a da data nascimento")]
        [DataType(DataType.Date,ErrorMessage ="Digite uma data de nascimento válida")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage ="Selecione o tipo escolaridade")]
        public int EscolaridadeId { get; set; }

        public void ValidarData()
        {
            DateTime dataNascimento = new DateTime(DataNascimento.Year, DataNascimento.Month, DataNascimento.Day);
            DateTime agora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (dataNascimento >= agora)
                throw new ArgumentException(nameof(DataNascimento));
        }
    }
}

using ConfitecCore.Interfaces;
using ConfitecCore.Usuarios.Agregacao;
using ConfitecCore.Usuarios.Enumeracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConfitecCore.Usuarios.Entidades
{
    public class Usuario: IAggregateRoot
    {
        public Usuario(int id, string nome, string sobreNome, string email, DateTime dataNascimento, EnumTipoEscolaridade tipoEscolaridade)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            SobreNome = sobreNome ?? throw new ArgumentNullException(nameof(sobreNome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            DataNascimento = dataNascimento;
            ConverterEnumTipoEscolaridadeParaEscolaridade(tipoEscolaridade);
            ValidarEmail();
        }

        protected Usuario()
        {
            this.Nome = string.Empty;
            this.Email = string.Empty;   
            this.SobreNome = string.Empty;
        }

      

        public int Id { get; set; } 
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; } 
        public  int? HistoricoEscolaridadeId { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var _usuario = obj as IAggregateRoot;
            if (_usuario == null) throw new ArgumentNullException(nameof(obj));

            if (_usuario.Id == Id) return true;

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + Email.GetHashCode();
                hash = hash * 23 + Nome.GetHashCode();
                return hash;
            }
        }

        private void ConverterEnumTipoEscolaridadeParaEscolaridade(EnumTipoEscolaridade enumTipoEscolaridade)
        {
            if (Id == 0)
            {
                EscolaridadeId = (int)enumTipoEscolaridade;
                HistoricoEscolaridadeId = (int)enumTipoEscolaridade;
            }
            else
            {
                 HistoricoEscolaridadeId = (int)enumTipoEscolaridade;

            }
        }
        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email) || Email.Length < 5)
                throw new ArgumentOutOfRangeException(nameof(Email));

            Email = Email.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(Email, pattern))
                throw new ArgumentOutOfRangeException(nameof(Email));

        }
       
    }
}

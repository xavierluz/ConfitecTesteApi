using ConfitecCore.Interfaces;
using ConfitecCore.Usuarios.Entidades;
using ConfitecCore.Usuarios.Enumeracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecCore.Usuarios.Agregacao
{
    public class Escolaridade: IAggregateRoot
    {
        protected Escolaridade()
        {
            Descricao= String.Empty;
        }
        public Escolaridade(int id, string descricao, EnumTipoEscolaridade tipoEscolaridade)
        {
            Id = id;
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            TipoEscolaridade = tipoEscolaridade;
            ValidarEscolaridade();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public EnumTipoEscolaridade TipoEscolaridade { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        private void ValidarEscolaridade()
        {
            if (TipoEscolaridade != EnumTipoEscolaridade.Infantil
                                 || TipoEscolaridade != EnumTipoEscolaridade.Fundamental
                                 || TipoEscolaridade != EnumTipoEscolaridade.Medio
                                 || TipoEscolaridade != EnumTipoEscolaridade.Superior)
            {
                throw new ArgumentOutOfRangeException(nameof(this.TipoEscolaridade));
            }
        }
    }
}

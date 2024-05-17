using GerenciadorImoveis.Dominio.Enumeradores;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        #region Propriedades
        public string NomeCompleto { get; private set; }
        public string NomeUsuario { get; private set; }
        public string Senha { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Construtores
        public Usuario(string nomeUsuario, string senha, TipoUsuario tipoUsuario)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }

        public Usuario()
        {
            Ativo = true;
            Eventos = new HashSet<Evento>();            
        }
        #endregion

        #region Metodos publicos
        #endregion
    }
}

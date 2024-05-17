using GerenciadorImoveis.Dominio.Enumeradores;


namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Arquivo : Entidade
    {
        #region Propriedades
        public string Caminho { get; private set; }
        public TipoArquivo TipoArquivo { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Construtores        
        public Arquivo(TipoArquivo tipoArquivo)
        {
            Caminho = string.Empty;
            TipoArquivo = tipoArquivo;            
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        public Arquivo()
        {
            Caminho = string.Empty;
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        #endregion

        #region Metodos publicos
        public void AtualizarCaminho(string caminho)
        {
            Caminho = caminho;
        }
        #endregion
    }
}

using GerenciadorImoveis.Dominio.Enumeradores;


namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Arquivo : Entidade
    {
        #region Propriedades
        public string Caminho { get; private set; }
        public TipoArquivo TipoArquivo { get; private set; }
        #endregion

        #region Construtores        
        public Arquivo(TipoArquivo tipoArquivo,Usuario cadastradoPor)
        {
            Caminho = string.Empty;
            TipoArquivo = tipoArquivo;
            CadastradoPor = cadastradoPor;
            Ativo = true;
        }
        public Arquivo()
        {
            Caminho = string.Empty;
            Ativo = true;
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

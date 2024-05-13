using GerenciadorImoveis.Dominio.Enumeradores;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Documento : Entidade
    {
        #region Propriedades
        public string Identificador { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public long ClienteId { get; private set; } 
        public Cliente Cliente { get; private set; }
        #endregion

        #region Construtores
        public Documento(string identificador, TipoDocumento tipoDocumento, Usuario cadastradoPor)
        {
            Identificador = identificador;
            TipoDocumento = tipoDocumento;
            CadastradoPor = cadastradoPor;
            Ativo = true;
        }
        public Documento()
        {
            Ativo = true;
        }
        #endregion

        #region Metodos publicos
        public void AlterarIdentificador(string identificador)
        {
            Identificador = identificador;
        }
        public void AlterarTipoDocumento(TipoDocumento tipoDocumento)
        {
            TipoDocumento = tipoDocumento;
        }
        #endregion

    }
}

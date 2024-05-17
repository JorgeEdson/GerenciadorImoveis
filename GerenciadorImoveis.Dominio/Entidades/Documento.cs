using GerenciadorImoveis.Dominio.Enumeradores;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Documento : Entidade
    {
        #region Propriedades
        public string Identificador { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public long? ClienteId { get; private set; } 
        public Cliente? Cliente { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Construtores
        public Documento(string identificador, TipoDocumento tipoDocumento)
        {
            Identificador = identificador;
            TipoDocumento = tipoDocumento;            
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        public Documento()
        {
            Ativo = true;
            Eventos = new HashSet<Evento>();
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
        public void VincularCliente(Cliente cliente)
        {
            //Cliente = cliente;
            ClienteId = cliente.Id;
        }
        #endregion

    }
}

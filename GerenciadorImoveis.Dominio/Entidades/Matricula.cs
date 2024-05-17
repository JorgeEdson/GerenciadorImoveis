

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Matricula : Entidade
    {
        #region Propriedades
        public long? ImovelId { get; private set; }
        public Imovel? Imovel { get; private set; }
        public long? ArquivoId { get; private set; }
        public Arquivo? Arquivo { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Construtores
        public Matricula(Imovel imovel, Arquivo arquivo)
        {
            Imovel = imovel;
            Arquivo = arquivo;            
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        public Matricula()
        {
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        #endregion


    }
}

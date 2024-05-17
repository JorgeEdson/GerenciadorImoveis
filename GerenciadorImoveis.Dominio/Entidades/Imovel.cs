using GerenciadorImoveis.Dominio.Enumeradores;


namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Imovel : Entidade
    {
        #region Propriedades
        public long TipoImovelId { get; private set; }
        public TipoImovel TipoImovel { get; private set; }
        public long? ProprietarioId { get; private set; }
        public Cliente? Proprietario { get; private set; }
        public long? EnderecoId { get; private set; }
        public Endereco? Endereco { get; private set; }
        public ImovelStatus ImovelStatus { get; private set; }
        public decimal AreaTerreno { get; private set; }
        public decimal? AreaEdificacao { get; private set; }
        public decimal ValorAquisicao { get; private set; }
        public DateTime DataAquisicao { get; private set; }
        public long? MatriculaId { get; private set; }
        public Matricula? Matricula { get; private set; }
        //public long IptuId { get; private set; }
        //public Iptu Iptu { get; private set; }
        public long ?PlantaId { get; private set; }
        public Planta? Planta { get; private set; }        
        public ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Construtores
        public Imovel
            (
                TipoImovel tipoImovel,
                Cliente proprietario,
                Endereco endereco,                
                decimal areaTerreno,
                decimal areaEdificacao,
                decimal valorAquisicao,
                DateTime dataAquisicao,
                ImovelStatus imovelStatus,
                Usuario cadastradoPor) : base(cadastradoPor)
        {
            TipoImovel = tipoImovel;
            Proprietario = proprietario;
            Endereco = endereco;            
            AreaTerreno = areaTerreno;
            AreaEdificacao = areaEdificacao;
            ValorAquisicao = valorAquisicao;
            DataAquisicao = dataAquisicao;
            //HistoricoValorAluguel = new HashSet<ValorAluguel>();
            //HistoricoValorVenda = new HashSet<ValorVenda>();
            ImovelStatus = imovelStatus;
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        public Imovel()
        {
            //HistoricoValorAluguel = new HashSet<ValorAluguel>();
            //HistoricoValorVenda = new HashSet<ValorVenda>();
            Ativo = true;
            Eventos = new HashSet<Evento>();
        }
        #endregion

        #region Metodos publicos        
        public void VincularMatricula(Matricula matricula)
        {
            Matricula = matricula;
        }
        public void VincularPlanta(Planta planta)
        {
            Planta = planta;
        }
        #endregion









    }
}

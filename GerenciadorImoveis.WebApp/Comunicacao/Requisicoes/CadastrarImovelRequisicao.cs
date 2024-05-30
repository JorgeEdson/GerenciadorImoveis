namespace GerenciadorImoveis.Dominio.Comunicacao.Requisicoes
{
    public class CadastrarImovelRequisicao
    {
        public long CadastradoPorId { get; set; }
        public int TipoImovel { get; set; }        
        public long ProprietarioId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int UF { get; set; }
        public string Cep { get; set; }
        public decimal AreaTerreno { get; set; }
        public decimal AreaEdificacao { get; set; }
        public decimal ValorAquisicao { get; set; }
        public string DataAquisicao { get; set; }
    }
}
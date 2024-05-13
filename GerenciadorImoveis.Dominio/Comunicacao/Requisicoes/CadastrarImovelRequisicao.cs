namespace GerenciadorImoveis.Dominio.Comunicacao.Requisicoes
{
    public struct CadastrarImovelRequisicao
    {
        public long CadastradoPorId;
        public int TipoImovel;
        public int ImovelStatus;
        public long ProprietarioId;
        public string Logradouro;
        public string Bairro;
        public string Cidade;
        public int UF;
        public string Cep;
        public decimal AreaTerreno;
        public decimal AreaEdificacao;
        public decimal ValorAquisicao;
        public string DataAquisicao;
    }
}

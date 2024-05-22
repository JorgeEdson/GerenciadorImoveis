

namespace GerenciadorImoveis.Dominio.Comunicacao.Requisicoes
{
    public struct CadastrarClienteRequisicao
    {
        public string Nome;
        public string Nacionalidade;
        public string Profissao;
        public string DocumentoIdentificador;
        public int TipoDocumento;
        public string Logradouro;
        public string Bairro;
        public string Cidade;
        public int UF;
        public string Cep;
        public long CadastradoPorId;
    }
}

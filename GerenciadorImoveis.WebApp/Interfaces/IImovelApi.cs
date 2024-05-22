using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using Refit;

namespace GerenciadorImoveis.WebApp.Interfaces
{
    public interface IImovelApi
    {
        [Multipart]
        [Post("/api/Imovel/CadastrarImovel")]
        Task<ApiResponse<string>> CadastrarImovel(
            [AliasAs("matricula")] StreamPart matricula,
            [AliasAs("planta")] StreamPart? planta,
            [AliasAs("CadastradoPorId")] long cadastradoPorId,
            [AliasAs("TipoImovel")] int tipoImovel,
            [AliasAs("ImovelStatus")] int imovelStatus,
            [AliasAs("ProprietarioId")] long proprietarioId,
            [AliasAs("Logradouro")] string logradouro,
            [AliasAs("Bairro")] string bairro,
            [AliasAs("Cidade")] string cidade,
            [AliasAs("UF")] int uf,
            [AliasAs("Cep")] string cep,
            [AliasAs("AreaTerreno")] decimal areaTerreno,
            [AliasAs("AreaEdificacao")] decimal areaEdificacao,
            [AliasAs("ValorAquisicao")] decimal valorAquisicao,
            [AliasAs("DataAquisicao")] string dataAquisicao
        );
    }
}

using GerenciadorImoveis.Dominio.Comunicacao;
using Microsoft.AspNetCore.Http;

namespace GerenciadorImoveis.Dominio.Interfaces
{
    public interface IManipularArquivo
    {
        public Task<ResultadoGenerico> SalvarArquivoAsync(IFormFile arquivo, long idArquivo);        
    }
}

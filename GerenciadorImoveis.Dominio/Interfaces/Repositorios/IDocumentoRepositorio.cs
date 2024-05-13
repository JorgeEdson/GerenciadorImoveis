using GerenciadorImoveis.Dominio.Entidades;

namespace GerenciadorImoveis.Dominio.Interfaces.Repositorios
{
    public interface IDocumentoRepositorio : IRepositorioBase<Documento>
    {
        Task<Documento> ObterDocumentoPorIdentificadorAsync(string identifcador);
    }
}

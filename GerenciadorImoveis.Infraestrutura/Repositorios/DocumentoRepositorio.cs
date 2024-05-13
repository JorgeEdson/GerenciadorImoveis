using GerenciadorImoveis.Dominio.Consultas;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class DocumentoRepositorio : RepositorioBase<Documento>, IDocumentoRepositorio
    {
        public DocumentoRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {

        }

        public async Task<Documento?> ObterDocumentoPorIdentificadorAsync(string identifcador)
        {
            return await DbSet
                .AsNoTracking()
                .Where(DocumentoConsultas.ObterDocumentoPorIdentificador(identifcador))
                .FirstOrDefaultAsync();
        }
    }
}

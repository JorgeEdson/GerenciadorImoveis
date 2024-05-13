using GerenciadorImoveis.Dominio.Entidades;
using System.Linq.Expressions;


namespace GerenciadorImoveis.Dominio.Consultas
{
    public static class DocumentoConsultas
    {
        public static Expression<Func<Documento, bool>> ObterDocumentoPorIdentificador(string identificador)
        {
            return x => x.Identificador == identificador;
        }
    }
}

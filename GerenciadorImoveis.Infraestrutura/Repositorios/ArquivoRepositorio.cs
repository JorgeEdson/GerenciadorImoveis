using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;


namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class ArquivoRepositorio : RepositorioBase<Arquivo>, IArquivoRepositorio
    {
        public ArquivoRepositorio(ContextoBancoDeDados contexto):base(contexto)
        {
                
        }
    }
}

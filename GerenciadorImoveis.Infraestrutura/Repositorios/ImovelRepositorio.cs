using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class ImovelRepositorio : RepositorioBase<Imovel>, IImovelRepositorio
    {
        public ImovelRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
        }
    }
}

using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
        }
    }
}

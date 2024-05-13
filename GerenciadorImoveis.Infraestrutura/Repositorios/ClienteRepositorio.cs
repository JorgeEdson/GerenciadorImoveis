

using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {

        }
    }
}

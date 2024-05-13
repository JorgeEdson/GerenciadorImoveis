using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
                
        }
    }
}

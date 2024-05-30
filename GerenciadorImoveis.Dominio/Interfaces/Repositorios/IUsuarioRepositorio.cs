using GerenciadorImoveis.Dominio.Entidades;

namespace GerenciadorImoveis.Dominio.Interfaces.Repositorios
{    
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {        
        Task<Usuario> AutenticarUsuario(string nomeUsuario, string senha);
    }
}

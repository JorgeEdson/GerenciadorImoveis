using GerenciadorImoveis.Dominio.Consultas;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
                
        }

        public async Task<Usuario?> AutenticarUsuario(string nomeUsuario, string senha)
        {
            return await DbSet
                .AsNoTracking()
                .Where(UsuarioConsultas.AutenticarUsuario(nomeUsuario, senha))
                .FirstOrDefaultAsync();
        }
    }
}

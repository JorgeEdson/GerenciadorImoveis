using GerenciadorImoveis.Dominio.Entidades;
using System.Linq.Expressions;

namespace GerenciadorImoveis.Dominio.Consultas
{
    public static class UsuarioConsultas
    {
        //AutenticarUsuario
        public static Expression<Func<Usuario, bool>> AutenticarUsuario(string nomeUsuario, string senha)
        {
            return x => x.NomeUsuario == nomeUsuario && x.Senha == senha;
        }
    }
}

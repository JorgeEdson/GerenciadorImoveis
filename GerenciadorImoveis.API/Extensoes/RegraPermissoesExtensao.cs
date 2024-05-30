using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Enumeradores;
using System.Security.Claims;

namespace GerenciadorImoveis.API.Extensoes
{
    public static class RegraPermissoesExtensao
    {
        public static IEnumerable<Claim> ObterRegras(this Usuario usuario)
        {
            List<Claim> resultado = usuario.TipoUsuario switch
            {
                TipoUsuario.ADMINISTRADOR =>
                [
                    new(ClaimTypes.NameIdentifier,usuario.Id.ToString()),
                    new(ClaimTypes.Name, usuario.NomeUsuario ?? ""),                    
                    new Claim(ClaimTypes.Role, "ADMINISTRADOR")                    
                ],
                TipoUsuario.AUXILIAR =>
                [
                    new(ClaimTypes.NameIdentifier,usuario.Id.ToString()),
                    new(ClaimTypes.Name, usuario.NomeUsuario ?? ""),
                    new Claim(ClaimTypes.Role, "AUXILIAR")
                ],
                _ => [],
            };
            return resultado;
        }
    }
}

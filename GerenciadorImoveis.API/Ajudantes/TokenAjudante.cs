using GerenciadorImoveis.API.Extensoes;
using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorImoveis.API.Ajudantes
{
    public class TokenAjudante
    {
        public string GerarToken(Usuario usuario)
        {
            var tokenManipulador = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Configuracoes.ChaveJwt);
            var permissoes = usuario.ObterRegras();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(permissoes),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenManipulador.CreateToken(tokenDescriptor);
            return tokenManipulador.WriteToken(token);
        }
    }
}

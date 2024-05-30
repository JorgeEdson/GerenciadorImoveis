using GerenciadorImoveis.API.Ajudantes;
using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorImoveis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UsuarioController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> Autenticar(
            [FromBody] AutenticarUsuarioRequisicao requisicao,
            [FromServices] TokenAjudante tokenAjudante,
            [FromServices] UsuarioManipulador usuarioManipulador)
        {
            try 
            {
                var resultado = await usuarioManipulador.Executar(requisicao);

                if (resultado.Dados != null)
                {
                    var token = tokenAjudante.GerarToken((Usuario)resultado.Dados);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Não Autorizado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorImoveis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ClienteController : ControllerBase
    {
        [HttpPost("CadastrarCliente")]
        public async Task<IActionResult> CadastrarCliente(            
            [FromForm] CadastrarClienteRequisicao requisicao,            
            [FromServices] ClienteManipulador clienteManipulador)       
        {
            var resultado = await clienteManipulador.Executar(requisicao);

            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);

            return BadRequest(resultado.Mensagem);
        }
    }
}

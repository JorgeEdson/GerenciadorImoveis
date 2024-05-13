using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorImoveis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ImovelController : ControllerBase
    {
        [HttpPost("CadastrarImovel")]
        public async Task<IActionResult> CadastrarImovel(
             [FromForm] IFormFile matricula,
             [FromForm] IFormFile? planta,             
             [FromForm] CadastrarImovelRequisicao requisicao,
             [FromServices] ImovelManipulador imovelManipulador)
        {            
            var listaArquivos = new List<IFormFile>();
            listaArquivos.Add(matricula);
            
            if (planta != null)
                listaArquivos.Add(planta);

            var resultado = await imovelManipulador.Executar(requisicao,listaArquivos);

            if (resultado.Sucesso)
                return Ok(resultado.Mensagem);

            return BadRequest(resultado.Mensagem);
        }
    }
}

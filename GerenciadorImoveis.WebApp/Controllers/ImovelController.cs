using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Enumeradores;
using GerenciadorImoveis.WebApp.Extensoes;
using GerenciadorImoveis.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Security.Claims;

namespace GerenciadorImoveis.WebApp.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelApi _imovelApi;
        public ImovelController()
        {
            _imovelApi = RestService.For<IImovelApi>("https://localhost:7149");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            ViewBag.CadastradoPorId = userIdClaim.Value;
            ViewBag.TipoImovelList = EnumeradorExtensao.ToSelectList<TipoImovel>();
            ViewBag.UFList = EnumeradorExtensao.ToSelectList<UF>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(IFormFile matricula, IFormFile? planta, CadastrarImovelRequisicao requisicao)
        {
            if (matricula == null)
            {
                ModelState.AddModelError(string.Empty, "Matricula é obrigatória.");
                return View(requisicao);
            }

            try
            {
                var matriculaPart = new StreamPart(matricula.OpenReadStream(), matricula.FileName, matricula.ContentType);

                StreamPart? plantaPart = null;
                if (planta != null)
                {
                    plantaPart = new StreamPart(planta.OpenReadStream(), planta.FileName, planta.ContentType);
                }

                var resposta = await _imovelApi.CadastrarImovel(
                    matriculaPart,
                    plantaPart,
                    requisicao.CadastradoPorId,
                    requisicao.TipoImovel,                    
                    requisicao.ProprietarioId,
                    requisicao.Logradouro,
                    requisicao.Bairro,
                    requisicao.Cidade,
                    requisicao.UF,
                    requisicao.Cep,
                    requisicao.AreaTerreno,
                    requisicao.AreaEdificacao,
                    requisicao.ValorAquisicao,
                    requisicao.DataAquisicao
                );

                if (resposta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Sucesso");
                }

                ModelState.AddModelError(string.Empty, "Erro ao cadastrar imóvel: " + response.Error.Content);
            }
            catch (ApiException ex)
            {
                // Log the error
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar imóvel: " + ex.Content);
            }

            return View(requisicao);
        }


        public IActionResult Sucesso()
        {
            return View();
        }
    }
}

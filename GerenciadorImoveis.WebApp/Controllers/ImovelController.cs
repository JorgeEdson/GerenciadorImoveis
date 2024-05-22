using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Refit;

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

                var response = await _imovelApi.CadastrarImovel(
                    matriculaPart,
                    plantaPart,
                    requisicao.CadastradoPorId,
                    requisicao.TipoImovel,
                    requisicao.ImovelStatus,
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

                if (response.IsSuccessStatusCode)
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

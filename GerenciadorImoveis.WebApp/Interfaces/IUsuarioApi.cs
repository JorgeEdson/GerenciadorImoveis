using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using Refit;

namespace GerenciadorImoveis.WebApp.Interfaces
{
    public interface IUsuarioApi
    {
        [Post("/api/Usuario/Autenticar")]
        Task<string> Autenticar([Body] AutenticarUsuarioRequisicao requisicao);
    }
}

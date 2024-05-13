using GerenciadorImoveis.Dominio.Comunicacao;

namespace GerenciadorImoveis.Dominio.Interfaces
{
    public interface IManipulador<T>
    {
        Task<ResultadoGenerico> Executar(T requisícao);
    }
    
    public interface IManipuladorComListaArquivos<T,Z>
    {
        Task<ResultadoGenerico> Executar(T requisicao, List<Z> listaArquivos);
    }
}

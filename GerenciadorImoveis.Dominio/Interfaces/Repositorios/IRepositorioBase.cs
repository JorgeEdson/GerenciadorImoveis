using GerenciadorImoveis.Dominio.Entidades;

namespace GerenciadorImoveis.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<ClasseGenerica> where ClasseGenerica : Entidade
    {
        Task<long> SalvarAsync(ClasseGenerica objetoParametro);
        Task AtualizarAsync(ClasseGenerica objetoParametro);
        Task ExcluirAsync(ClasseGenerica objetoParametro);
        Task<ClasseGenerica?> ObterPorIdAsync(long id);
        Task<ClasseGenerica?> ObterAtivoPorIdAsync(long id);
        Task<IEnumerable<ClasseGenerica>> ObterTodosAsync();
    }
}

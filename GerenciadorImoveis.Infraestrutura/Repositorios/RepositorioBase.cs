using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase<ClasseGenerica> : IRepositorioBase<ClasseGenerica> where ClasseGenerica : Entidade
    {
        protected readonly ContextoBancoDeDados _contexto;
        public DbSet<ClasseGenerica> DbSet { get; set; }

        protected RepositorioBase(ContextoBancoDeDados contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<ClasseGenerica>();
        }

        public async Task AtualizarAsync(ClasseGenerica objetoParametro)
        {
            DbSet.Update(objetoParametro);
            await _contexto.SaveChangesAsync();
        }

        public async Task ExcluirAsync(ClasseGenerica objetoParametro)
        {
            DbSet.Remove(objetoParametro);
            await _contexto.SaveChangesAsync();
        }

        public async Task<ClasseGenerica?> ObterPorIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<ClasseGenerica?> ObterAtivoPorIdAsync(long id)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Id == id && e.Ativo);
        }

        public async Task<IEnumerable<ClasseGenerica>> ObterTodosAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<long> SalvarAsync(ClasseGenerica objetoParametro)
        {
            await DbSet.AddAsync(objetoParametro);
            await _contexto.SaveChangesAsync();
            return objetoParametro.Id;
        }
    }
}
